// AnalyticsModel.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace APIPix.Pages
{
    public class AnalyticsModel : PageModel
    {
        public int TotalTransacoes { get; set; }
        public decimal ValorTotalMovimentado { get; set; }
        public int TotalTransacoesSucesso { get; set; }

        public int TransacoesFaixa1 { get; set; }
        public int TransacoesFaixa2 { get; set; }
        public int TransacoesFaixa3 { get; set; }
        public int TransacoesFaixa4 { get; set; }

        public List<ErroEndpoint> ErrosPorEndpoint { get; set; }

        public void OnGet()
        {
            // Dados fict�cios para simula��o
            TotalTransacoes = 1500; // Exemplo fict�cio
            ValorTotalMovimentado = 500000.50m; // Exemplo fict�cio
            TotalTransacoesSucesso = 1450; // Exemplo fict�cio

            // Distribui��o das transa��es por faixa de valor
            TransacoesFaixa1 = 300; // Exemplo fict�cio
            TransacoesFaixa2 = 500; // Exemplo fict�cio
            TransacoesFaixa3 = 400; // Exemplo fict�cio
            TransacoesFaixa4 = 300; // Exemplo fict�cio

            // Erros por endpoint (dados fict�cios)
            ErrosPorEndpoint = new List<ErroEndpoint>
            {
                new ErroEndpoint { Endpoint = "/api/pix/transferir", QuantidadeErros = 5, ErroMaisComum = "Timeout" },
                new ErroEndpoint { Endpoint = "/api/pix/consultar", QuantidadeErros = 2, ErroMaisComum = "Erro de Valida��o" }
            };
        }
    }

    public class ErroEndpoint
    {
        public string Endpoint { get; set; }
        public int QuantidadeErros { get; set; }
        public string ErroMaisComum { get; set; }
    }
}
