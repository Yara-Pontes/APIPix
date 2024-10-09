using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace APIPix.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            // L�gica de autentica��o simulada
            if (ModelState.IsValid)
            {
                if (Username == "admin" && Password == "12345")
                {
                    // Definir os dados do usu�rio no cookie
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, Username)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    // Fazer login do usu�rio
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    // Redireciona para o dashboard ap�s login bem-sucedido
                    return RedirectToPage("/Dashboard");
                }
                else
                {
                    ErrorMessage = "Usu�rio ou senha inv�lidos.";
                    return Page();
                }
            }

            // Se a valida��o falhar, retorna � p�gina de login
            return Page();
        }
    }
}
