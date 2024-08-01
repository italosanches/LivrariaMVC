using Microsoft.EntityFrameworkCore;
using LivrariaMVC;
using LivrariaMVC.Models;

namespace LivrariaMVC
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
          
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<LivroAutor> LivroAutores { get; set; }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<LivroGenero> LivroGeneros { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Config N-N livros Autor
            modelBuilder.Entity<LivroAutor>().HasKey
                (
                    key => new { key.LivroId, key.AutorId }
                );

            modelBuilder.Entity<LivroAutor>()
                .HasOne(la => la.Livro)
                .WithMany(l => l.LivrosAutores)
                .HasForeignKey(la => la.LivroId);

            modelBuilder.Entity<LivroAutor>()
               .HasOne(la => la.Autor)
               .WithMany(a => a.LivroAutores)
               .HasForeignKey(la => la.AutorId);

            //Config N-N livros Genero
            modelBuilder.Entity<LivroGenero>()
        .HasKey(lg => new { lg.LivroId, lg.GeneroId });

            modelBuilder.Entity<LivroGenero>()
                .HasOne(lg => lg.Livro)
                .WithMany(l => l.LivrosGeneros)
                .HasForeignKey(lg => lg.LivroId);

            modelBuilder.Entity<LivroGenero>()
                .HasOne(lg => lg.Genero)
                .WithMany(g => g.LivrosGeneros)
                .HasForeignKey(lg => lg.GeneroId);


        }
    }
}



