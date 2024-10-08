using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace APIPix.Pages
{
    public class FinanceiroModel : PageModel
    {
        public decimal SaldoAtual { get; set; }
        public decimal ReceitasTotais { get; set; }
        public decimal DespesasTotais { get; set; }
        public List<Transacao> Transacoes { get; set; }

        public void OnGet()
        {
            // Exemplo de dados fictícios
            SaldoAtual = 2500.00m;
            ReceitasTotais = 5000.00m;
            DespesasTotais = 2500.00m;
        }
    }
}
