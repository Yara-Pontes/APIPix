using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace APIPix.Pages
{
    public class AnalyticsModel : PageModel
    {
        public List<AnalyticsItem> AnalyticsData { get; set; }

        public void OnGet()
        {
            // L�gica para carregar dados de an�lise
            AnalyticsData = new List<AnalyticsItem>
            {
                new AnalyticsItem { Endpoint = "/api/pagamentos", Transacoes = 120, Erros = 2 },
                new AnalyticsItem { Endpoint = "/api/cobran�as", Transacoes = 80, Erros = 1 }
                // Substitua pelos dados reais do seu sistema
            };
        }

        public class AnalyticsItem
        {
            public string Endpoint { get; set; }
            public int Transacoes { get; set; }
            public int Erros { get; set; }
        }
    }
}
