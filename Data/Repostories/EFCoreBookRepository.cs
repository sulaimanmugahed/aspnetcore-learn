using Domain;
using Microsoft.EntityFrameworkCore;


namespace Data;

public class EFCoreBookRepository(AppDbContext context) : IBookRepository
{


    public Book? GetDetail(int id)
    {
        return context.Books
        .Include(a => a.Category)
        .Include(c => c.Authors)
         .ThenInclude(b => b.Author)
         .FirstOrDefault(a => a.Id == id);
    }



    public BuyResult Buy(int customerId, int bookId, int quantity)
    {
        var result = new BuyResult();
        var customer = context.Customers.FirstOrDefault(a => a.Id == customerId);
        if (customer is null)
        {
            return result;

        }
        var book = context.Books.FirstOrDefault(a => a.Id == bookId);
        if (book is null)
        {
            return result;

        }

        var price = book.Price * quantity;
        if (customer.IsBalanceLessThan(price))
        {
            return result;
        }

        if (book.Quantity < quantity)
        {

            return result;
        }
        book.DecreaseQuantity(quantity);
        customer.Balance -= price;

        context.SaveChanges();


        result.Success = true;
        return result;
    }


}
