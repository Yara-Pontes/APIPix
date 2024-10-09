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
            // Lógica de autenticação simulada
            if (ModelState.IsValid)
            {
                if (Username == "admin" && Password == "12345")
                {
                    // Definir os dados do usuário no cookie
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, Username)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    // Fazer login do usuário
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    // Redireciona para o dashboard após login bem-sucedido
                    return RedirectToPage("/Dashboard");
                }
                else
                {
                    ErrorMessage = "Usuário ou senha inválidos.";
                    return Page();
                }
            }

            // Se a validação falhar, retorna à página de login
            return Page();
        }
    }
}
