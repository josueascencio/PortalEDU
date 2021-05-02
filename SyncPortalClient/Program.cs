using Dotmim.Sync;
using Dotmim.Sync.Enumerations;
using Dotmim.Sync.SqlServer;
using Dotmim.Sync.Web.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SyncPortalClient
{
    class Program
    {

        private static string clientConnectionString = $"Data Source=LA-SV-VT-01-136; Initial Catalog=CE1PortalEDU5; user id=sa; pwd=Ef1c13nc1@; Trusted_Connection=false; MultipleActiveResultSets=true;";

        static async Task Main(string[] args)
        {
            Console.WriteLine("POr favor verifique que la API del Portal Educativo se encuentre activa antes de sincronizar");
            Console.ReadLine();
            await SynchronizeAsync();
        }

        private static async Task SynchronizeAsync()
        {
            // Database script used for this sample : https://github.com/Mimetis/Dotmim.Sync/blob/master/CreateAdventureWorks.sql 



            // Getting a JWT token
            // You should get a Jwt Token from an identity provider like Azure, Google, AWS or other.
            var token = GenerateJwtToken("portaleducativo@gmail.com", "PORTAL01");
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);




            var serverOrchestrator = new WebClientOrchestrator("https://localhost:44383/api/sync", client:httpClient);

            // Second provider is using plain old Sql Server provider, relying on triggers and tracking tables to create the sync environment
            var clientProvider = new SqlSyncProvider(clientConnectionString);


            //var tables = new string[] { "Product", "Customer" };

            //var syncSetup = new SyncSetup(tables);
            //syncSetup.Tables["Product"].SyncDirection = SyncDirection.UploadOnly;
            //syncSetup.Tables["Customer"].SyncDirection = SyncDirection.UploadOnly;

            // Creating an agent that will handle all the process
            var agent = new SyncAgent(clientProvider, serverOrchestrator);

            // Previene eliminacion de tablas desde el cliente
            
            agent.LocalOrchestrator.OnTableChangesSelected(args =>
            {
                if (args.Changes == null || !args.Changes.HasRows)
                    return;

                foreach (var changedRow in args.Changes.Rows.ToArray())
                {
                    if (changedRow.RowState == DataRowState.Deleted)
                        args.Changes.Rows.Remove(changedRow);
                }
            });

            // Ejecucion del agente
            do
            {
                try
                {
                    var progress = new SynchronousProgress<ProgressArgs>(args => Console.WriteLine($"{args.PogressPercentageString}:\t{args.Message}"));
                    // Launch the sync process
                    var s1 = await agent.SynchronizeAsync(progress);
                    // Write results
                    Console.WriteLine(s1);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("End");
        }

        // Creacion del token
        private static string GenerateJwtToken(string email, string userid)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, "portaleducativo.com"),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userid)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SOME_RANDOM_KEY_DO_NOT_SHARE"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(Convert.ToDouble(10));

            var token = new JwtSecurityToken(
                "portaleducativo.com",
                "portaleducativo.com",
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }


}

