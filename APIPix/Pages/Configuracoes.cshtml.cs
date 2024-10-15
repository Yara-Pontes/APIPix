using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APIPix.Pages
{
    public class ConfiguracoesModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string NovaSenha { get; set; }

        [BindProperty]
        public string AutenticacaoDupla { get; set; }

        [BindProperty]
        public decimal LimiteDiario { get; set; }

        public void OnGet()
        {
            // Aqui voc� pode carregar as configura��es existentes, se houver.
            // Por exemplo, carregando do banco de dados ou de um arquivo de configura��o.
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Retorna � p�gina com erros de valida��o
            }

            // L�gica para salvar as configura��es.
            // Voc� pode implementar aqui a l�gica para persistir as configura��es em um banco de dados ou em um arquivo de configura��o.

            return RedirectToPage("Sucesso"); // Redireciona para uma p�gina de sucesso ap�s salvar
        }
    }
}
