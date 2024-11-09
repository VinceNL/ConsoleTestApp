using ValidationComponent.CustomAttributes;
using System.Text.RegularExpressions;
using System;
using System.Reflection;
using System.Linq;

namespace ValidationComponent
{
    public class ValidationComponent
    {
        public static bool PropertyValueIsValid(Type type, string enteredValue, string elementName, out string errorMessage)
        {
            PropertyInfo property = type.GetProperty(elementName);

            Attribute[] attributes = property.GetCustomAttributes().ToArray();

            errorMessage = string.Empty;

            foreach (Attribute attribute in attributes)
            {
                switch (attribute)
                {
                    case RequiredAttribute required:
                        if (!FieldRequiredIsValid(enteredValue))
                        {
                            errorMessage = required.ErrorMessage;
                            errorMessage = string.Format(errorMessage, property.Name);
                            return false;
                        }
                        break;
                    case StringLengthAttribute stringLength:
                        if (!FieldStringLengthIsValid(stringLength, enteredValue))
                        {
                            errorMessage = stringLength.ErrorMessage!;
                            errorMessage = string.Format(errorMessage, property.Name, stringLength.MaxLength, stringLength.MinLength);
                            return false;
                        }
                        break;
                    case RegularExpressionAttribute regularExpression:
                        if (!FieldPatternMatchIsValid(regularExpression, enteredValue))
                        {
                            errorMessage = regularExpression.ErrorMessage;
                            errorMessage = string.Format(errorMessage, property.Name, regularExpression.Pattern);
                            return false;
                        }
                        break;
                    default:
                        break;
                }
            }
            return true;
        }

        private static bool FieldRequiredIsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        private static bool FieldStringLengthIsValid(StringLengthAttribute stringLengthAttribute, string enteredValue)
        {
            if (enteredValue.Length >= stringLengthAttribute.MinLength && enteredValue.Length <= stringLengthAttribute.MaxLength)
            {
                return true;
            }
            return false;
        }

        private static bool FieldPatternMatchIsValid(RegularExpressionAttribute regularExpressionAttribute, string enteredValue)
        {
            if (Regex.IsMatch(enteredValue, regularExpressionAttribute.Pattern))
            {
                return true;
            }
            return false;
        }
    }
}
