namespace TestConsoleApp
{
    public static class CodeExampleRunner
    {
        /// <summary>
        /// Runs the event delegation example.
        /// </summary>
        public static void RunEventDelegationExample()
        {
            Console.WriteLine("Press any key to run the device");
            Console.ReadKey();
            Console.WriteLine();
            EventDelegationExample.IDevice device = new EventDelegationExample.Device();
            device.RunDevice();
            Console.ReadKey();
        }

        /// <summary>
        /// Runs the observer pattern example.
        /// </summary>
        public static void RunObserverPatternExample()
        {
            Console.Clear();

            ObserverPatternExample.SecuritySurveillanceHub securitySurveillanceHub = new ObserverPatternExample.SecuritySurveillanceHub();

            ObserverPatternExample.EmployeeNotify employeeNotify = new ObserverPatternExample.EmployeeNotify(new ObserverPatternExample.Employee
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones",
                JobTitle = "Development Manager"
            });
            ObserverPatternExample.EmployeeNotify employeeNotify2 = new ObserverPatternExample.EmployeeNotify(new ObserverPatternExample.Employee
            {
                Id = 2,
                FirstName = "Dave",
                LastName = "Kendal",
                JobTitle = "Chief Information Officer"
            });

            ObserverPatternExample.SecurityNotify securityNotify = new ObserverPatternExample.SecurityNotify();

            employeeNotify.Subscribe(securitySurveillanceHub);
            employeeNotify2.Subscribe(securitySurveillanceHub);
            securityNotify.Subscribe(securitySurveillanceHub);

            securitySurveillanceHub.ConfirmExternalVisitorEntersBuilding(1, "Andrew", "Jackson", "The Company", "Contractor", DateTime.Parse("12 May 2020 11:00"), 1);
            securitySurveillanceHub.ConfirmExternalVisitorEntersBuilding(2, "Jane", "Davidson", "Another Company", "Lawyer", DateTime.Parse("12 May 2020 12:00"), 2);

            // employeeNotify.UnSubscribe();

            securitySurveillanceHub.ConfirmExternalVisitorExitsBuilding(1, DateTime.Parse("12 May 2020 13:00"));
            securitySurveillanceHub.ConfirmExternalVisitorExitsBuilding(2, DateTime.Parse("12 May 2020 15:00"));

            securitySurveillanceHub.BuildingEntryCutOffTimeReached();

            Console.ReadKey();
        }


        /// <summary>
        /// Runs the generics with constraint example.
        /// </summary>
        public static void RunGenericsWithConstraintExample()
        {
            GenericsWithConstraintExample.Employee[] arr =
            {
                new GenericsWithConstraintExample.Employee { Id = 1, Name = "Bob" },
                new GenericsWithConstraintExample.Employee { Id = 4, Name = "John"},
                new GenericsWithConstraintExample.Employee { Id = 3, Name = "Andrew" },
                new GenericsWithConstraintExample.Employee { Id = 2, Name = "Dave" },
            };

            GenericsWithConstraintExample.SortArray<GenericsWithConstraintExample.Employee> sortArray = new();

            sortArray.BubbleSort(arr);

            foreach (var item in arr)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }
    }
}