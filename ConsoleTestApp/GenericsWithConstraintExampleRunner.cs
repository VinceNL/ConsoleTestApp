using GenericsWithConstraintExample;

namespace TestConsoleApp
{
    public static class GenericsWithConstraintExampleRunner
    {
        public static void Run()
        {
            Employee[] arr =
            {
                new Employee { Id = 1, Name = "Bob" },
                new Employee { Id = 4, Name = "John"},
                new Employee { Id = 3, Name = "Andrew" },
                new Employee { Id = 2, Name = "Dave" },
            };

            SortArray<Employee> sortArray = new();

            sortArray.BubbleSort(arr);

            foreach (var item in arr)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }
    }
}
