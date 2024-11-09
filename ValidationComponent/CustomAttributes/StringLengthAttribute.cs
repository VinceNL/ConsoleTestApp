using System;

namespace ValidationComponent.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field
        | AttributeTargets.Parameter, AllowMultiple = false)]
    public class StringLengthAttribute : Attribute
    {
        public int MinLength { get; set; }
        public string? ErrorMessage { get; set; }
        public int MaxLength { get; set; }

        public StringLengthAttribute(int maxLength)
        {
            SetProperties(maxLength);
        }

        public StringLengthAttribute(int maxLength, string errorMessage)
        {
            SetProperties(maxLength, errorMessage);
        }

        public StringLengthAttribute(int maxLength, int minLength)
        {
            SetProperties(maxLength, minLength: minLength);
        }

        public StringLengthAttribute(int maxLength, string errorMessage, int minLength)
        {
            SetProperties(maxLength, errorMessage, minLength);
        }

        private void SetProperties(int maxLength, string errorMessage = "", int? minLength = null)
        {
            if (errorMessage == "")
            {
                if (minLength == null)
                {
                    ErrorMessage = "The value for {0} must not exceed {1}";
                }
                else
                {
                    ErrorMessage = "The value for {0} must be between {1} and {2}";
                }
            }
            else
            {
                ErrorMessage = errorMessage;
            }
            MaxLength = maxLength;
            MinLength = minLength ?? 0;
        }
    }
}
