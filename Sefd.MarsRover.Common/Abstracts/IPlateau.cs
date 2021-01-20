using System.Collections.Generic;

namespace Sefd.MarsRover.Common.Abstracts
{
    public interface IPlateau
    {
        #region Properties
        int X { get; set; }
        int Y { get; set; }
        IList<IRover> Rovers { get; set; }
        #endregion

        #region Methods
        void ProcessCoordinates(int x, int y);
        #endregion
    }
}
