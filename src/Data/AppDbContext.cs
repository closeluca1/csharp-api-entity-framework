using Entities.Studant;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : DbContext
{
    public DbSet<Studant> Stutants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "Data Source=src/Data/Versions/DataBase.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}