using System;

namespace Sefd.MarsRover.Common.Helpers
{
    public class CommonHelper
    {
        /// <summary>
        /// Splits text by space
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string[] SplitBySpace(string text)
        {
            return text.Split(' ');
        }

        /// <summary>
        /// Converts string array to int array
        /// </summary>
        /// <param name="stringArray"></param>
        /// <returns></returns>
        public static int[] ConvertStringArrayToInt(string[] stringArray)
        {
            return Array.ConvertAll(stringArray, st => int.Parse(st));
        }
    }
}
