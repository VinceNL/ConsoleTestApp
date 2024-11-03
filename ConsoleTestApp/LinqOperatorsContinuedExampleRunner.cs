using TCPData;

namespace ConsoleTestApp
{
    public class LinqOperatorsContinuedExampleRunner
    {
        public static void Run()
        {
            var employees = Data.GetEmployees();
            var departments = Data.GetDepartments();

            ////Equality Operator
            ////SequenceEqual
            //var employeeListCompare = Data.GetEmployees();
            //bool areEqual = employees.SequenceEqual(employeeListCompare, new EmployeeComparer());

            //Console.WriteLine($"Are the two lists equal? {areEqual}");

            ////Concat
            //var employeeList2 = new List<Employee> 
            //{ 
            //    new Employee { Id = 9, FirstName = "Fred", LastName = "Horst", AnnualSalary = 200300.40m, DepartmentId =3, IsManager = false},
            //    new Employee { Id = 10, FirstName = "Sally", LastName = "Smith", AnnualSalary = 300400.50m, DepartmentId = 2, IsManager = true},
            //    new Employee { Id = 11, FirstName = "Joe", LastName = "Doe", AnnualSalary = 400500.60m, DepartmentId = 1, IsManager = false}
            //};

            //var concattedResult = employees.Concat(employeeList2);

            //foreach (var employee in concattedResult)
            //{
            //    Console.WriteLine($"{employee.Id, -5}{employee.FirstName, -10} {employee.LastName, -10}");
            //}

            //// Aggregate Operator

            //decimal totalSalaries = employees.Aggregate(0m, (total, next) =>
            //{
            //    var bonus = next.IsManager ? 0.04m : 0.20m;

            //    return total + next.AnnualSalary + (next.AnnualSalary * bonus);
            //});

            //Console.WriteLine(string.Create(CultureInfo.CreateSpecificCulture("en-US"), $"Total Salaries: {totalSalaries:C}"));

            //string data = employees.Aggregate("Employees Annual Salaries (including bonus): \n", (sb, next) =>
            //{
            //    var bonus = next.IsManager ? 0.04m : 0.20m;

            //    sb += string.Create(CultureInfo.CreateSpecificCulture("en-US"), $"{next.FirstName} {next.LastName} - {next.AnnualSalary + (next.AnnualSalary * bonus)}\n");
            //    return sb;
            //}, sb => sb.Substring(0, sb.Length - 2));

            //Console.WriteLine(data);

            //// DefaultIfEmpty Operator
            //var intList = new List<int>();
            //var newList = intList.DefaultIfEmpty(9999);

            //Console.WriteLine(newList.ElementAt(0));

            ////Empty Operator
            //var emptyEmployeeList = Enumerable.Empty<Employee>().ToList();

            //emptyEmployeeList.Add(new Employee { Id = 1, FirstName = "John", LastName = "Doe", AnnualSalary = 100000.00m, DepartmentId = 1, IsManager = true });

            //foreach (var employee in emptyEmployeeList)
            //{
            //    Console.WriteLine($"{employee.Id,-5}{employee.FirstName,-10} {employee.LastName,-10}");
            //}

            ////Range Operator
            //var intCollection = Enumerable.Range(25, 20);

            //foreach (var item in intCollection)
            //{
            //    Console.WriteLine(item);
            //}

            ////Repeat Operator
            //var stringCollection = Enumerable.Repeat("Hello World", 10);
            //foreach (var item in stringCollection)
            //{
            //    Console.WriteLine(item);
            //}

            ////Set operators - Distinct, Except, Intersect, Union
            //var integerList1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //var distinctResult = integerList1.Distinct();

            //foreach (var item in distinctResult)
            //{
            //    Console.WriteLine(item);
            //}

            //var integerList2 = new List<int> { 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            //var integerList3 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //var distinctResult = integerList2.Except(integerList3);

            //foreach (var item in distinctResult)
            //{
            //    Console.WriteLine(item);
            //}

            //var employeeList1 = new List<Employee>
            //{
            //    new Employee { Id = 1, FirstName = "John", LastName = "Doe", AnnualSalary = 100000.00m, DepartmentId = 1, IsManager = true },
            //    new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", AnnualSalary = 200000.00m, DepartmentId = 2, IsManager = false },
            //    new Employee { Id = 3, FirstName = "Sally", LastName = "Jones", AnnualSalary = 300000.00m, DepartmentId = 3, IsManager = true }
            //};

            //var employeeList2 = new List<Employee>
            //{
            //    new Employee { Id = 1, FirstName = "John", LastName = "Doe", AnnualSalary = 100000.00m, DepartmentId = 1, IsManager = true },
            //    new Employee { Id = 4, FirstName = "Fred", LastName = "Horst", AnnualSalary = 200300.40m, DepartmentId = 3, IsManager = false},
            //    new Employee { Id = 5, FirstName = "Sally", LastName = "Smith", AnnualSalary = 300400.50m, DepartmentId = 2, IsManager = true},
            //    new Employee { Id = 6, FirstName = "Joe", LastName = "Doe", AnnualSalary = 400500.60m, DepartmentId = 1, IsManager = false}
            //};

            //var distinctResult = employeeList1.Intersect(employeeList2, new EmployeeComparer());
            //var distinctResult2 = employeeList1.Union(employeeList2, new EmployeeComparer());

            //foreach (var item in distinctResult)
            //{
            //    Console.WriteLine($"{item.Id,-5}{item.FirstName,-10} {item.LastName,-10}");
            //}

            //Console.WriteLine();

            //foreach (var item in distinctResult2)
            //{
            //    Console.WriteLine($"{item.Id,-5}{item.FirstName,-10} {item.LastName,-10}");
            //}

            ////Partitioning Operators - Skip, SkipWhile, Take, TakeWhile
            ////Skip
            //var results = employees.Skip(2);

            //foreach (var employee in results)
            //{
            //    Console.WriteLine($"{employee.Id,-5}{employee.FirstName,-10} {employee.LastName,-10}");
            //}

            ////SkipWhile
            //var results = employees.SkipWhile(e => e.AnnualSalary > 20000);

            //foreach (var employee in results)
            //{
            //    Console.WriteLine($"{employee.Id,-5}{employee.FirstName,-10} {employee.LastName,-10}");
            //}

            ////Take
            //var results = employees.Take(2);
            //foreach (var employee in results)
            //{
            //    Console.WriteLine($"{employee.Id,-5}{employee.FirstName,-10} {employee.LastName,-10}");
            //}

            ////TakeWhile
            //var results = employees.TakeWhile(e => e.AnnualSalary > 20000);

            //foreach (var employee in results)
            //{
            //    Console.WriteLine($"{employee.Id,-5}{employee.FirstName,-10} {employee.LastName,-10}");
            //}

            // Conversion Operators - ToArray, ToDictionary, ToList, ToLookup
            //List<Employee> results = (from e in employees
            //                         where e.AnnualSalary > 20000
            //                         select e).ToList();

            //foreach (var employee in results)
            //{
            //    Console.WriteLine($"{employee.Id,-5}{employee.FirstName,-10} {employee.LastName,-10}");
            //}

            //Dictionary<int, Employee> results = (from e in employees
            //                                     where e.AnnualSalary > 20000
            //                                     select e).ToDictionary(e => e.Id);

            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.Key} : {item.Value.FirstName} {item.Value.LastName}");
            //}

