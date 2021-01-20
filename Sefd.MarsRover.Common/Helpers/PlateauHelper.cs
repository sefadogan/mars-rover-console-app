using System;

namespace Sefd.MarsRover.Common.Helpers
{
    public class PlateauHelper
    {
        /// <summary>
        /// Splits plateau coordinates, then returns the converted int array
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public static int[] SplitPlateauCoordinates(string coordinates)
        {
            var splittedCoordinates = CommonHelper.SplitBySpace(coordinates);
            var convertedCoordinates = CommonHelper.ConvertStringArrayToInt(splittedCoordinates);

            if (convertedCoordinates.Length > 2) 
                throw new Exception("Invalid coordinates");

            return convertedCoordinates;
        }        
    }
}
