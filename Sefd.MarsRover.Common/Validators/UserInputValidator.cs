
namespace Sefd.MarsRover.Common.Validators
{
    public class UserInputValidator 
    {
        /// <summary>
        /// Basic validate implementation for user input
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Validate(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            // So on..

            return true;
        }
    }
}
