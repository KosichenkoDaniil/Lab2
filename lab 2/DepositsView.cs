using System;
using System.Collections.Generic;

namespace lab_2;

public partial class DepositsView
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Term { get; set; }

    public decimal Mindepositamount { get; set; }

    public int Currencyid { get; set; }

    public decimal Rate { get; set; }

    public string? Additionalconditions { get; set; }
}
