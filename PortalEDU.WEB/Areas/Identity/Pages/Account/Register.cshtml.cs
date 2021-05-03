using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using PortalEDU.Models;
using PortalEDU.Utilidades;

namespace PortalEDU.WEB.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Correo electronico")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "El {0} debe ser de por lo menos {2} y un maximo de {1} caracteres longitud.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña no coincide")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "El Codigo del Centro Escolar es obligatorio")]
            [MaxLength(5, ErrorMessage = "{0} can have a max of {1} characters")]
            [Display(Name = "Codigo de su Centro Educativo")]
            public string CodigoCE { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    CodigoCE = Input.CodigoCE,
                    // Ciudad = Input.Ciudad,
                    //Direccion = Input.Direccion,
                    //Pais = Input.Pais,
                    //PhoneNumber = Input.PhoneNumber,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    // Aqui validamos si los roles existen, sino se crean
                    if (!await _roleManager.RoleExistsAsync(Constantes.Admin))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Constantes.Admin));
                        await _roleManager.CreateAsync(new IdentityRole(Constantes.Alumno));
                        await _roleManager.CreateAsync(new IdentityRole(Constantes.Anonimo));
                        await _roleManager.CreateAsync(new IdentityRole(Constantes.Docente));
                        await _roleManager.CreateAsync(new IdentityRole(Constantes.Responsable));
                    }

                    //Obterne el rol del usuario
                    string rol = Request.Form["radUsuarioRole"].ToString();

                    //Validamos el rol seleccionado
                    if (rol == Constantes.Admin)
                    {
                        await _userManager.AddToRoleAsync(user, Constantes.Admin);
                    }
                    else if (rol == Constantes.Alumno)
                    {
                        await _userManager.AddToRoleAsync(user, Constantes.Alumno);

                    }
                    else if (rol == Constantes.Anonimo)
                    {
                        await _userManager.AddToRoleAsync(user, Constantes.Anonimo);

                    }
                    else if (rol == Constantes.Docente)
                    {
                        await _userManager.AddToRoleAsync(user, Constantes.Docente);

                    }
                    else
                    {
                        if (rol == Constantes.Responsable)
                        {
                            await _userManager.AddToRoleAsync(user, Constantes.Responsable);

                        }
                    }


                    _logger.LogInformation("Usuario creado con exito");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);


                    //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //    var callbackUrl = Url.Page(
                    //        "/Account/ConfirmEmail",
                    //        pageHandler: null,
                    //        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //        protocol: Request.Scheme);

                    //    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //    {
                    //        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //    }
                    //    else
                    //    {
                    //        await _signInManager.SignInAsync(user, isPersistent: false);
                    //        return LocalRedirect(returnUrl);
                    //    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}