using Microsoft.EntityFrameworkCore;
using ProducerServices.Entities;

namespace ProducerServices.Data
{
    public class OrderRequestDbContext: DbContext
    {
        public OrderRequestDbContext(DbContextOptions<OrderRequestDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name= "Pankaj",
                    Address="Electronic City, Bangalore"
                    ,Pincode="560100"
                }              
                );

            modelBuilder.Entity<Customer>().HasData(
             new Customer
             {
                 Id = 4,
                 Name = "Pankaj",
                 Address = "Electronic City, Bangalore"
                 ,
                 Pincode = "560100"
             }
             );

            modelBuilder.Entity<Customer>().HasData(
             new Customer
             {
                 Id = 2,
                 Name = "Alok",
                 Address = "HSR, Bangalore"
                 ,
                 Pincode = "560089"
             }
             );

            modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 3,
                Name = "Harshita",
                Address = "HSR, Bangalore"
                ,
                Pincode = "560088"
            }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Perfumes"
            });

            modelBuilder.Entity<Product>().HasData(
          new Product
          {
              Id = 2,
              Name = "Jeans Pants"
          });

            modelBuilder.Entity<Product>().HasData(
             new Product
             {
                 Id = 3,
                 Name = "Woman Suits"
             });

            //OrderRequest

            modelBuilder.Entity<OrderRequest>().HasData(
            new OrderRequest
            {
                OrderId = 1,
                ProductId=3,
                CustomerId=1,
                Quantity=34,
                Status="Delayed"
            });

            modelBuilder.Entity<OrderRequest>().HasData(
            new OrderRequest
            {
                OrderId = 3,
                ProductId = 2,
                CustomerId = 2,
                Quantity = 34,
                Status = "Delayed"
            });

            modelBuilder.Entity<OrderRequest>().HasData(
            new OrderRequest
            {
                OrderId = 4,
                ProductId = 2,
                CustomerId = 4,
                Quantity = 24,
                Status = "Delayed"
            });

            modelBuilder.Entity<OrderRequest>().HasData(
          new OrderRequest
          {
              OrderId = 2,
              ProductId = 2,
              CustomerId = 3,
              Quantity = 24,
              Status = "Delayed"
          });

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<OrderRequest> OrderRequests { get; set; }

    }
}