            //Dictionary<int, Employee> results = (from e in employees
            //                                     where e.AnnualSalary > 20000
            //                                     select e).ToDictionary(e => e.Id);

            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.Key} : {item.Value.FirstName} {item.Value.LastName}");
            //}

            ////Let clause
            //var results = from emp in employees
            //              let initials = emp.FirstName.Substring(0, 1).ToUpper() + emp.LastName.Substring(0, 1).ToUpper()
            //              let AnnualSalary = emp.AnnualSalary + (emp.IsManager ? (0.04m * emp.AnnualSalary) : (0.20m * emp.AnnualSalary))
            //              where initials == "JD" || initials == "SJ" && AnnualSalary > 20000
            //              select new
            //              {
            //                  emp.Id,
            //                  emp.FirstName,
            //                  emp.LastName,
            //                  emp.AnnualSalary,
            //                  initials
            //              };

            //foreach (var employee in results)
            //{
            //    Console.WriteLine($"{employee.Id,-5}{employee.FirstName,-10} {employee.LastName,-10} {employee.AnnualSalary,-10} {employee.initials,-5}");
            //}

            //// into clause
            var results = from emp in employees
                          where emp.AnnualSalary > 20000
                          select emp into highPaidEmployees
                          where highPaidEmployees.IsManager == true
                          select highPaidEmployees;

            foreach (var employee in results)
            {
                Console.WriteLine($"{employee.Id,-5}{employee.FirstName,-10} {employee.LastName,-10}");
            }

            Console.ReadKey();
        }
    }
}
