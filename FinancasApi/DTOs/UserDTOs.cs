namespace FinancasApi.DTOs
{
    public class UserCreateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

    }

    public class UserReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }

    public class UserUpdateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

}
