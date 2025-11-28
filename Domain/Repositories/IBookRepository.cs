namespace Domain;







public interface IBookRepository
{
    Book? GetDetail(int id);
    BuyResult Buy(int customerId, int bookId, int quantity);

}
