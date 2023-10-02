namespace CompanyApp.Data.Entities
{
    public class County
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<Personel>? Personel { get; set; } = new List<Personel>();

    }
}
