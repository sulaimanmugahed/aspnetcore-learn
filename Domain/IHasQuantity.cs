using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain;

public interface IHasQuantity
{
    int Quantity { get; set; }
}
