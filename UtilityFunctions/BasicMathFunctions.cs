using System;

namespace UtilityFunctions
{
    [Information(Description = "This class contains basic math functions")]
    public class BasicMathFunctions
    {
        [Information(Description = "This method devides two numbers")]
        public double DivideOperation(double number1, double number2)
        {
            if (number2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            return number1 / number2;
        }

        [Information(Description = "This method multiplies two numbers")]
        public double MultiplyOperation(double number1, double number2)
        {
            return number1 * number2;
        }

        [Information(Description = "This method adds two numbers")]
        public double AddOperation(double number1, double number2)
        {
            return number1 + number2;
        }
    }
}
