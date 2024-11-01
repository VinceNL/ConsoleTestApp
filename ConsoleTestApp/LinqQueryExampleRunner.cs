using TCPData;

namespace ConsoleTestApp
{
    public static class LinqQueryExampleRunner
    {
        public static void Run()
        {
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            ////Filter Method Example (custom implementation)
            //var filteredEmployees = employees.Filter(e => e.IsManager == false && e.AnnualSalary < 50000);

            //foreach (var employee in filteredEmployees)
            //{
            //    Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.AnnualSalary}");
            //}

            ////Select and Where Operators - Method Syntax
            //var results = employeeList.Select(e => new
            //{
            //    FullName = e.FirstName + " " + e.LastName,
            //    e.AnnualSalary

            //}).Where(e => e.AnnualSalary >= 50000);

            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
            //}

            ////Select and Where Operators - Query Syntax
            //var results2 = from emp in employeeList
            //              where emp.AnnualSalary >= 50000
            //              select new
            //              {
            //                  FullName = emp.FirstName + " " + emp.LastName,
            //                  emp.AnnualSalary
            //              };

            //foreach (var item in results2)
            //{
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
            //}

            ////Deferred Execution Example
            //var results3 = from emp in employeeList.GetHighSalariedEmployees()
            //              select new
            //              {
            //                  FullName = emp.FirstName + " " + emp.LastName,
            //                  emp.AnnualSalary
            //              };

            //employeeList.Add(new Employee
            //{
            //    Id = 5,
            //    FirstName = "Sam",
            //    LastName = "Davis",
            //    AnnualSalary = 100000.20m,
            //    IsManager = true,
            //    DepartmentId = 2

            //});

            //foreach (var item in results3)
            //{
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
            //}

            ////Immediate Execution Example
            //var results4 = (from emp in employeeList.GetHighSalariedEmployees()
            //               select new
            //               {
            //                   FullName = emp.FirstName + " " + emp.LastName,
            //                   emp.AnnualSalary
            //               }).ToList();

            //employeeList.Add(new Employee
            //{
            //    Id = 5,
            //    FirstName = "Sam",
            //    LastName = "Davis",
            //    AnnualSalary = 100000.20m,
            //    IsManager = true,
            //    DepartmentId = 2

            //});

            //foreach (var item in results4)
            //{
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
            //}

            //// Join Operation Example - Method Syntax
            //var results5 = departmentList.Join(employeeList,
            //        department => department.Id,
            //        employee => employee.DepartmentId,
            //        (department, employee) => new
            //        {
            //            FullName = employee.FirstName + " " + employee.LastName,
            //            employee.AnnualSalary,
            //            DepartmentName = department.LongName
            //        }
            //    );

            //foreach (var item in results5)
            //{
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.FullName}");
            //}

            //// Join Operation Example - Query Syntax
            //var results6 = from dept in departmentList
            //              join emp in employeeList
            //              on dept.Id equals emp.DepartmentId
            //              select new
            //              {
            //                  FullName = emp.FirstName + " " + emp.LastName,
            //                  emp.AnnualSalary,
            //                  DepartmentName = dept.LongName

            //              };

            //foreach (var item in results6)
            //{
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.FullName}");
            //}

            ////GroupJoin Operator Example - Method Syntax
            //var results7 = departmentList.GroupJoin(employeeList,
            //        dept => dept.Id,
            //        emp => emp.DepartmentId,
            //        (dept, employeesGroup) => new
            //        {
            //            Employees = employeesGroup,
            //            FullName = dept.LongName
            //        }
            //    );

            //foreach (var item in results7)
            //{
            //    Console.WriteLine($"Department Name: {item.FullName}");
            //    foreach (var emp in item.Employees)
            //        Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");

            //}

            ////GroupJoin Operator Example - Query Syntax
            var results8 = from dept in departmentList
                           join emp in employeeList
                           on dept.Id equals emp.DepartmentId
                           into employeeGroup
                           select new
                           {
                               Employees = employeeGroup,
                               FullName = dept.LongName
                           };

            foreach (var item in results8)
            {
                Console.WriteLine($"Department Name: {item.FullName}");
                foreach (var emp in item.Employees)
                    Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");

            }

            Console.ReadKey();
        }
    }
}
