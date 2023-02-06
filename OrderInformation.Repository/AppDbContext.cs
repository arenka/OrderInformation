using Microsoft.EntityFrameworkCore;
using OrderInformation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<OrderInfo> OrderInfos { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }



        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.Entity)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }


            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;

                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }


            }

            return await base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // mevcut çalıştığım assblyde uygular.

            modelBuilder.Entity<OrderStatus>().HasData(
              new OrderStatus { Id = 1, CreatedDate = DateTime.Now, Name = "Sipariş Alındı" },
              new OrderStatus { Id = 2, CreatedDate = DateTime.Now, Name = "Yola Çıktı" },
              new OrderStatus { Id = 3, CreatedDate = DateTime.Now, Name = "Dağıtım Merkezinde" },
              new OrderStatus { Id = 4, CreatedDate = DateTime.Now, Name = "Dağıtıma Çıktı" },
              new OrderStatus { Id = 5, CreatedDate = DateTime.Now, Name = "Teslim Edildi" },
              new OrderStatus { Id = 6, CreatedDate = DateTime.Now, Name = "Teslim Edilemedi" }
             );


            modelBuilder.Entity<Material>().HasData(
             new Material { Id = 1, CreatedDate = DateTime.Now, Code = "KLM001", Name = "Kurşun Kalem" },
             new Material { Id = 2, CreatedDate = DateTime.Now, Code = "KLM002", Name = "Tükenmez Kalem" }
            );



            base.OnModelCreating(modelBuilder);
        }
    }
}