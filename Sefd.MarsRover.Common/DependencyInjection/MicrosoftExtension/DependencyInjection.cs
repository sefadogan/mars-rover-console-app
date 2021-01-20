using Microsoft.Extensions.DependencyInjection;
using Sefd.MarsRover.Common.Abstracts;
using Sefd.MarsRover.Common.Concretes;

namespace Sefd.MarsRover.Common.DependencyInjection.MicrosoftExtension
{
    public class DependencyInjection
    {
        public static ServiceProvider Configure()
        {
            var serviceProvider = new ServiceCollection()

               .AddTransient<IPlateau, Plateau>()
               .AddTransient<IRover, Rover>()
               .AddTransient<IRoverPosition, RoverPosition>()

               .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
