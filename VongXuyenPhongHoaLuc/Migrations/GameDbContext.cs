using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VongXuyenPhongHoaLuc.Models;

public class GameDbContext : DbContext
{
    public GameDbContext(DbContextOptions<GameDbContext> options)
        : base(options) { }

    public DbSet<Hero> Heroes { get; set; }
    public DbSet<ArenaRank> ArenaRank { get; set; }

}
