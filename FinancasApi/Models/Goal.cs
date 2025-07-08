namespace FinancasApi.Models
{
    public class Goal
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public decimal TargetAmount { get; set; }

        public decimal CurrentAmount { get; set; } = 0;

        public DateTime Deadline { get; set; }

        // Relacionamento
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
