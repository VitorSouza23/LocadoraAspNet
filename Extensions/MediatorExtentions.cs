using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraAspNet.Extensions
{
    public static class MediatorExtentions
    {
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).Assembly);
        }
    }
}