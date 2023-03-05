using SICPA.Classes;
using SICPA.Models;

namespace TestSICPA_BackEnd.Cases
{
    public class EmployeeTest
    {
        public EmployeeTest()
        {
            this.Status = "true";
            this.Age = "DescriptionTest";
            this.Name = "NameTest";
            this.Email = "EmailTest";
            this.Position = "PositionTest";
            this.Surname = "SurnameTest";
        }
        public int Id { get; set; }
        public string? Status { get; set; }

        public string? Age { get; set; }

        public string? Email { get; set; }

        public string? Name { get; set; }

        public string? Position { get; set; }

        public string? Surname { get; set; }
        public static EmployeeCLS GetDataTest()
        {
            EmployeeTest test = new();

            EmployeeCLS employeeCLS = new()
            {
                Id = GetMaxIntEmployees(),
                Status = test.Status,
                Age = test.Age,
                Name = test.Name,
                Email = test.Email,
                Position = test.Position,
                Surname = test.Surname,

            };
            return employeeCLS;
        }

        private static int GetMaxIntEmployees()
        {
            using SicpaContext bd = new();
            return bd.Employees.Max(x => x.Id);
        }
    }
}
