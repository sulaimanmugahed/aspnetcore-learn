using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api;

public class CreateBookDto
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    public List<int> Authors { get; set; } = [];
}
