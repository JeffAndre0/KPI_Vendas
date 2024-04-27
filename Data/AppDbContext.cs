
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Back.Data {
    public class AppDbContext : DbContext {
        private readonly IConfiguration _configuration;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
        : base(options){
        _configuration = configuration;
    }
        public DbSet<MultiStore> MultiStore { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }

        public void DeleteAllMultistore()
    {
        MultiStore.RemoveRange(MultiStore);
        SaveChanges();
    }

    }
}