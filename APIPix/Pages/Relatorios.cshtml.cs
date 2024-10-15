using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPix.Pages
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
    }

    public class RelatoriosModel : PageModel
    {
        // Propriedades para armazenar as transações e os filtros
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string StatusFilter { get; set; }

        public void OnGet(DateTime? startDate, DateTime? endDate, string status)
        {
            // Armazenar os parâmetros do filtro
            StartDate = startDate;
            EndDate = endDate;
            StatusFilter = status;

            // Aqui você deve obter as transações de uma fonte de dados real (banco de dados, etc.)
            // Para fins de exemplo, vamos adicionar alguns dados fictícios:
            Transactions.Add(new Transaction
            {
                Date = DateTime.Now.AddDays(-1),
                Amount = 150.00m,
                Status = "Sucesso",
                Sender = "Usuario1",
                Receiver = "Usuario2"
            });

            Transactions.Add(new Transaction
            {
                Date = DateTime.Now.AddDays(-2),
                Amount = 75.00m,
                Status = "Pendente",
                Sender = "Usuario3",
                Receiver = "Usuario4"
            });

            Transactions.Add(new Transaction
            {
                Date = DateTime.Now.AddDays(-3),
                Amount = 200.00m,
                Status = "Falha",
                Sender = "Usuario5",
                Receiver = "Usuario6"
            });

            // Filtrar as transações com base nos parâmetros
            if (startDate.HasValue)
            {
                Transactions = Transactions.Where(t => t.Date >= startDate.Value).ToList();
            }

            if (endDate.HasValue)
            {
                Transactions = Transactions.Where(t => t.Date <= endDate.Value).ToList();
            }

            if (!string.IsNullOrEmpty(status) && status != "todos")
            {
                Transactions = Transactions.Where(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }
    }
}
