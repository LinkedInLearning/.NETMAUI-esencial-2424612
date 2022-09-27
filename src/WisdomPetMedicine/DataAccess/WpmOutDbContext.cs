using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisdomPetMedicine.Services;

namespace WisdomPetMedicine.DataAccess;
public class WpmOutDbContext : DbContext
{
    private readonly IDatabasePathService databasePathService;

    public DbSet<SaleItem> Sales { get; set; }

    public WpmOutDbContext(IDatabasePathService databasePathService)
    {
        this.databasePathService = databasePathService;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = $"Filename={databasePathService.Get("wpm.db")}";
        optionsBuilder.UseSqlite(connectionString);
    }
}

public record SaleItem(int ClientId, 
    int ProductId, int Quantity, decimal Price)
{
    public int Id { get; set; }
}