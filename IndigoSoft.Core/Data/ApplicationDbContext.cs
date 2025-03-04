// <copyright file="ApplicationDbContext.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

namespace IndigoSoft.Core.Data
{
    using IndigoSoft.Core.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<IPAddress> IPAddresses { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<UserIPConnection> UserIPConnections { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserIPConnection>()
                .HasIndex(u => new { u.UserId, u.ConnectionTime });
        }
    }
}
