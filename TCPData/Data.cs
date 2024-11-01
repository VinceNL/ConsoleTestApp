using System.Collections.Generic;

namespace TCPData
{
    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    AnnualSalary = 60000,
                    IsManager = true,
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    AnnualSalary = 50000,
                    IsManager = false,
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Tom",
                    LastName = "Jones",
                    AnnualSalary = 40000,
                    IsManager = false,
                    DepartmentId = 3
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Sue",
                    LastName = "Johnson",
                    AnnualSalary = 30000,
                    IsManager = false,
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 5,
                    FirstName = "Bill",
                    LastName = "Davis",
                    AnnualSalary = 20000,
                    IsManager = false,
                    DepartmentId = 3
                },
                new Employee
                {
                    Id = 6,
                    FirstName = "Mary",
                    LastName = "Wilson",
                    AnnualSalary = 10000,
                    IsManager = false,
                    DepartmentId = 3
                }
            };
        }

        public static List<Department> GetDepartments()
        {
            return new List<Department>
            {
                new Department
                {
                    Id = 1,
                    ShortName = "HR",
                    LongName = "Human Resources"
                },
                new Department
                {
                    Id = 2,
                    ShortName = "IT",
                    LongName = "Information Technology"
                },
                new Department
                {
                    Id = 3,
                    ShortName = "FN",
                    LongName = "Finance"
                }
            };
        }
    }
}
