using Microsoft.EntityFrameworkCore;

namespace Hw53.Models;

public class MobileContext : DbContext
{
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    public MobileContext(DbContextOptions<MobileContext> options) : base(options) { }
}