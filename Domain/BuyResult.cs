using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain;

public class BuyResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}
