using Microsoft.EntityFrameworkCore;
using S00250043_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
namespace S00250043_ConsoleApp
{
	public class ConsoleEcommerceContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderData> OrderData { get; set; }
		public ConsoleEcommerceContext(
	 DbContextOptions<ConsoleEcommerceContext> options)
	 : base(options) { }
		// Parameterless constructor for Console
		public ConsoleEcommerceContext() { }
		protected override void OnConfiguring(
			DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(
					@"Server=(localdb)\mssqllocaldb;
	                  Database=StudentDB2024;
	                  Trusted_Connection=True;");
			}
		}
		protected override void OnModelCreating(
	ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Category>()
        .HasKey(c => new { c.Category_id});
            modelBuilder.Entity<Order>()
        .HasKey(o => new { o.Order_id });
            modelBuilder.Entity<OrderData>()
        .HasKey(o => new { o.Order_item_id });
            modelBuilder.Entity<Product>()
        .HasKey(p => new { p.Collectible_id });
            modelBuilder.Entity<User>()
        .HasKey(u => new { u.User_id });
            // SEED DATA
            //USERS
            modelBuilder.Entity<User>().HasData(
				new User
				{
					User_id = 1,
					Name = "Alice Carter",
					Email = "alice@example.com",
					Role = "Customer"
                },
                
                new User
                {
                    User_id = 2,
                    Name = "Bob Nguyen",
                    Email = "bob@example.com",
                    Role = "Customer"
                }
                );

            //CATEGORIES
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Category_id = 1,
                    Name = "Trading Cards"

                },

                new Category
                {
                    Category_id = 2,
                    Name = "Action Figures"
                }
                );

            //PRODUCTS
            modelBuilder.Entity<Product>().HasData(
                

                new Product
                {
                    Collectible_id = 1,
                    Name = "Pikachu Holo Card",
                    Category_id = 1,
                    Price = 120,
                    Condition = "Mint",
                    Stock_quantity = 5
                },
                new Product
                {
                    Collectible_id = 2,
                    Name = "Batman Figure",
                    Category_id = 2,
                    Price = 80,
                    Condition = "Good",
                    Stock_quantity = 3

                },
                new Product
                {
                    Collectible_id = 3,
                    Name = "Yoda Figure",
                    Category_id = 2,
                    Price = 95.50,
                    Condition = "Near Mint",
                    Stock_quantity = 2
                }
                );

            //ORDERS
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                  Order_id = 101,
                  User_id = 1,
                  Total_price = 120,
                  Payment_status = "Paid",
                  Order_status = "Shipped"

                },

                new Order
                { 
                  Order_id = 102,
                  User_id = 2,
                  Total_price = 175.50,
                  Payment_status = "Pending",
                  Order_status = "Processing"
                }
                );

            //ORDER ITEM DATA
            modelBuilder.Entity<OrderData>().HasData(
                new OrderData
                {
                   Order_item_id = 1,
                   Order_id = 101,
                   Collectible_id = 1,
                   Quantity = 1,
                   Unit_price = 120
                },

                new OrderData
                {
                    Order_item_id = 2,
                    Order_id = 102,
                    Collectible_id = 2,
                    Quantity = 1,
                    Unit_price = 80
                },
                
                new OrderData
                {
                    Order_item_id = 3,
                    Order_id = 102,
                    Collectible_id = 3,
                    Quantity = 1,
                    Unit_price = 95.50
                }
                );




        }
	}
}
