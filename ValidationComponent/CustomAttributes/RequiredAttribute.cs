using System;

namespace ValidationComponent.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field
        | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }

        public RequiredAttribute()
        {
            ErrorMessage = "You cannot leave field, {0}, empty";
        }

        public RequiredAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
