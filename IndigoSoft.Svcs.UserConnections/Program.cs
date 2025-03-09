// <copyright file="Program.cs" company="IndigoSoft">
// Copyright © 2025 IndigoSoft
// </copyright>

using IndigoSoft.Svcs.UserConnections;

/// <summary>
/// Program class.
/// </summary>
public static class Program
{
    /// <summary>
    /// Entrance method.
    /// </summary>
    /// <param name="args">Program launch arguments.</param>
    public static void Main(string[] args)
    {
        try
        {
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            // ToDo: NLog catch setup errors.
            throw;
        }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit.
            //NLog.LogManager.Shutdown();
        }
    }

    /// <summary>
    /// CreateHostBuilder method.
    /// </summary>
    /// <param name="args">List of arguments.</param>
    /// <returns>Host builder entity.</returns>
    public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
                   webBuilder.ConfigureKestrel(serverOptions => serverOptions.AddServerHeader = false);
               })
               .ConfigureLogging(logging =>
               {
                   logging.ClearProviders();

                   // This is required to see message at level below Info.
                   // See https://github.com/NLog/NLog.Web/issues/167.
                   // See also https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-3.
                   logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
               });
}