
namespace CodeGeneratorApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool PaymentDone { get; set; } = false;
    }
}
