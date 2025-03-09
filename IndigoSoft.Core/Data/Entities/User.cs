// <copyright file="User.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

namespace IndigoSoft.Core.Data.Entities
{
    /// <summary>
    /// User class.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets value of Id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets value of Connections.
        /// </summary>
        public List<UserIPConnection> Connections { get; set; } = new ();
    }
}
