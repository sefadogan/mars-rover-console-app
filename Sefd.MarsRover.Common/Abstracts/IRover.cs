using Sefd.MarsRover.Common.Consts.Enums;
using System.Collections.Generic;

namespace Sefd.MarsRover.Common.Abstracts
{
    public interface IRover : ITurnableLeft, ITurnableRight, IMovableForward
    {
        #region Properties
        IRoverPosition Position { get; set; }
        Queue<MovementCommand> MovementCommands { get; set; }
        IPlateau Plateau { get; set; }
        #endregion

        #region Methods
        void SetProperties(IRoverPosition position, Queue<MovementCommand> movementCommands, IPlateau plateau);
        void RunMovementCommands();
        void CheckConditionsToMove();
        string GetCurrentPositionAsString(bool parenthesis = false);
        #endregion
    }
}
