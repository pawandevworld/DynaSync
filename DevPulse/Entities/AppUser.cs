namespace DevPulse.Entities
{
    public class AppUser
    {
        // id is the primary key by convention
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string LastName { get; set; }
        public required string FirstName { get; set; }

        //Adding this property creates an error in the AccountController
        public required string KnownAs { get; set; }

        public byte[] PasswordHash { get; set; } = [];
        public byte[] PasswordSalt { get; set; } = [];

        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;

        public List<Job> Jobs { get; set; } = [];
               
    }
}