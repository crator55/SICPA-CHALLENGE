using Microsoft.AspNetCore.Mvc;
using SICPA.Classes;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace SICPA.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Status { get; set; }

    public string? Age { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? Position { get; set; }

    public string? Surname { get; set; }

    public virtual ICollection<DepartmentsEmployee> DepartmentsEmployees { get; } = new List<DepartmentsEmployee>();

    public List<EmployeeCLS> ListEmployee()
    {
        List<EmployeeCLS> list = new();
        using SicpaContext bd = new();
        list = (from EmployeeCLS in bd.Employees
                select new EmployeeCLS()
                {
                    Id = EmployeeCLS.Id,
                    Status = EmployeeCLS.Status.ToString(),
                    Age = EmployeeCLS.Age,
                    Email = EmployeeCLS.Email,
                    Name = EmployeeCLS.Name,
                    Position = EmployeeCLS.Position,
                    Surname = EmployeeCLS.Surname,
                }).ToList();
        return list;
    }
    public EmployeeCLS OneEmployee(int id)
    {
        EmployeeCLS Employee = new();
        using SicpaContext bd = new();
        Employee = (
                from EmployeeCLS in bd.Employees
                where EmployeeCLS.Id == id
                select new EmployeeCLS()
                {
                    Id = EmployeeCLS.Id,
                    Status = EmployeeCLS.Status.ToString(),
                    Age = EmployeeCLS.Age,
                    Email = EmployeeCLS.Email,
                    Name = EmployeeCLS.Name,
                    Position = EmployeeCLS.Position,
                    Surname = EmployeeCLS.Surname
                }).FirstOrDefault();
        return Employee;
    }
    public bool SaveEmployee(EmployeeCLS EmployeeCLS)
    {
        using SicpaContext bd = new();
        Employee oEmployee = new()
        {
            Status = bool.Parse(EmployeeCLS.Status),
            Age = EmployeeCLS.Age,
            Email = EmployeeCLS.Email,
            Name = EmployeeCLS.Name,
            Position = EmployeeCLS.Position,
            Surname = EmployeeCLS.Surname,
            CreatedDate = DateTime.Now
        };
        bd.Add(oEmployee);
        bd.SaveChanges();
        return true;
    }
    public bool EditEmployee(EmployeeCLS EmployeeCLS, int id)
    {
        using SicpaContext bd = new();
        Employee oEmployee = new()
        {
            Id = id
        };
        bd.Attach(oEmployee);
        oEmployee.Status = bool.Parse(EmployeeCLS.Status);
        oEmployee.Age = EmployeeCLS.Age;
        oEmployee.Email = EmployeeCLS.Email;
        oEmployee.Name = EmployeeCLS.Name;
        oEmployee.Position = EmployeeCLS.Name;
        oEmployee.Surname = EmployeeCLS.Surname;
        oEmployee.ModifiedDate = DateTime.Now;
        bd.SaveChanges();
        return true;
    }
    public bool DeleteEmployee(int id)
    {
        using SicpaContext bd = new();
        Employee oEmployee = new()
        {
            Id = id
        };
        bd.Attach(oEmployee);
        bd.Employees.Attach(oEmployee);
        bd.Employees.Remove(oEmployee);
        bd.SaveChanges();
        return true;
    }
}
