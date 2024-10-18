namespace TestConsoleApp
{
    public static class EventDelegationExampleRunner
    {
        public static void Run()
        {
            Console.WriteLine("Press any key to run the device");
            Console.ReadKey();
            Console.WriteLine();
            EventDelegationExample.IDevice device = new EventDelegationExample.Device();
            device.RunDevice();
            Console.ReadKey();
        }
    }
}
