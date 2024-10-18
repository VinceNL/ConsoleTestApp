using EventsCustomQueueExample;
using WarehouseManagementSystemAPI;

namespace TestConsoleApp
{
    public static class CustomQueueExampleRunner
    {
        private const int Batch_Size = 5;

        public static void Run()
        {
            CustomQueue<HardwareItem> hardwareItemQueue = new();

            hardwareItemQueue.CustomQueueEvent += Queue_CustomQueueEvent;

            Thread.Sleep(2000);

            //comes into stock - device scans a bar code or QR code
            hardwareItemQueue.AddItem(new Drill { Id = 1, Name = "Drill 1", Type = "Drill", UnitPrice = 20.00m, Quantity = 10 });

            Thread.Sleep(1000);

            hardwareItemQueue.AddItem(new Drill { Id = 2, Name = "Drill 2", Type = "Drill", UnitPrice = 30.00m, Quantity = 20 });

            Thread.Sleep(2000);

            hardwareItemQueue.AddItem(new Ladder { Id = 3, Name = "Ladder 1", Type = "Ladder", UnitPrice = 100.00m, Quantity = 5 });

            Thread.Sleep(1000);

            hardwareItemQueue.AddItem(new Hammer { Id = 4, Name = "Hammer 1", Type = "Hammer", UnitPrice = 10.00m, Quantity = 80 });
            Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new PaintBrush { Id = 5, Name = "Paint Brush 1", Type = "PaintBrush", UnitPrice = 5.00m, Quantity = 100 });
            Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new PaintBrush { Id = 6, Name = "Paint Brush 2", Type = "PaintBrush", UnitPrice = 5.00m, Quantity = 100 });
            Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new PaintBrush { Id = 7, Name = "Paint Brush 3", Type = "PaintBrush", UnitPrice = 5.00m, Quantity = 100 });
            Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new Hammer { Id = 8, Name = "Hammer 2", Type = "Hammer", UnitPrice = 11.00m, Quantity = 80 });
            Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new Hammer { Id = 9, Name = "Hammer 3", Type = "Hammer", UnitPrice = 13.00m, Quantity = 80 });
            Thread.Sleep(3000);

            hardwareItemQueue.AddItem(new Hammer { Id = 10, Name = "Hammer 4", Type = "Hammer", UnitPrice = 14.00m, Quantity = 80 });
            Thread.Sleep(3000);
            Console.ReadKey();
        }

        private static void ProcessItems(CustomQueue<HardwareItem> hardwareItemQueue)
        {
            while (hardwareItemQueue.QueueLength > 0)
            {
                Thread.Sleep(3000);
                HardwareItem item = hardwareItemQueue.GetItem();
            }
        }

        private static void Queue_CustomQueueEvent(CustomQueue<HardwareItem> sender, QueueEventArgs eventArgs)
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

        private static void WriteValuesInQueueToScreen(CustomQueue<HardwareItem> hardwareItems)
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