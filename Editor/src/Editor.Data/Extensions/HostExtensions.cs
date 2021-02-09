using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Data.Common;

namespace Editor.Data
{
    public static class HostExtensions
    {
        public static IHost MigrateDbContext<TContext>(this IHost host)
            where TContext : DbContext
        {
            using var scope = host.Services.CreateScope();
            var sp = scope.ServiceProvider;

            var logger = sp.GetRequiredService<ILogger<TContext>>();
            var context = sp.GetService<TContext>();

            try
            {
                logger.LogInformation("Migrating database associated with {Context}", typeof(TContext).Name);

                var retry = Policy.Handle<DbException>()
                                  .WaitAndRetry(new[]
                                  {
                                      TimeSpan.FromSeconds(5),
                                      TimeSpan.FromSeconds(10),
                                      TimeSpan.FromSeconds(15),
                                  });

                retry.Execute(() => context.Database.Migrate());

                logger.LogInformation("Migrated database associated with {Context}", typeof(TContext).Name);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex, "An error occurred while migrating the database used on {Context}", typeof(TContext).Name);
            }
            finally
            {
                context?.Dispose();
            }

            return host;
        }
    }
}