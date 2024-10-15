using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace APIPix.Services
{
    public class BancoInterService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly List<Transaction> _transactions; // Lista para armazenar transações em memória (pode ser substituída por um banco de dados)

        public BancoInterService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _transactions = new List<Transaction>(); // Inicializa a lista de transações
        }

        public async Task<string> ObterTokenAsync()
        {
            var clientId = _configuration["BancoInter:ClientID"];
            var clientSecret = _configuration["BancoInter:ClientSecret"];

            var request = new HttpRequestMessage(HttpMethod.Post, "auth/oauth/v2/token")
            {
                Content = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret)
                })
            };

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var tokenResult = JsonConvert.DeserializeObject<TokenResponse>(responseContent);
                return tokenResult.AccessToken;
            }

            throw new Exception("Falha ao obter token.");
        }

        // Método para adicionar uma transação
        public void AddTransaction(Transaction transaction)
        {
            transaction.Id = _transactions.Count + 1; // Simplesmente atribuindo um ID incremental
            _transactions.Add(transaction);
        }

        // Método para obter todas as transações
        public List<Transaction> GetTransactions()
        {
            return _transactions;
        }
    }

    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }

    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
    }
}
