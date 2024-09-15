namespace MessengerApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

        public ICollection<Message>? Messages { get; set; }
        public ICollection<UserChat>? UserChats { get; set; }
    }
}
