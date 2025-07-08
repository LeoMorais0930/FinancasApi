namespace FinancasApi.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        // Relacionamentos
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    }
}
