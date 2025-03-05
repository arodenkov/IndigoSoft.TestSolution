using IndigoSoft.Core.Data;
using IndigoSoft.Core.Domain.Contracts;
using IndigoSoft.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace IndigoSoft.Tests.UserConnections
{
    public class Tests
    {
        private ApplicationDbContext context;
        private IUserConnectionsService service;

        [SetUp]
        public void Setup()
        {
            this.context = new ApplicationDbContext();
            this.service = new UserConnectionsService(this.context);
        }

        [TearDown]
        public void Complete()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        [Test]
        public async Task AddConnectionAsync_ShouldAddConnection()
        {
            await this.service.AddConnectionAsync(100001, "127.0.0.1");
            var connections = await this.context.UserIPConnections.ToListAsync();
            Assert.That(connections.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task FindUsersByIPAsync_ShouldReturnUsers()
        {
            await this.service.AddConnectionAsync(100001, "31.214.157.141");
            await this.service.AddConnectionAsync(100002, "31.214.200.100");

            var users = await this.service.FindUsersByIPAsync("31.214");
            Assert.That(users.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetUserIPsAsync_ShouldReturnIPs()
        {
            await this.service.AddConnectionAsync(100001, "127.0.0.1");
            await this.service.AddConnectionAsync(100001, "192.168.1.1");

            var ips = await this.service.GetUserIPsAsync(100001);
            Assert.That(ips.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetLastConnectionAsync_ShouldReturnLastConnection()
        {
            await this.service.AddConnectionAsync(100001, "127.0.0.1");
            await this.service.AddConnectionAsync(100001, "192.168.1.1");

            var (time, ip) = await this.service.GetLastConnectionAsync(100001);
            Assert.That(ip, Is.EqualTo("192.168.1.1"));
        }
    }
}