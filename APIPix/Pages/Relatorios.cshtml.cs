using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace APIPix.Pages
{
    public class RelatoriosModel : PageModel
    {
        public decimal TotalTransacoes { get; set; }
        public List<Transacao> TransacoesRecentes { get; set; }

        public void OnGet()
        {
            // Total de transações fixo
            TotalTransacoes = 1000.00m;
            TransacoesRecentes = GetTransacoes(); // Obter transações fictícias
        }

        private List<Transacao> GetTransacoes()
        {
            // Dados fictícios de transações
            return new List<Transacao>
            {
                /*new Transacao { Data = new DateTime(2024, 1, 1), Valor = 100.00m, Status = "Concluída", Remetente = "Cliente A", Destinatario = "Cliente B" },
                new Transacao { Data = new DateTime(2024, 1, 2), Valor = 200.00m, Status = "Pendente", Remetente = "Cliente C", Destinatario = "Cliente D" },
                new Transacao { Data = new DateTime(2024, 1, 3), Valor = 150.00m, Status = "Concluída", Remetente = "Cliente E", Destinatario = "Cliente F" },
                new Transacao { Data = new DateTime(2024, 1, 4), Valor = 300.00m, Status = "Cancelada", Remetente = "Cliente G", Destinatario = "Cliente H" },
                new Transacao { Data = new DateTime(2024, 1, 5), Valor = 250.00m, Status = "Concluída", Remetente = "Cliente I", Destinatario = "Cliente J" }*/
            };
        }
    }

    /*public class Transacao
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
        public string Remetente { get; set; }
        public string Destinatario { get; set; }
    }*/
}
