using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SICPA.Models;

public partial class Department
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
}
