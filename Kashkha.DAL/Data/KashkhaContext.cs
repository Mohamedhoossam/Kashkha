﻿using Kashkha.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class KashkhaContext:IdentityDbContext<User>
	{
        public KashkhaContext(DbContextOptions options):base(options)
        {
    
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>(builder =>
			{
				builder.Property(o => o.OrderStatus)
				.HasConversion(OStatus => OStatus.ToString(), OStutus => (OrderStatus)Enum.Parse(typeof(OrderStatus), OStutus));
				builder.Property(o => o.PaymentStatus)
				.HasConversion(OStatus => OStatus.ToString(), OStutus => (PaymentStatus)Enum.Parse(typeof(PaymentStatus), OStutus));

				builder.OwnsOne(o => o.OrderAddress, SA => SA.WithOwner()); //[1:1]
				builder.Property(o => o.TotalPrice).
				HasColumnType("decimal(18,2)");


				//shop owner
				modelBuilder.Entity<Product>()
            .HasOne(p => p.ShopOwner)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.ShopOwnerId);

				modelBuilder.Entity<Order>()
				.HasOne(o => o.ShopOwner)
				.WithMany(s => s.Orders)
            .HasForeignKey(o => o.ShopOwnerId);

			});

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Product> products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<ShopOwner> ShopOwners { get; set; }
	}
}
