namespace FinancasApi.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; } // "Receita" ou "Despesa"

        public string Category { get; set; }

        // Relacionamento
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
