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
            // Aqui você pode carregar as configurações existentes, se houver.
            // Por exemplo, carregando do banco de dados ou de um arquivo de configuração.
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Retorna à página com erros de validação
            }

            // Lógica para salvar as configurações.
            // Você pode implementar aqui a lógica para persistir as configurações em um banco de dados ou em um arquivo de configuração.

            return RedirectToPage("Sucesso"); // Redireciona para uma página de sucesso após salvar
        }
    }
}
