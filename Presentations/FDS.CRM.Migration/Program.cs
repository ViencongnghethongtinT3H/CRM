﻿using FDS.CRM.Infrastructure.DateTimes;
using Polly;
using System.Reflection;
using FDS.CRM.Persistence;
using DbUp;
using FDS.CRM.Infrastructure.HealthChecks;
using FDS.CRM.Migration.Data;
using FDS.CRM.Infrastructure.Logging;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var services = builder.Services;
        var configuration = builder.Configuration;

        builder.WebHost.UseCRMLogger(configuration =>
        {
            return new LoggingOptions();
        });

        if (string.Equals(configuration["CheckDependency:Enabled"], "true", StringComparison.OrdinalIgnoreCase))
        {
            NetworkPortCheck.Wait(configuration["CheckDependency:Host"], 5);
        }

        services.AddDateTimeProvider();

        // Khởi tạo kết nối tới SQL server
        services.AddPersistence(configuration["ConnectionStrings:CRMDatabase"], Assembly.GetExecutingAssembly().GetName().Name);

        // Configure the HTTP request pipeline.
        var app = builder.Build();

        Policy.Handle<Exception>().WaitAndRetry(new[]
        {
            TimeSpan.FromSeconds(10),
            TimeSpan.FromSeconds(20),
            TimeSpan.FromSeconds(30),
        })
        .Execute(async () =>
        {
            // Thực hiện migrations
            app.MigrateAdsDb();

            // Thực hiện DbUp scripts (nếu cần)
            var upgrader = DeployChanges.To
            .SqlDatabase(configuration.GetConnectionString("CRMDatabase"))
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                throw result.Error;
            }

            // Seed data
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<CrmDbContext>();
                    var logger = services.GetRequiredService<ILogger<CrmDbContext>>();
                    await DbInitializer.Initialize(context, logger);
                    Console.WriteLine("Seed data completed successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
                    throw;
                }
            }
        });

        app.Run();
    }
}