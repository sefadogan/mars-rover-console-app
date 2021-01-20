using Sefd.MarsRover.Common.Abstracts;
using Sefd.MarsRover.Common.Consts.Enums;

namespace Sefd.MarsRover.Common.Concretes
{
    public class RoverPosition : IRoverPosition
    {
        #region Properties
        public int X { get; set; }
        public int Y { get; set; }
        public RoverDirection Direction { get; set; }
        #endregion

        #region Constructors
        public RoverPosition()
        {
        }
        public RoverPosition(int x, int y)
        {
            X = x;
            Y = y;
            Direction = RoverDirection.N;
        }
        public RoverPosition(RoverDirection direction)
        {
            X = 0;
            Y = 0;
            Direction = direction;
        }
        public RoverPosition(RoverDirection direction = RoverDirection.N, int x = 0, int y = 0)
        {
            Direction = direction;
            X = x;
            Y = y;
        }
        #endregion

        #region Methods
        public void SetProperties(RoverDirection direction, int x, int y)
        {
            Direction = direction;
            X = x;
            Y = y;
        }
        #endregion
    }
}
