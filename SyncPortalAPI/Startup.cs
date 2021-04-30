using Dotmim.Sync;
using Dotmim.Sync.Enumerations;
using Dotmim.Sync.MySql;
using Dotmim.Sync.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPortalAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddControllers();


            //Sincronizacion

            // [Required]: To be able to handle multiple sessions
            services.AddMemoryCache();


            // Adding a default authentication system
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims



            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidIssuer = "portaleducativo.com",
                            ValidAudience = "portaleducativo.com",
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SOME_RANDOM_KEY_DO_NOT_SHARE"))
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                Debug.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                Debug.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                return Task.CompletedTask;
                            }
                        };
                    });






            // [Required]: Get a connection string to your server data source
            var connectionString = Configuration.GetSection("ConnectionStringsAPI")["SqlConnection"];

            //var connectionStringMy = Configuration.GetSection("ConnectionStringsAPI")["MySqlConnection"];

            // [Required]: Tables list involved in the sync process
            var tables = new string[] { "Product", "Customer" };

            var syncSetup = new SyncSetup(tables);
            syncSetup.Tables["Product"].SyncDirection = SyncDirection.UploadOnly;
            syncSetup.Tables["Customer"].SyncDirection = SyncDirection.UploadOnly;

            // [Required]: Add a SqlSyncProvider acting as the server hub.
            services.AddSyncServer<SqlSyncChangeTrackingProvider>(connectionString, syncSetup);
            //services.AddSyncServer<MySqlSyncProvider>(connectionStringMy, tables);
            //EndSincronizacion




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SyncPortal v1"));
            //}
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

