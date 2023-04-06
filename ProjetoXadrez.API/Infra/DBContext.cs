using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetoXadrez.API.Domain;

namespace ProjetoXadrez.API.Infra;

public class DBContext : DbContext
{
    protected readonly IConfiguration _configuration;
    public DbSet<Jogo> Jogos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Jogo>().Property(prop=>prop.IsFinished).IsRequired().HasColumnType("BIT");
        modelBuilder.Entity<Jogo>().Property(prop=>prop.IsWhiteTurn).IsRequired().HasColumnType("BIT");
        modelBuilder.Entity<Jogo>()
            .Property(e => e.MoveHistory)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        modelBuilder.Entity<Jogo>().HasKey(prop=>prop.id);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        options.UseSqlServer(_configuration.GetConnectionString("xadrez"));
    }
    public DBContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
}

