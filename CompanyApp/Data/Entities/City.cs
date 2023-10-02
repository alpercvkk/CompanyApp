namespace CompanyApp.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<County> Counties { get; set; } = new List<County>();
        public List<Personel>? Personel { get; set; } = new List<Personel>();
    }
}
