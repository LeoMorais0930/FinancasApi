namespace FinancasApi.DTOs
{
    public class GoalCreateDTO
    {
        public string? Description { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime Deadline { get; set; }
    }

    public class GoalReadDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime Deadline { get; set; }
    }

    public class GoalUpdateDTO
    {
        public string? Description { get; set; }
        public decimal? TargetAmount { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
