using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace APIPix.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

            // Dados fictícios para o painel
            TotalTransacoes = 1500.75m;
            SaldoAtual = 500.00m;
            ClientesCadastrados = 120;
            //TransacoesRecentes = ObterTransacoesRecentes();
        }

        // Propriedades para o painel
        public decimal TotalTransacoes { get; set; }
        public decimal SaldoAtual { get; set; }
        public int ClientesCadastrados { get; set; }
        public List<Transacao> TransacoesRecentes { get; set; }

        /*private List<Transacao> ObterTransacoesRecentes()
        {
            // Exemplo de dados de transações recentes
            return new List<Transacao>
            {
                new Transacao { Data = DateTime.Now.AddDays(-1), Valor = 100.00m, Status = "Completa", Remetente = "Cliente A", Destinatario = "Cliente B" },
                new Transacao { Data = DateTime.Now.AddDays(-2), Valor = 200.50m, Status = "Pendente", Remetente = "Cliente C", Destinatario = "Cliente D" },
                new Transacao { Data = DateTime.Now.AddDays(-3), Valor = 150.00m, Status = "Completa", Remetente = "Cliente E", Destinatario = "Cliente F" },
                new Transacao { Data = DateTime.Now.AddDays(-4), Valor = 300.00m, Status = "Cancelada", Remetente = "Cliente G", Destinatario = "Cliente H" },
                new Transacao { Data = DateTime.Now.AddDays(-5), Valor = 250.00m, Status = "Completa", Remetente = "Cliente I", Destinatario = "Cliente J" }
            };
        }*/
    }

    public class Transacao
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
        public string Remetente { get; set; }
        public string Destinatario { get; set; }
    }
}
