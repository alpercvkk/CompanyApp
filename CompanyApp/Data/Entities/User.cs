namespace CompanyApp.Data.Entities
{
    public class User
    {
        public string Id { get; init; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}
