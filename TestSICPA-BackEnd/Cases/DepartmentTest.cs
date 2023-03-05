using SICPA.Classes;
using SICPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSICPA_BackEnd.Cases
{
    public class DepartmentTest
    {
        public DepartmentTest() {
            this.Status = "true";
            this.Description = "DescriptionTest";
            this.Name= "NameTest";
            this.Phone= "PhoneTest";
            this.EnterpriseName = "5";
        }
        public int Id { get; set; }
        public string? Status { get; set; }

        public string? Description { get; set; }

        public string? Name { get; set; }

        public string? Phone { get; set; }
        public string? EnterpriseName { get; set; }
        public static DepartmentCLS GetDataTest()
        {
            DepartmentTest test = new();
            Enterprise et= new ();
            EnterpriseCLS enterpriseCLS = new()
            {
                Status = "true",
                Address = "AddressTest",
                Name= "NameTest",
                Phone= "PhoneTest"
            };
            et.SaveEnterprise( enterpriseCLS );
            DepartmentCLS departmentCLS = new()
            {
                Id = GetMaxIntDepartments(),
                Status = test.Status,
                Description = test.Description,
                Name = test.Name,
                EnterpriseName = GetMaxIntEnterprise().ToString(),
                Phone = test.Phone,
            };
            return departmentCLS;
        }
        private static int GetMaxIntDepartments()
        {
            using SicpaContext bd = new();
            return bd.Departments.Max(x => x.Id);
        }
        private static int GetMaxIntEnterprise()
        {
            using SicpaContext bd = new();
            return bd.Enterprises.Max(x => x.Id);
        }
    }
}
