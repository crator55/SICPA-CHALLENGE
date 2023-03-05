using System;
using System.Collections.Generic;

namespace SICPA.Models;

public partial class DepartmentsEmployee
{
    public int Id { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Status { get; set; }

    public int? IdDepartment { get; set; }

    public int? IdEmployee { get; set; }

    public virtual Department? IdDepartmentNavigation { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }
}
