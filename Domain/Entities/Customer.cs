using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain;

public class Customer:Entity
{

    public string Name { get; set; }
    public int Balance { get; set; }
    public User User { get; set; }
    
    public int UserId { get; set; } 

}
