// <copyright file="UserIPConnection.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

namespace IndigoSoft.Core.Data.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class UserIPConnection
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IPAddressId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IPAddress IPAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ConnectionTime { get; set; }
    }
}
