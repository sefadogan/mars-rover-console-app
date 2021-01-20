using Microsoft.Extensions.DependencyInjection;
using Sefd.MarsRover.Common.Abstracts;
using Sefd.MarsRover.Common.Concretes;
using Sefd.MarsRover.Common.Consts.Enums;
using System.Collections.Generic;

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

            //IServiceCollection services = new ServiceCollection();

            //services.AddTransient<IPlateau, Plateau>();
            ////services.AddTransient<IPlateauGrid, PlateauGrid>();

            ////services.AddTransient<ICommand, TurnLeftCommand>();
            ////services.AddTransient<ICommand, TurnRightCommand>();
            ////services.AddTransient<ICommand, MoveCommand>();
            ////services.AddTransient<IRoverCommandManager, RoverCommandManager>();
            ////services.AddTransient<IRoverPosition, RoverPosition>();
            ////services.AddTransient<IRover, Rover>();
            ////services.AddTransient<IPlateauGrid, PlateauGrid>();

            //return services.BuildServiceProvider();
        }
    }
}
