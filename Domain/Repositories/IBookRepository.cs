namespace Domain;







public interface IBookRepository:IRepository<Book>
{
    Book? GetDetail(int id);
    BuyResult Buy(int customerId, int bookId, int quantity);

}
