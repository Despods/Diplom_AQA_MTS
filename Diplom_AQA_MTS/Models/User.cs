namespace Diplom_AQA_MTS.Models
{
    public record User
    {
        public string Username { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public UserType UserType { get; set; } = UserType.Admin;
    }
}
