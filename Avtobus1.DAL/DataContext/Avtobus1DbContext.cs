using Avtobus1.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avtobus1.DAL.DataContext;
public class Avtobus1DbContext : DbContext
{
    public Avtobus1DbContext(DbContextOptions<Avtobus1DbContext> options) : base(options)
    {

    }
    public DbSet<Url> Urls { get; set; }
}
