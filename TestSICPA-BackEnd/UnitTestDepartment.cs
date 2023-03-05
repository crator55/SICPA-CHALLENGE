using SICPA.Classes;
using SICPA.Models;
using TestSICPA_BackEnd.Cases;

namespace TestSICPA_BackEnd
{
    public class UnitTestDepartment
    {
        private readonly Department department = new();
        private readonly Enterprise enterprise = new Enterprise();
        [Fact]
        public void ListDepartment_GetList_CountMoreThan0()
        {
          var res=  department.GetDepartments();
            Assert.True(res.Count>0);
        }
        [Fact]
        public void GetOneDepartment_GetList_CountMoreThan0()
        {
            var departmentCLS= DepartmentTest.GetDataTest();
            department.SaveDepartment(departmentCLS);
            var res = department.OneDepartment(departmentCLS.Id);
            Assert.True(res != null);
            department.DeleteDepartment(departmentCLS.Id);
            enterprise.DeleteEnterprise(int.Parse(departmentCLS.EnterpriseName));
        }
        [Fact]
        public void SaveDepartment_Save_Succesfull()
        {
            var departmentCLS = DepartmentTest.GetDataTest();
            var res= department.SaveDepartment(departmentCLS);
            Assert.True(res);
            department.DeleteDepartment(departmentCLS.Id);
            enterprise.DeleteEnterprise(int.Parse(departmentCLS.EnterpriseName));
        }
        [Fact]
        public void EditDepartment_EditData_Succesfull()
        {
            var departmentCLS = DepartmentTest.GetDataTest();
            department.SaveDepartment(departmentCLS);
            departmentCLS.Name = "OtherTest";
            department.EditDepartment(departmentCLS,departmentCLS.Id);
            var resul = department.OneDepartment(departmentCLS.Id);
            Assert.Equal(resul.Name.TrimEnd(),departmentCLS.Name);
            department.DeleteDepartment(departmentCLS.Id);
            enterprise.DeleteEnterprise(int.Parse(departmentCLS.EnterpriseName));
        }
        [Fact]
        public void DeleteDepartment_DeleteData_Succesfull()
        {
            var departmentCLS = DepartmentTest.GetDataTest();
            department.SaveDepartment(departmentCLS);
            department.DeleteDepartment(departmentCLS.Id);
            var resul = department.OneDepartment(departmentCLS.Id);
            Assert.True(resul== null);
          
            enterprise.DeleteEnterprise(int.Parse(departmentCLS.EnterpriseName));
        }
    }
    
}