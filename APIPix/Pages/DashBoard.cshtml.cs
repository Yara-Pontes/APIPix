using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APIPix.Pages
{
    public class DashboardModel : PageModel
    {
        public string Usuario { get; set; }
        public decimal TotalTransacoes { get; set; }
        public decimal SaldoAtual { get; set; }
        public int ClientesCadastrados { get; set; }

        public void OnGet()
        {
            // Recupera os dados da sessão ou TempData
            Usuario = TempData["Usuario"]?.ToString() ?? "Usuário";
            TotalTransacoes = Convert.ToDecimal(TempData["TotalTransacoes"] ?? 0);
            SaldoAtual = Convert.ToDecimal(TempData["SaldoAtual"] ?? 0);
            ClientesCadastrados = Convert.ToInt32(TempData["ClientesCadastrados"] ?? 0);
        }
    }
}
