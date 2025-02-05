namespace Rent_A_Moment.Dto
{
    public class RegisterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
