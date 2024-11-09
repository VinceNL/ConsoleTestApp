using System;

namespace ValidationComponent.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field
        | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RegularExpressionAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
        public string Pattern { get; set; }
        public RegularExpressionAttribute(string pattern)
        {
            Pattern = pattern;
            ErrorMessage = "The value for {0} does not match the pattern {1}";
        }

        public RegularExpressionAttribute(string pattern, string errorMessage)
        {
            Pattern = pattern;
            ErrorMessage = errorMessage;
        }
    }
}
