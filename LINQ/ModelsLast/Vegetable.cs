using System;
using System.Collections.Generic;

namespace LINQ.Models;

public partial class Vegetable
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Count { get; set; }

    public int? Price { get; set; }
}
