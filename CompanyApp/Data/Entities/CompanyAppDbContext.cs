using Microsoft.EntityFrameworkCore;

namespace CompanyApp.Data.Entities
{
    public class CompanyAppDbContext : DbContext
    {
        public DbSet<Personel> Personels { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FAFVSUB\\MSSQLSERVER01;Database=CompanyAppDb;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().HasKey(x => x.Id);
            modelBuilder.Entity<City>().HasKey(x => x.Id);
            modelBuilder.Entity<County>().HasKey(x => x.Id);

            modelBuilder.Entity<Personel>().HasOne(x => x.Cities).WithMany(x => x.Personel).HasForeignKey(x => x.CityId);

            modelBuilder.Entity<Personel>().HasOne(x => x.Counties).WithMany(x => x.Personel).HasForeignKey(x => x.CountyId);

            modelBuilder.Entity<County>().HasOne(x => x.City).WithMany(x => x.Counties).HasForeignKey(x => x.CityId);
           

          

        }



    }
}
