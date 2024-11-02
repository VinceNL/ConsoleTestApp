
using TCPData;

namespace ConsoleTestApp
{
    public class LinqOperatorsExampleRunner
    {
        public static void Run()
        {
            List<Employee> employees = Data.GetEmployees();
            List<Department> departments = Data.GetDepartments();


            // Sorting Operations OrderBy, OrderByDescending, ThenBy, ThenByDescending
            // Method Syntax
            //var results = employees.Join(departments,
            //    e => e.DepartmentId,
            //    d => d.Id,
            //    (e, d) => new
            //    {
            //        e.Id,
            //        e.FirstName,
            //        e.LastName,
            //        e.AnnualSalary,
            //        DepartmentId = d.Id,
            //        DepartmentName = d.LongName
            //    }).OrderBy(o => o.DepartmentId).ThenByDescending(o => o.AnnualSalary);

            //// Query Syntax
            //var results = from e in employees
            //               join d in departments
            //               on e.DepartmentId equals d.Id
            //               orderby d.Id, e.AnnualSalary descending
            //               select new
            //               {
            //                   e.Id,
            //                   e.FirstName,
            //                   e.LastName,
            //                   e.AnnualSalary,
            //                   DepartmentId = d.Id,
            //                   DepartmentName = d.LongName
            //               };
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"FirstName: {item.FirstName, -10} Last Name:{item.LastName, -10} Annual Salary: {item.AnnualSalary, 10} DepartmentName: {item.DepartmentName}");
            //}

            //// Grouping Operations GroupBy, ToLookup
            //// Query Syntax
            //var groupedResults = from e in employees
            //                     orderby e.DepartmentId
            //                     group e by e.DepartmentId;

            //// Method Syntax
            //var groupedResults = employees.OrderBy(o => o.DepartmentId).ToLookup(g => g.DepartmentId);

            //foreach (var empGroup in groupedResults)
            //{
            //    Console.WriteLine($"Department Id: {empGroup.Key}");
            //    foreach (var emp in empGroup)
            //    {
            //        Console.WriteLine($"\tEmployee FullName: {emp.FirstName} {emp.LastName}");
            //    }
            //}

            //// All, Any, Contains, quantifiers operators
            //var annualSalaryComparer = 20_000;

            //bool isAllTrue = employees.All(e => e.AnnualSalary > annualSalaryComparer);

            //if (isAllTrue)
            //{
            //    Console.WriteLine("All employees have annual salary greater than 20,000");
            //}
            //else
            //{
            //    Console.WriteLine("Not all employees have annual salary greater than 20,000");
            //}

            //bool isTrueAny = employees.Any(e => e.AnnualSalary > annualSalaryComparer);

            //if (isTrueAny)
            //{
            //    Console.WriteLine("At least one employee has annual salary greater than 20,000");
            //}
            //else
            //{
            //    Console.WriteLine("No employee has annual salary greater than 20,000");
            //}

            ////Contains
            //var searchEmployee = new Employee
            //{
            //    Id = 3,
            //    FirstName = "Tom",
            //    LastName = "Jones",
            //    AnnualSalary = 40000,
            //    IsManager = false,
            //    DepartmentId = 3
            //};

            //bool containsEmployee = employees.Contains(searchEmployee, new EmployeeComparer());

            //if (containsEmployee)
            //{
            //    Console.WriteLine("Employee found in the list");
            //}
            //else
            //{
            //    Console.WriteLine("Employee not found in the list");
            //}


            //// ofType filter operator
            //ArrayList mixedCollection = Data.GetHeterogeneousDataCollection();

            //var stringResults = from s in mixedCollection.OfType<string>()
            //                    select s;

            //foreach (var item in stringResults)
            //{
            //    Console.WriteLine(item);
            //}

            ////Element Operators First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault, ElementAt
            //var employee = employees.ElementAtOrDefault(13);

            //if (employee == null)
            //{
            //    Console.WriteLine("Employee not found");
            //}
            //else
            //{
            //    Console.WriteLine($"Employee Id: {employee.Id} First Name: {employee.FirstName} Last Name: {employee.LastName}");
            //}

            //var integerList = new List<int> { 1, 3, 5, 7, 9, 11, 13 };

            //int result = integerList.FirstOrDefault(i => i % 2 == 0);

            //if (result == 0)
            //{
            //    Console.WriteLine("No even number found");
            //}
            //else
            //{
            //    Console.WriteLine($"First even number found: {result}");
            //}

            var emp = employees.SingleOrDefault(e => e.Id == 3);

            if (emp == null)
            {
                Console.WriteLine("Employee not found");
            }
            else
            {
                Console.WriteLine($"Employee Id: {emp.Id} First Name: {emp.FirstName} Last Name: {emp.LastName}");
            }

            Console.ReadKey();
        }
    }
}
