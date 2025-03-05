// <copyright file="IPAddress.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

namespace IndigoSoft.Core.Data.Entities
{
    using NpgsqlTypes;

    /// <summary>
    /// 
    /// </summary>
    public class IPAddress
    {
        private string address = string.Empty;

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
        public NpgsqlTsVector TsvAddress { get; }

        /// <summary>
        /// 
        /// </summary>
        public List<UserIPConnection> Connections { get; set; } = new ();
    }
}
