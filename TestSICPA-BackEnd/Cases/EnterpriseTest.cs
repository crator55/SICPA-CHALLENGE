using SICPA.Classes;
using SICPA.Models;

namespace TestSICPA_BackEnd.Cases
{
    public class EnterpriseTest
    {
        public EnterpriseTest()
        {
            this.Status = "true";
            this.Address = "AddressTest";
            this.Name = "NameTest";
            this.Phone = "PhoneTest";
        }
        public int? Id { get; set; }
        public string? Status { get; set; }

        public string? Address { get; set; }

        public string? Name { get; set; }

        public string? Phone { get; set; }
        public static EnterpriseCLS GetDataTest()
        {
            EnterpriseTest test = new();

            EnterpriseCLS enterpriseCLS = new()
            {
                Id = GetMaxIntEmployees(),
                Status = test.Status,
                Address = test.Address,
                Name = test.Name,
                Phone = test.Phone,
            };
            return enterpriseCLS;
        }

        private static int GetMaxIntEmployees()
        {
            using SicpaContext bd = new();
            return bd.Enterprises.Max(x => x.Id);
        }
    }
}
