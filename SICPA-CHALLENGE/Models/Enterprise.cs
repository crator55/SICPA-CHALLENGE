using SICPA.Classes;

namespace SICPA.Models;

public partial class Enterprise
{
    public int Id { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Status { get; set; }

    public string? Address { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Department> Departments { get; } = new List<Department>();
    public List<EnterpriseCLS> ListEnterprise()
    {
        List<EnterpriseCLS> list = new();
        using SicpaContext bd = new();
        list = (from EnterprisesCLS in bd.Enterprises
                select new EnterpriseCLS()
                {
                    Id = EnterprisesCLS.Id,
                    Status = EnterprisesCLS.Status.ToString(),
                    Address = EnterprisesCLS.Address,
                    Name = EnterprisesCLS.Name,
                    Phone = EnterprisesCLS.Phone
                }).ToList();
        return list;
    }
    public EnterpriseCLS OneEnterprise(int id)
    {
        EnterpriseCLS Enterprise = new();
        using SicpaContext bd = new();
        Enterprise = (
                from EnterprisesCLS in bd.Enterprises
                where EnterprisesCLS.Id == id
                select new EnterpriseCLS()
                {
                    Id = EnterprisesCLS.Id,
                    Status = EnterprisesCLS.Status.ToString(),
                    Address = EnterprisesCLS.Address,
                    Name = EnterprisesCLS.Name,
                    Phone = EnterprisesCLS.Phone
                }).FirstOrDefault();
        return Enterprise;
    }
    public bool SaveEnterprise(EnterpriseCLS EnterpriseCLS)
    {
        using SicpaContext bd = new();
        Enterprise oEnterprise = new()
        {
            Status = bool.Parse(EnterpriseCLS.Status),
            Address = EnterpriseCLS.Address,
            Name = EnterpriseCLS.Name,
            Phone = EnterpriseCLS.Phone,
            CreatedDate = DateTime.Now,
        };
        bd.Add(oEnterprise);
        bd.SaveChanges();
        return true;
    }
    public bool EditEnterprise(EnterpriseCLS EnterpriseCLS, int id)
    {
        using SicpaContext bd = new();
        Enterprise oEnterprise = new()
        {
            Id = id
        };
        bd.Attach(oEnterprise);
        oEnterprise.Status = bool.Parse(EnterpriseCLS.Status);
        oEnterprise.Address = EnterpriseCLS.Address;
        oEnterprise.Name = EnterpriseCLS.Name;
        oEnterprise.Phone = EnterpriseCLS.Phone;
        oEnterprise.ModifiedDate = DateTime.Now;
        bd.SaveChanges();
        return true;
    }
    public bool DeleteEnterprise(int id)
    {
        using SicpaContext bd = new();
        Enterprise oEnterprise = new()
        {
            Id = id
        };
        bd.Attach(oEnterprise);
        bd.Enterprises.Attach(oEnterprise);
        bd.Enterprises.Remove(oEnterprise);
        bd.SaveChanges();
        return true;
    }
}
