using ConsoleTestApp;

namespace TestConsoleApp
{
    public static class CodeExampleRunner
    {
        public static void RunEventDelegationExample()
        {
            EventDelegationExampleRunner.Run();
        }

        public static void RunObserverPatternExample()
        {
            ObserverPatternExampleRunner.Run();
        }

        public static void RunGenericsWithConstraintExample()
        {
            GenericsWithConstraintExampleRunner.Run();
        }

        public static void RunCustomQueueExample()
        {
            CustomQueueExampleRunner.Run();
        }

        public static void RunFactoryPatternExample()
        {
            FactoryPatternExampleRunner.Run();
        }

        public static void RunBinaryFlagsExample()
        {
            BinaryFlagsExampleRunner.Run();
        }
    }
}