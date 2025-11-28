using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain;

public static class Extensions
{
    public static bool IsBalanceLessThan(this Customer customer, int amount)
    {
        return customer.Balance < amount;
    }
    public static void DecreaseQuantity(this IHasQuantity entity, int quantity)
    {
        entity.Quantity -= quantity;

    }
}
