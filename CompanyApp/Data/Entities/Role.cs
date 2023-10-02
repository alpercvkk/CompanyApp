namespace CompanyApp.Data.Entities
{
    public class Role
    {

        public string Id { get; init; }
        public string Name { get; set; }

        // Bu role tanımlanmış kişiler
        public List<User> Users { get; set; } = new List<User>(); 
        
        public Role()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
