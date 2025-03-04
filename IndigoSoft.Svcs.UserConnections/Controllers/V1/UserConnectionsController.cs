// <copyright file="UserConnectionsController.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

namespace IndigoSoft.Svcs.UserConnections.Controllers.V1
{
    using IndigoSoft.Svcs.UserConnections.Domain.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserConnectionsController : ControllerBase
    {
        private readonly ILogger<UserConnectionsController> logger;
        private readonly IUserConnectionsService service;

        public UserConnectionsController(IUserConnectionsService service, ILogger<UserConnectionsController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [MapToApiVersion("1.0")]
        [HttpPut("AddConnection")]
        [SwaggerOperation(Tags = new[] { "AddConnection" })]
        public async Task AddConnectionAsync(long userId, string ipAddress) => await this.service.AddConnectionAsync(userId, ipAddress);

        [MapToApiVersion("1.0")]
        [HttpGet("FindUsersByIP")]
        [SwaggerOperation(Tags = new[] { "FindUsersByIP" })]
        public async Task<List<long>> FindUsersByIPAsync(string ipPart) => await this.service.FindUsersByIPAsync(ipPart);

        [MapToApiVersion("1.0")]
        [HttpGet("GetUserIPs")]
        [SwaggerOperation(Tags = new[] { "GetUserIPs" })]
        public async Task<List<string>> GetUserIPsAsync(long userId) => await this.service.GetUserIPsAsync(userId);

        [MapToApiVersion("1.0")]
        [HttpGet("GetLastConnection")]
        [SwaggerOperation(Tags = new[] { "GetLastConnection" })]
        public async Task<(DateTime?, string?)> GetLastConnectionAsync(long userId) => await this.service.GetLastConnectionAsync(userId);

    }
}
