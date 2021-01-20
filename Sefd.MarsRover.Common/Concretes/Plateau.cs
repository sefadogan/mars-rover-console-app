using Sefd.MarsRover.Common.Abstracts;
using System.Collections.Generic;

namespace Sefd.MarsRover.Common.Concretes
{
    public class Plateau : IPlateau
    {
        #region Properties
        public int X { get; set; }
        public int Y { get; set; }
        public IList<IRover> Rovers { get; set; }
        #endregion

        #region Constructors
        public Plateau()
        {
            Rovers = new List<IRover>();
        }
        #endregion

        #region Methods
        public void ProcessCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion
    }
}
