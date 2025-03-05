// <copyright file="UserConnectionsService.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

namespace IndigoSoft.Core.Services
{
    using IndigoSoft.Core.Data;
    using IndigoSoft.Core.Data.Entities;
    using IndigoSoft.Core.Domain.Contracts;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    public class UserConnectionsService : IUserConnectionsService
    {

        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserConnectionsService"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public UserConnectionsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task AddConnectionAsync(long userId, string ipAddress)
        {
            var ip = await this.context.IPAddresses.FirstOrDefaultAsync(x => x.Address == ipAddress);
            if (ip == null)
            {
                ip = new IPAddress { Address = ipAddress };
                this.context.IPAddresses.Add(ip);
                await this.context.SaveChangesAsync();
            }

            var connection = new UserIPConnection
            {
                UserId = userId,
                IPAddressId = ip.Id,
                ConnectionTime = DateTime.UtcNow,
            };

            this.context.UserIPConnections.Add(connection);
            await this.context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<List<long>> FindUsersByIPAsync(string ipPart)
        {
            return await this.context.UserIPConnections
                .Include(x => x.IPAddress)
                .Where(x => x.IPAddress.TsvAddress.Matches(ipPart))
                .Select(x => x.UserId)
                .Distinct()
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<List<string>> GetUserIPsAsync(long userId)
        {
            return await this.context.UserIPConnections
                .Include(x => x.IPAddress)
                .Where(x => x.UserId == userId)
                .Select(x => x.IPAddress.Address)
                .Distinct()
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<(DateTime?, string?)> GetLastConnectionAsync(long userId)
        {
            var lastConnection = await this.context.UserIPConnections
                .Include(x => x.IPAddress)
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.ConnectionTime)
                .FirstOrDefaultAsync();

            return (lastConnection?.ConnectionTime, lastConnection?.IPAddress?.Address);
        }
    }
}
