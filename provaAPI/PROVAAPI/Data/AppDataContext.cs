using Microsoft.EntityFrameworkCore;
using PROVAAPI.Models;

namespace PROVAAPI;
public class AppDataContext : DbContext
{

    public AppDataContext(DbContextOptions<AppDataContext> options):base(options){}

    public DbSet<Aluno> alunos {get; set;}
    public DbSet<Imc> imcs {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
    }
}
