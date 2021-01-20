using System;
using Sefd.MarsRover.Common.Abstracts;
using Sefd.MarsRover.Common.Consts.Enums;

namespace Sefd.MarsRover.Common.Helpers
{
    public class RoverHelper
    {
        /// <summary>
        /// Runs movement commands
        /// </summary>
        /// <param name="rover"></param>
        public static void RunMovementCommands(IRover rover)
        {
            while (rover.MovementCommands.Count > 0)
            {
                MovementCommand movementCommand = rover.MovementCommands.Dequeue();
                switch (movementCommand)
                {
                    case MovementCommand.M:
                        rover.Move();
                        break;

                    case MovementCommand.L:
                        rover.TurnLeft();
                        break;

                    case MovementCommand.R:
                        rover.TurnRight();
                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// Moves to keep the direction
        /// </summary>
        /// <param name="roverPosition"></param>
        /// <returns></returns>
        public static IRoverPosition Move(IRoverPosition roverPosition)
        {
            switch (roverPosition.Direction)
            {
                case RoverDirection.N:
                    roverPosition.Y++;
                    break;

                case RoverDirection.S:
                    roverPosition.Y--;
                    break;

                case RoverDirection.W:
                    roverPosition.X--;
                    break;

                case RoverDirection.E:
                    roverPosition.X++;
                    break;

                default:
                    throw new InvalidOperationException();
            }

            return roverPosition;
        }

        /// <summary>
        /// Turns right to keep the (x, y)
        /// </summary>
        /// <param name="roverDirection"></param>
        public static RoverDirection TurnRight(RoverDirection roverDirection)
        {
            RoverDirection currentRoverDirection;

            switch (roverDirection)
            {
                case RoverDirection.N:
                    currentRoverDirection = RoverDirection.E;
                    break;

                case RoverDirection.E:
                    currentRoverDirection = RoverDirection.S;
                    break;

                case RoverDirection.S:
                    currentRoverDirection = RoverDirection.W;
                    break;

                case RoverDirection.W:
                    currentRoverDirection = RoverDirection.N;
                    break;

                default:
                    throw new InvalidOperationException();
            }

            return currentRoverDirection;
        }

        /// <summary>
        /// Turns left to keep the (x, y)
        /// </summary>
        /// <param name="roverDirection"></param>
        public static RoverDirection TurnLeft(RoverDirection roverDirection)
        {
            RoverDirection currentRoverDirection;

            switch (roverDirection)
            {
                case RoverDirection.N:
                    currentRoverDirection = RoverDirection.W;
                    break;

                case RoverDirection.E:
                    currentRoverDirection = RoverDirection.N;
                    break;

                case RoverDirection.S:
                    currentRoverDirection = RoverDirection.E;
                    break;

                case RoverDirection.W:
                    currentRoverDirection = RoverDirection.S;
                    break;

                default:
                    throw new InvalidOperationException();
            }

            return currentRoverDirection;
        }
    }
}
