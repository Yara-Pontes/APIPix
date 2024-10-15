using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace APIPix.Pages
{
    public class TransactionLog
    {
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
    }

    public class ErrorLog
    {
        public DateTime DateTime { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }

    public class LogsModel : PageModel
    {
        public List<TransactionLog> RecentTransactions { get; set; } = new List<TransactionLog>();
        public List<ErrorLog> RecentErrors { get; set; } = new List<ErrorLog>();

        public void OnGet()
        {
            // Aqui você deve preencher as listas RecentTransactions e RecentErrors com dados reais.
            // Para fins de exemplo, vamos adicionar alguns dados fictícios:

            RecentTransactions.Add(new TransactionLog
            {
                DateTime = DateTime.Now,
                Amount = 150.00m,
                Status = "Completo",
                Sender = "Usuario1",
                Receiver = "Usuario2"
            });

            RecentErrors.Add(new ErrorLog
            {
                DateTime = DateTime.Now,
                ErrorCode = "404",
                Message = "Recurso não encontrado"
            });
        }
    }
}
