using System;
using System.Collections.Generic;

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
}
