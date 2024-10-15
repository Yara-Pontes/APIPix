using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APIPix.Pages
{
    public class FinanceiroModel : PageModel
    {
        public decimal SaldoAtual { get; set; }
        public decimal ReceitasTotais { get; set; }
        public decimal DespesasTotais { get; set; }

        public void OnGet()
        {
            // Aqui você vai implementar a lógica para obter os dados do banco de dados.
            // Exemplo:
            SaldoAtual = 1000.00m; // Substitua pelo valor do banco de dados
            ReceitasTotais = 5000.00m; // Substitua pelo valor do banco de dados
            DespesasTotais = 4000.00m; // Substitua pelo valor do banco de dados
        }
    }
}
