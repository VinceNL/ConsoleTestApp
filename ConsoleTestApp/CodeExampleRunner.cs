using WarehouseManagementSystemAPI;

namespace TestConsoleApp
{
    public static class CodeExampleRunner
    {
        private const int Batch_Size = 5;

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

        /// <summary>
        /// Runs the custom queue example.
        /// </summary>
        public static void RunCustomQueueExample()
        {
            CustomQueue<EventsCustomQueueExample.HardwareItem> hardwareItemQueue = new();

            hardwareItemQueue.CustomQueueEvent += Queue_CustomQueueEvent;

            Thread.Sleep(2000);

            //comes into stock - device scans a bar code or QR code
            hardwareItemQueue.AddItem(new EventsCustomQueueExample.Drill { Id = 1, Name = "Drill 1", Type = "Drill", UnitPrice = 20.00m, Quantity = 10 });

            Thread.Sleep(1000);

            hardwareItemQueue.AddItem(new EventsCustomQueueExample.Drill { Id = 2, Name = "Drill 2", Type = "Drill", UnitPrice = 30.00m, Quantity = 20 });

            Thread.Sleep(2000);

            hardwareItemQueue.AddItem(new EventsCustomQueueExample.Ladder { Id = 3, Name = "Ladder 1", Type = "Ladder", UnitPrice = 100.00m, Quantity = 5 });

            Thread.Sleep(1000);

            hardwareItemQueue.AddItem(new EventsCustomQueueExample.Hammer { Id = 4, Name = "Hammer 1", Type = "Hammer", UnitPrice = 10.00m, Quantity = 80 });
            Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new EventsCustomQueueExample.PaintBrush { Id = 5, Name = "Paint Brush 1", Type = "PaintBrush", UnitPrice = 5.00m, Quantity = 100 });
            Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new EventsCustomQueueExample.PaintBrush { Id = 6, Name = "Paint Brush 2", Type = "PaintBrush", UnitPrice = 5.00m, Quantity = 100 });
            Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new EventsCustomQueueExample.PaintBrush { Id = 7, Name = "Paint Brush 3", Type = "PaintBrush", UnitPrice = 5.00m, Quantity = 100 });
            Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new EventsCustomQueueExample.Hammer { Id = 8, Name = "Hammer 2", Type = "Hammer", UnitPrice = 11.00m, Quantity = 80 });
            Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new EventsCustomQueueExample.Hammer { Id = 9, Name = "Hammer 3", Type = "Hammer", UnitPrice = 13.00m, Quantity = 80 });
            Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new EventsCustomQueueExample.Hammer { Id = 10, Name = "Hammer 4", Type = "Hammer", UnitPrice = 14.00m, Quantity = 80 });
            Thread.Sleep(3000);
            Console.ReadKey();
        }

        private static void ProcessItems(CustomQueue<EventsCustomQueueExample.HardwareItem> hardwareItemQueue)
        {
            while (hardwareItemQueue.QueueLength > 0)
            {
                Thread.Sleep(3000);
                EventsCustomQueueExample.HardwareItem item = hardwareItemQueue.GetItem();
            }
        }

        private static void Queue_CustomQueueEvent(CustomQueue<EventsCustomQueueExample.HardwareItem> sender, QueueEventArgs eventArgs)
        {
            Console.Clear();
            Console.WriteLine(MainHeading());
            Console.WriteLine();
            Console.WriteLine(RealTimeUpdateHeading());

            if (sender.QueueLength > 0)
            {
                Console.WriteLine(eventArgs.Message);
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine(ItemsInQueueHeading());
                Console.WriteLine(FieldHeadings());

                WriteValuesInQueueToScreen(sender);

                if (sender.QueueLength == Batch_Size)
                {
                    ProcessItems(sender);
                }
            }
            else
            {
                Console.WriteLine("All items have been processed");
            }
        }

        private static void WriteValuesInQueueToScreen(CustomQueue<EventsCustomQueueExample.HardwareItem> hardwareItems)
        {
            foreach (var item in hardwareItems)
            {
                Console.WriteLine($"{item.Id,-6}{item.Name,-15}{item.Type,-20}{item.Quantity,10}{item.UnitPrice,10}");
            }
        }

        //Headings
        private static string FieldHeadings()
        {
            return UnderLine($"{"Id",-6}{"Name",-15}{"Type",-20}{"Quantity",10}{"Value",10}");
        }

        private static string RealTimeUpdateHeading()
        {
            return UnderLine("Real-time Update");
        }

        private static string ItemsInQueueHeading()
        {
            return UnderLine("Items Queued for Processing");
        }

        private static string MainHeading()
        {
            return UnderLine("Warehouse Management System");
        }

        private static string UnderLine(string heading)
        {
            return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
        }

        //Headings
    }
}