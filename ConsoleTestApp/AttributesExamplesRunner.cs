#define LOG_INFO
using System.Reflection;
using LoggingComponent;
using ConsoleTestApp.Models;
using System.Text.Json;

[assembly: AssemblyDescription("My assembly description")]
namespace ConsoleTestApp
{
    public class AttributesExamplesRunner
    {
        public static void Run()
        {
            OutputGlobalAttributeInformation();
            LoggingTest();

            var employee = new Employee();
            var department = new Department();

            string empId = null;
            string firstName = null;
            string postCode = null;
            string shortName = null;

            Type employeeType = typeof(Employee);
            Type departmentType = typeof(Department);

            if (GetInput(employeeType, "Enter Employee ID", "Id", out empId) &&
                GetInput(employeeType, "Enter First Name", "FirstName", out firstName) &&
                GetInput(employeeType, "Enter Post Code", "PostCode", out postCode) &&
                GetInput(departmentType, "Enter The employee's department code", "ShortName", out shortName))
            {
                employee.Id = Int32.Parse(empId);
                employee.FirstName = firstName;
                employee.PostCode = postCode;
                department.ShortName = shortName;
            }

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Thank you. Employee with first name, {employee.FirstName}, Id, {employee.Id}, Post Code, {employee.PostCode}, and Department Code, {department.ShortName} has been entered successfully");
            Console.ResetColor();

            Console.ReadKey();

            var employeeJSON = JsonSerializer.Serialize(employee);

            Console.WriteLine(employeeJSON);

            Console.ReadKey();
        }

        private static bool GetInput(Type t, string promptText, string fieldName, out string fieldValue)
        {
            fieldValue = string.Empty;
            string enteredValue = string.Empty;
            string errorMessage = null;

            do
            {
                Console.WriteLine(promptText);
                enteredValue = Console.ReadLine();

                if (!ValidationComponent.ValidationComponent.PropertyValueIsValid(t, enteredValue, fieldName, out errorMessage))
                {
                    fieldValue = null;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(errorMessage);
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    fieldValue = enteredValue;
                    break;
                }
            }
            while (true);

            return true;
        }

        private static void LoggingTest()
        {
            Logging.LogToScreen("this code is testing logging functionality");
        }

        private static void OutputGlobalAttributeInformation()
        {
            Assembly assem = typeof(AttributesExamplesRunner).Assembly;

            AssemblyName assemName = assem.GetName();

            Version? version = assemName.Version;

            object[] attributes = assem.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);

            var assemblyDescription = attributes[0] as AssemblyDescriptionAttribute;

            Console.WriteLine($"Assembly Name: {assemName}");
            Console.WriteLine($"Assembly Version: {version}");

            if (assemblyDescription != null)
            {
                Console.WriteLine($"Assembly Description: {assemblyDescription.Description}");
            }
        }
    }
}
