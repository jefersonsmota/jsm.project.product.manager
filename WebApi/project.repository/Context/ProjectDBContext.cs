using Microsoft.EntityFrameworkCore;
using project.domain.Entities;
using project.repository.Configuration;
using System.Configuration;

namespace project.repository.Context
{
    public partial class ProjectDBContext : DbContext
    {
        public ProjectDBContext()
        {

        }

        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=sitemercadodb; user id=sa; password=L.M!jk5G@wQCn\\M5");
        //        //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        //    }
        //}

        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
