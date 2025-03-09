// <copyright file="ApplicationDbContext.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

namespace IndigoSoft.Core.Data
{
    using IndigoSoft.Core.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Application DB context class.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets users dataset.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets user IP addresses dataset.
        /// </summary>
        public DbSet<IPAddress> IPAddresses { get; set; }

        /// <summary>
        /// Gets or sets UserIPConnections dataset.
        /// </summary>
        public DbSet<UserIPConnection> UserIPConnections { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserIPConnection>()
                .HasIndex(u => new { u.UserId, u.ConnectionTime });

            modelBuilder.Entity<IPAddress>()
                .HasIndex(a => a.TsvAddress)
                .HasMethod("GIN");
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}