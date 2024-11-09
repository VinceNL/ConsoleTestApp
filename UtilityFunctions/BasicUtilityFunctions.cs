using System;

namespace UtilityFunctions
{
    [Information(Description = "This class contains basic utility functions")]
    public class BasicUtilityFunctions
    {
        [Information(Description = "This method writes a welcome message")]
        public string WriteWelcomeMessage(string name)
        {
            return $"Welcome {name}";
        }

        [Information(Description = "This method concatenates three strings")]
        public string ConcatThreeStrings(string string1, string string2, string string3)
        {
            return string1 + " " + string2 + " " + string3;
        }

        [Information(Description = "This method returns the length of a string")]
        public int GetStringLength(string inputString)
        {
            return inputString.Length;
        }
    }
}
