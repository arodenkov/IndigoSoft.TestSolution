// <copyright file="UserIPConnection.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

namespace IndigoSoft.Core.Data.Entities
{
    /// <summary>
    /// UserIPConnection class.
    /// </summary>
    public class UserIPConnection
    {
        /// <summary>
        /// Gets or sets value of Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets value of UserId.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets value of User.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets value of IPAddressId.
        /// </summary>
        public int IPAddressId { get; set; }

        /// <summary>
        /// Gets or sets value of IPAddress.
        /// </summary>
        public IPAddress? IPAddress { get; set; }

        /// <summary>
        /// Gets or sets value of ConnectionTime.
        /// </summary>
        public DateTime ConnectionTime { get; set; }
    }
}