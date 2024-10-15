using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace APIPix.Pages
{
    public class SuporteModel : PageModel
    {
        [BindProperty]
        public string Nome { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string TipoSolicitacao { get; set; }
        [BindProperty]
        public string Descricao { get; set; }
        [BindProperty]
        public IFormFile Anexo { get; set; }

        public bool Success { get; set; } = false;
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Por favor, preencha todos os campos obrigatórios.";
                return Page();
            }

            try
            {
                // Aqui você pode processar a solicitação, por exemplo, salvar os dados em um banco de dados
                // Se houver um arquivo anexado, você pode salvá-lo em um diretório
                if (Anexo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "uploads", Anexo.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        Anexo.CopyTo(stream);
                    }
                }

                // Defina a variável de sucesso como verdadeira
                Success = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = "Houve um erro ao enviar sua solicitação: " + ex.Message;
            }

            return Page();
        }
    }
}
