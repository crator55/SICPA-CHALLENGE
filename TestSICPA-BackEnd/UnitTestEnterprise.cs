using SICPA.Classes;
using SICPA.Models;
using TestSICPA_BackEnd.Cases;

namespace TestSICPA_BackEnd
{
    public class UnitTestEnterprise
    {
        private readonly Enterprise enterprise = new();
        [Fact]
        public void ListEnterprise_GetList_CountMoreThan0()
        {
          var res=  enterprise.ListEnterprise();
            Assert.True(res.Count>0);
        }
        [Fact]
        public void GetOneEnterprise_GetList_CountMoreThan0()
        {
            var enterpriseCLS= EnterpriseTest.GetDataTest();
            enterprise.SaveEnterprise(enterpriseCLS);
            var res = enterprise.OneEnterprise(enterpriseCLS.Id);
            Assert.True(res != null);
            enterprise.DeleteEnterprise(enterpriseCLS.Id);
        }
        [Fact]
        public void SaveEnterprise_Save_Succesfull()
        {
            var enterpriseCLS = EnterpriseTest.GetDataTest();
            var res= enterprise.SaveEnterprise(enterpriseCLS);
            Assert.True(res);
            enterprise.DeleteEnterprise(enterpriseCLS.Id);
        }
        [Fact]
        public void EditEnterprise_EditData_Succesfull()
        {
            var enterpriseCLS = EnterpriseTest.GetDataTest();
            enterprise.SaveEnterprise(enterpriseCLS);
            enterpriseCLS.Name = "OtherTest";
            enterprise.EditEnterprise(enterpriseCLS,enterpriseCLS.Id);
            var resul = enterprise.OneEnterprise(enterpriseCLS.Id);
            Assert.Equal(resul.Name.TrimEnd(),enterpriseCLS.Name);
            enterprise.DeleteEnterprise(enterpriseCLS.Id);
        }
        [Fact]
        public void DeleteEnterprise_DeleteData_Succesfull()
        {
            var enterpriseCLS = EnterpriseTest.GetDataTest();
            enterprise.SaveEnterprise(enterpriseCLS);
            enterprise.DeleteEnterprise(enterpriseCLS.Id);
            var resul = enterprise.OneEnterprise(enterpriseCLS.Id);
            Assert.True(resul== null);
        }
    }
    
}