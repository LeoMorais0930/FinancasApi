namespace FinancasApi.DTOs
{
    public class TransactionCreateDTO
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Date { get; set; } // opcional
        public string Type { get; set; }    // Receita ou Despesa
        public string Category { get; set; }
    }

    public class TransactionReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
    }

    public class TransactionUpdateDTO
    {
        public string? Title { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }
        public string? Type { get; set; }
        public string? Category { get; set; }
    }
}
