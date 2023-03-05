using SICPA.Classes;
using SICPA.Models;
using TestSICPA_BackEnd.Cases;

namespace TestSICPA_BackEnd
{
    public class UnitTestEmployee
    {
        private readonly Employee employee = new();
        [Fact]
        public void ListEmployee_GetList_CountMoreThan0()
        {
          var res=  employee.ListEmployee();
            Assert.True(res.Count>0);
        }
        [Fact]
        public void GetOneEmployee_GetList_CountMoreThan0()
        {
            var employeeCLS= EmployeeTest.GetDataTest();
            employee.SaveEmployee(employeeCLS);
            var res = employee.OneEmployee(employeeCLS.Id);
            Assert.True(res != null);
            employee.DeleteEmployee(employeeCLS.Id);
        }
        [Fact]
        public void SaveEmployee_Save_Succesfull()
        {
            var employeeCLS = EmployeeTest.GetDataTest();
            var res= employee.SaveEmployee(employeeCLS);
            Assert.True(res);
            employee.DeleteEmployee(employeeCLS.Id);
        }
        [Fact]
        public void EditEmployee_EditData_Succesfull()
        {
            var employeeCLS = EmployeeTest.GetDataTest();
            employee.SaveEmployee(employeeCLS);
            employeeCLS.Name = "OtherTest";
            employee.EditEmployee(employeeCLS,employeeCLS.Id);
            var resul = employee.OneEmployee(employeeCLS.Id);
            Assert.Equal(resul.Name.TrimEnd(),employeeCLS.Name);
            employee.DeleteEmployee(employeeCLS.Id);
        }
        [Fact]
        public void DeleteEmployee_DeleteData_Succesfull()
        {
            var employeeCLS = EmployeeTest.GetDataTest();
            employee.SaveEmployee(employeeCLS);
            employee.DeleteEmployee(employeeCLS.Id);
            var resul = employee.OneEmployee(employeeCLS.Id);
            Assert.True(resul== null);
        }
    }
    
}