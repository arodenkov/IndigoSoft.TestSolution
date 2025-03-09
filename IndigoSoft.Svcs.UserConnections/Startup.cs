// <copyright file="Startup.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

namespace IndigoSoft.Svcs.UserConnections
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Gets value of Configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">Configuration object.</param>
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        /// <summary>
        /// Configure services method.
        /// </summary>
        /// <param name="services">Services collection instance.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<DbContext>(options =>
                options.UseNpgsql(this.Configuration.GetConnectionString("DefaultConnection")));
        }

        /// <summary>
        /// Configure app method.
        /// </summary>
        /// <param name="app">Applicatopn builder instance.></param>
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            app.UseHsts();
            app.UseHttpsRedirection();
        }
    }
}
