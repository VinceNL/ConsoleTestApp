using System.Reflection;

namespace ConsoleTestApp
{
    public class ReflectionExampleRunner
    {
        public static void Run()
        {
            const string TargetAssemblyFileName = "UtilityFunctions.dll";
            const string TargetAssemblyNameSpace = "UtilityFunctions";

            // Get the base directory of the current domain
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Navigate up the directory hierarchy to the solution root
            string solutionRoot = Directory.GetParent(baseDirectory).Parent.Parent.Parent.Parent.FullName;

            // Construct the path to the desired directory
            string targetDirectory = Path.Combine(solutionRoot, TargetAssemblyNameSpace, "bin", "Debug", "netstandard2.1");

            // Combine the target directory with the assembly file name
            string assemblyPath = Path.Combine(targetDirectory, TargetAssemblyFileName);

            Assembly assembly = Assembly.LoadFile(Path.Combine(@"F:\source\repos\DotNet\ConsoleTestApp\UtilityFunctions\bin\Debug\netstandard2.1\", TargetAssemblyFileName));

            List<Type> classes = assembly.GetTypes()
                .Where(t => t.Namespace == TargetAssemblyNameSpace && HasInformationAttribute(t)).ToList();


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please press the number key associated with " +
                    "the class you want to test");

                DisplayProgramElements(classes);

                Type typeChoice = ReturnProgramElementReference(classes);

                object instance = Activator.CreateInstance(typeChoice);

                Console.Clear();

                WriteHeadingToScreen($"Testing {typeChoice.Name}");

                DisplayElementDescription(ReturnInformationCustomAttributeDescription(typeChoice));

                WritePromptToScreen("Please enter the name of the method you want to test");

                List<MethodInfo> methods = typeChoice.GetMethods().Where(m => HasInformationAttribute(m)).ToList();

                DisplayProgramElements(methods);

                MethodInfo methodChoice = ReturnProgramElementReference(methods);

                if (methodChoice != null)
                {
                    Console.Clear();
                    WriteHeadingToScreen($"Testing {typeChoice.Name}.{methodChoice.Name}");

                    ParameterInfo[] parameters = methodChoice.GetParameters();

                    object result = GetResult(instance, methodChoice, parameters);

                    WriteResultToScreen(result);
                }

                Console.WriteLine();
                WritePromptToScreen("Press spacebar to end the application");

                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    break;
                }
            }
        }

        const string InformationAttributeTypeName = "UTILITYFUNCTIONS.INFORMATIONATTRIBUTE";

        private static string ReturnInformationCustomAttributeDescription(MemberInfo memberInfo)
        {
            foreach (Attribute attribute in memberInfo.GetCustomAttributes())
            {
                Type typeAttr = attribute.GetType();

                if (typeAttr.ToString().ToUpper() == InformationAttributeTypeName)
                {
                    PropertyInfo propertyInfo = typeAttr.GetProperty("Description");
                    if (propertyInfo != null)
                    {
                        object s = propertyInfo.GetValue(attribute, null);

                        if (s != null)
                        {
                            return s.ToString();
                        }
                    }
                }
            }
            return null;
        }

        private static void DisplayElementDescription(string elementDescription)
        {
            if (elementDescription != null)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(elementDescription);
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        private static bool HasInformationAttribute(MemberInfo memberInfo)
        {
            foreach (Attribute attribute in memberInfo.GetCustomAttributes())
            {
                Type typeAttr = attribute.GetType();

                if (typeAttr.ToString().ToUpper() == InformationAttributeTypeName)
                {
                    return true;
                }
            }
            return false;
        }

        private static object[] ReturnParameterValueInputAsObjectArray(ParameterInfo[] parameters)
        {
            object[] parameterValues = new object[parameters.Length];
            int itemCount = 0;

            foreach (ParameterInfo parameterInfo in parameters)
            {
                WritePromptToScreen($"Please enter a value for {parameterInfo.Name}");

                if (parameterInfo.ParameterType == typeof(string))
                {
                    string inputString = Console.ReadLine();
                    parameterValues[itemCount] = inputString;
                }
                else if (parameterInfo.ParameterType == typeof(int))
                {
                    int inputInt = int.Parse(Console.ReadLine());
                    parameterValues[itemCount] = inputInt;
                }
                else if (parameterInfo.ParameterType == typeof(double))
                {
                    double inputDouble = double.Parse(Console.ReadLine());
                    parameterValues[itemCount] = inputDouble;
                }
                else
                {
                    Console.WriteLine("Unsupported parameter type");
                }
                itemCount++;
            }
            return parameterValues;
        }

        private static object GetResult(Object classInstance, MethodInfo methodInfo,
                                        ParameterInfo[] parameters)
        {
            object result = null;

            if (parameters.Length == 0)
            {
                result = methodInfo.Invoke(classInstance, null);
            }
            else
            {
                var paramValueArray = ReturnParameterValueInputAsObjectArray(parameters);
                result = methodInfo.Invoke(classInstance, paramValueArray);
            }
            return result;
        }

        private static T ReturnProgramElementReference<T>(List<T> elements)
        {
            ConsoleKey consoleKey = Console.ReadKey().Key;

            switch (consoleKey)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("You selected 1");
                    return elements[0];
                case ConsoleKey.D2:
                    Console.WriteLine("You selected 2");
                    return elements[1];
                case ConsoleKey.D3:
                    Console.WriteLine("You selected 3");
                    return elements[2];
                case ConsoleKey.D4:
                    Console.WriteLine("You selected 4");
                    return elements[3];
            }
            return default;
        }

        private static void DisplayProgramElements<T>(List<T> elements)
        {
            int count = 0;

            foreach (T element in elements)
            {
                count++;
                Console.WriteLine($"{count}. {element}");
            }
        }

        private static void WriteHeadingToScreen(string heading)
        {
            Console.WriteLine(heading);
            Console.WriteLine(new string('-', heading.Length));
            Console.WriteLine();
        }

        private static void WritePromptToScreen(string prompt)
        {
            Console.WriteLine(prompt);
        }

        private static void WriteResultToScreen(object result)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"The result is: {result}");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
