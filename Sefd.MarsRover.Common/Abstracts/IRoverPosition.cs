using Sefd.MarsRover.Common.Consts.Enums;

namespace Sefd.MarsRover.Common.Abstracts
{
    public interface IRoverPosition
    {
        #region Properties
        int X { get; set; }
        int Y { get; set; }
        RoverDirection Direction { get; set; }
        #endregion

        #region Methods
        void SetProperties(RoverDirection direction, int x, int y);
        #endregion
    }
}
