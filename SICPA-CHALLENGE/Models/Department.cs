using Microsoft.AspNetCore.Mvc;
using SICPA.Classes;
using SICPA_CHALLENGE.Models;
using System.Reflection.Metadata.Ecma335;

namespace SICPA.Models;

public partial class Department : IDepartment
{
    public int Id { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Status { get; set; }

    public string? Description { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public int IdEnterprise { get; set; }

    public virtual ICollection<DepartmentsEmployee> DepartmentsEmployees { get; } = new List<DepartmentsEmployee>();

    public virtual Enterprise? IdEnterpriseNavigation { get; set; }

    public List<DepartmentCLS> GetDepartments()
    {
        List<DepartmentCLS> list = new();
        using SicpaContext bd = new();
        list = (from DepartmentCLS in bd.Departments
                join Enterp in bd.Enterprises
                on DepartmentCLS.IdEnterprise equals Enterp.Id
                select new DepartmentCLS()
                {
                    Id = DepartmentCLS.Id,
                    Status = DepartmentCLS.Status.ToString(),
                    Description = DepartmentCLS.Description,
                    Name = DepartmentCLS.Name,
                    Phone = DepartmentCLS.Phone,
                    EnterpriseName = Enterp.Name
                }).ToList();
        return list;
    }
    public DepartmentCLS OneDepartment(int id)
    {
        DepartmentCLS department = new();
        using SicpaContext bd = new();
        department = (
                from DepartmentCLS in bd.Departments
                join Enterp in bd.Enterprises
                on DepartmentCLS.IdEnterprise equals Enterp.Id
                where DepartmentCLS.Id == id
                select new DepartmentCLS()
                {
                    Id = DepartmentCLS.Id,
                    Status = DepartmentCLS.Status.ToString(),
                    Description = DepartmentCLS.Description,
                    Name = DepartmentCLS.Name,
                    Phone = DepartmentCLS.Phone,
                    EnterpriseName = Enterp.Name
                }).FirstOrDefault();
        return department;
    }

    public bool SaveDepartment(DepartmentCLS departmentCLS)
    {
        using SicpaContext bd = new();
        Department odepartment = new()
        {
            Status = bool.Parse(departmentCLS.Status),
            Description = departmentCLS.Description,
            Name = departmentCLS.Name,
            Phone = departmentCLS.Phone,
            IdEnterprise = int.Parse(departmentCLS.EnterpriseName),
            CreatedDate = DateTime.Now,
        };
        bd.Add(odepartment);
        bd.SaveChanges();
        return true;
    }
    public bool EditDepartment(DepartmentCLS departmentCLS, int id)
    {
        using SicpaContext bd = new();
        Department odepartment = new()
        {
            Id = id
        };
        bd.Attach(odepartment);
        odepartment.Status = bool.Parse(departmentCLS.Status);
        odepartment.Description = departmentCLS.Description;
        odepartment.Name = departmentCLS.Name;
        odepartment.Phone = departmentCLS.Phone;
        odepartment.IdEnterprise = int.Parse(departmentCLS.EnterpriseName);
        odepartment.ModifiedDate = DateTime.Now;
        bd.SaveChanges();
        return true;
    }

    public bool DeleteDepartment(int id)
    {
        using SicpaContext bd = new();
        Department odepartment = new()
        {
            Id = id,
            IdEnterprise = 1
        };
        bd.Attach(odepartment);
        bd.Departments.Attach(odepartment);
        bd.Departments.Remove(odepartment);
        bd.SaveChanges();
        return true;
    }

}
