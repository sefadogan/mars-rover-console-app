using Sefd.MarsRover.Common.Consts.Enums;
using System;
using System.Collections.Generic;

namespace Sefd.MarsRover.Common.Helpers
{
    public class UserInputHelper
    {
        /// <summary>
        /// Returns movement commands via user input
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public static Queue<MovementCommand> GetMovementCommandsQueueViaUserInput(string userInput)
        {
            if (string.IsNullOrEmpty(userInput)) throw null;

            Queue<MovementCommand> movementCommands = new Queue<MovementCommand>();
            foreach (var charItem in userInput)
            {
                var movementCommand = GetMovementCommandByKey(charItem.ToString());
                movementCommands.Enqueue(movementCommand);
            }

            return movementCommands;
        }

        /// <summary>
        /// Returns movement command by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static MovementCommand GetMovementCommandByKey(string key)
        {
            switch (key.ToUpper())
            {
                case nameof(MovementCommand.M):
                    return MovementCommand.M;

                case nameof(MovementCommand.L):
                    return MovementCommand.L;

                case nameof(MovementCommand.R):
                    return MovementCommand.R;

                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Returns rover direction by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static RoverDirection GetRoverDirectionByKey(string key)
        {
            switch (key.ToUpper())
            {
                case nameof(RoverDirection.N):
                    return RoverDirection.N;

                case nameof(RoverDirection.E):
                    return RoverDirection.E;

                case nameof(RoverDirection.S):
                    return RoverDirection.S;

                case nameof(RoverDirection.W):
                    return RoverDirection.W;

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
