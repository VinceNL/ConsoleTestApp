using System;
using System.Collections.Generic;
using TCPData;

namespace TCPExtensions
{
    public static class Extension
    {
        public static List<T> Filter<T>(this List<T> records, Func<T, bool> predicate)
        {
            var filteredResult = new List<T>();
            foreach (var item in records)
            {
                if (predicate(item))
                {
                    filteredResult.Add(item);
                }
            }
            return filteredResult;
        }

        public static IEnumerable<Employee> GetHighSalariedEmployees(this IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                if (employee is Employee emp)
                {
                    if (emp.AnnualSalary >= 50000)
                    {
                        yield return employee;
                    }
                }
            }
        }
    }
}
