using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisdomPetMedicine.DataAccess;
public class WpmOutDbContext : DbContext
{
    public DbSet<SaleItem> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}

public record SaleItem(int ClientId, 
    int ProductId, int Quantity, decimal Price);