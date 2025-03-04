// <copyright file="User.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

namespace IndigoSoft.Core.Data.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<UserIPConnection> Connections { get; set; } = new ();
    }
}
