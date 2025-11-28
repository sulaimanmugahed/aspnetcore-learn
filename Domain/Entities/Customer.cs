using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Balance { get; set; }
    public User User { get; set; }
    
    public int UserId { get; set; } 

}
