using System;
using System.Collections.Generic;

namespace LINQ.Models;

public partial class Group
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long? Level { get; set; }
}
