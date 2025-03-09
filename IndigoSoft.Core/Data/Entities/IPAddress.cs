// <copyright file="IPAddress.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

namespace IndigoSoft.Core.Data.Entities
{
    using NpgsqlTypes;

    /// <summary>
    /// IPAddress class.
    /// </summary>
    public class IPAddress
    {
        private string address = string.Empty;

        /// <summary>
        /// Gets or sets value of Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets value of Address.
        /// </summary>
        required public string Address { get; set; }

        /// <summary>
        /// Gets value of TsvAddress.
        /// </summary>
        public NpgsqlTsVector? TsvAddress { get; }

        /// <summary>
        /// Gets or sets value of Connections.
        /// </summary>
        public List<UserIPConnection> Connections { get; set; } = new ();
    }
}
