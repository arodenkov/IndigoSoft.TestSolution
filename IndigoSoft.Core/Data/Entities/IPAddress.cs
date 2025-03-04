// <copyright file="IPAddress.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

namespace IndigoSoft.Core.Data.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class IPAddress
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<UserIPConnection> Connections { get; set; } = new ();
    }
}
