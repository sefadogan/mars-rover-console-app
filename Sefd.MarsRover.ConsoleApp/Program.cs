using Microsoft.Extensions.DependencyInjection;
using Sefd.MarsRover.Common.Abstracts;
using Sefd.MarsRover.Common.Consts.Enums;
using Sefd.MarsRover.Common.DependencyInjection.MicrosoftExtension;
using Sefd.MarsRover.Common.Helpers;
using System;
using System.Collections.Generic;

namespace Sefd.MarsRover.ConsoleApp
{
    class Program
    {
        private static bool anotherRoverDecision = true;
        private static string[] splittedPositionAndDirection;
        private static string inputCommands;
        private static string inputAnotherRoverDecision;

        static void Main(string[] _)
        {
            #region Configure Dependency Injection
            var serviceProvider = DependencyInjection.Configure();
            #endregion 

            #region Get plateau cordinates
            Console.Write("Please input plateau coordinates: ");
            var inputPlateauCordinates = Console.ReadLine();

            var splittedCoordinates = PlateauHelper.SplitPlateauCoordinates(inputPlateauCordinates);

            var plateau = serviceProvider.GetService<IPlateau>();
            plateau.ProcessCoordinates(splittedCoordinates[0], splittedCoordinates[1]);
            #endregion

            #region Get rover's position, direction and command infos
            while (anotherRoverDecision)
            {
                PutLine();

                // Get rover's position and direction from user
                Console.Write("Please input rover's position and direction: ");
                var inputPositionAndDirection = Console.ReadLine();

                // Split position and direction text by space
                splittedPositionAndDirection = CommonHelper.SplitBySpace(inputPositionAndDirection);

                // Get commands from user
                Console.Write("Commands: ");
                inputCommands = Console.ReadLine();

                // Get movement commands
                Queue<MovementCommand> movementCommands = UserInputHelper.GetMovementCommandsQueueViaUserInput(inputCommands);

                // Convert splitted string inputs to int
                var convertedX = Convert.ToInt32(splittedPositionAndDirection[0]);
                var convertedY = Convert.ToInt32(splittedPositionAndDirection[1]);

                // Get rover position instance from service provider
                var directionKey = splittedPositionAndDirection[2];
                var roverPosition = serviceProvider.GetService<IRoverPosition>();
                roverPosition.SetProperties(UserInputHelper.GetRoverDirectionByKey(directionKey), convertedX, convertedY);

                // Get rover instance from service provider
                var rover = serviceProvider.GetService<IRover>();
                rover.SetProperties(roverPosition, movementCommands, plateau);

                // Add rover to the plateau
                plateau.Rovers.Add(rover);

                // Ask user that wants to add another rover to the plateau
                AskAnotherRoverForThePlateauToUser();
            }
            #endregion

            #region Run movement commands for every rover
            PutLine("Result(s):");
            foreach (var rover in plateau.Rovers)
            {
                rover.RunMovementCommands();
                Console.WriteLine($"{rover.Position.X} {rover.Position.Y} {rover.Position.Direction}");
            }
            #endregion
        }

        private static void PutLine() => Console.WriteLine();
        private static void PutLine(string text = "") => Console.WriteLine($"\n{text}");
        private static void AskAnotherRoverForThePlateauToUser()
        {
            Console.Write("\nWould you like to add another rover to the plateau? (Y/y): ");
            inputAnotherRoverDecision = Console.ReadLine();

            // If user texts Y/y, while loop will be re-run to get rover's position, direction and commands.
            anotherRoverDecision = inputAnotherRoverDecision.ToUpper().Equals("Y");
        }
    }
}
