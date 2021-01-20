using Sefd.MarsRover.Common.Concretes;
using Sefd.MarsRover.Common.Consts.Enums;
using Sefd.MarsRover.Common.Helpers;
using System;
using System.Collections.Generic;

namespace Sefd.MarsRover.Common.Abstracts
{
    public class Rover : IRover
    {
        #region Properties
        public IRoverPosition Position { get; set; }
        public Queue<MovementCommand> MovementCommands { get; set; }
        public IPlateau Plateau { get; set; }
        #endregion

        #region Constructors
        public Rover()
        {
        }
        public Rover(IRoverPosition position, Queue<MovementCommand> movementCommands, IPlateau plateau)
        {
            Position = position;
            MovementCommands = movementCommands;
            Plateau = plateau;
        }
        #endregion

        #region Methods
        public void SetProperties(IRoverPosition position, Queue<MovementCommand> movementCommands, IPlateau plateau)
        {
            Position = position;
            MovementCommands = movementCommands;
            Plateau = plateau;
        }
        public void Move()
        {
            CheckConditionsToMove();
            Position = RoverHelper.Move(Position);
        }
        public void TurnLeft()
        {
            Position.Direction = RoverHelper.TurnLeft(Position.Direction);
        }
        public void TurnRight()
        {
            Position.Direction = RoverHelper.TurnRight(Position.Direction);
        }
        public void RunMovementCommands()
        {
            RoverHelper.RunMovementCommands(this);
        }
        public void CheckConditionsToMove()
        {
            if ((Position.X > Plateau.X || Position.X < 0) || 
                (Position.Y > Plateau.Y || Position.Y < 0))
            {
                throw new Exception("Rover cannot move! Trying to go out of the plateau.");
            }
        }
        public string GetCurrentPositionAsString(bool parenthesis = false)
        {
            return parenthesis
                ? $"{Position.X} {Position.Y}"
                :$"({Position.X}, {Position.Y})";
        }
        #endregion
    }
}
