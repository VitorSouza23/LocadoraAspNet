using System.Linq;
using LocadoraAspNet.InfraData.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAspNet.Extensions
{
    public static class DbExtensions
    {
        public static void DoMigrations(this IApplicationBuilder app, DataContext dataContext)
        {
            var pendingMigrations = dataContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                dataContext.Database.Migrate();
            }
        }
    }
}