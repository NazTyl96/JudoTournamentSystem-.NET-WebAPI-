using Microsoft.EntityFrameworkCore;
using JTS.Models;

namespace JTS.Data;

public class Context : DbContext
{
    public Context (DbContextOptions<Context> options)
        : base(options)
    {
    }

    public DbSet<Tournament> Tournaments => Set<Tournament>();
    public DbSet<Competitor> Competitors => Set<Competitor>();
}