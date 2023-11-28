using System;
using System.Collections.Generic;

namespace lab_2;

public partial class EmployeesBornBefore1993
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Middlename { get; set; } = null!;

    public string Post { get; set; } = null!;

    public DateTime Dob { get; set; }
}
