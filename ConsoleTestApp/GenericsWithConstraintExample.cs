namespace GenericsWithConstraintExample
{
    public class Employee : IComparable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo(Employee? other)
        {
            return this.Id.CompareTo(other?.Id);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }

    public class SortArray<T> where T : IComparable<T>
    {
        public void BubbleSort(T[] arr)
        {
            // Bubble sort algorithm
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j]!.CompareTo(arr[j + 1]) > 0)
                    {
                        Swap(arr, j);
                    }
                }
            }
        }

        private void Swap(T[] arr, int j)
        {
            T temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;
        }
    }
}