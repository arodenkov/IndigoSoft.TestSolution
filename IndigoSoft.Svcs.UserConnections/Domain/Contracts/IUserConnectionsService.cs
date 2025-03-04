// <copyright file="IUserConnectionsService.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

namespace IndigoSoft.Svcs.UserConnections.Domain.Contracts
{
    public interface IUserConnectionsService
    {
        /// <summary>
        /// Add user connection data.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="ipAddress">User IP address.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddConnectionAsync(long userId, string ipAddress);

        /// <summary>
        /// Find users by IP address's part.
        /// </summary>
        /// <param name="ipPart">IP address part.</param>
        /// <returns>List of users ids.</returns>
        Task<List<long>> FindUsersByIPAsync(string ipPart);

        /// <summary>
        /// Gets user's all IP addresses.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>List of user's IPs.</returns>
        Task<List<string>> GetUserIPsAsync(long userId);

        /// <summary>
        /// Search datetime and IP of users's last connection.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>Set of datetimes and IPs.</returns>
        Task<(DateTime?, string?)> GetLastConnectionAsync(long userId);
    }
}
