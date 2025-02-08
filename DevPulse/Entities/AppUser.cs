namespace DevPulse.Entities
{
    public class AppUser
    {
        // id is the primary key by convention
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string LastName { get; set; }
    }
}