using System;
using System.Collections.Generic;

namespace lab_2;

public partial class InvestorsView
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Middlename { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public string PassportId { get; set; } = null!;
}
