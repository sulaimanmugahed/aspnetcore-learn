// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Domain;

// namespace Data;



// public class MemoryDatabase : IDatabase
// {
//     private readonly List<Book> _books;
//     private readonly List<Pen> _pens;

//     private readonly List<Author> _authors;
//     private readonly List<User> _users;
//     private readonly List<Customer> _customers = [];


//     public MemoryDatabase()
//     {
//         _books = [
//             new Book(1,"book1",1000,10),
//             new Book(2,"book2",3000,0),
//             new Book(3,"book3",6000,10),
//             new Book(4,"book4",5000,10),
//             new Book(5,"book5",1000,10)
//         ];

//         _pens = [
//       new Pen(1,"pen1",200,10),
//             new Pen(2,"pen2",500,0)
//   ];
//         _authors = [
//            new Author(1,"author"),
//             new Author(2,"author2"),

//         ];
//         _users = [

//             new User(){
//                 Id=1,
//               UserName ="a",
//              Password ="12"

//             },
//             new User(){
//                 Id=2,
//               UserName ="b",
//              Password ="22"

//             }


//         ];

//     }

//     public List<Book> GetAllBooks()
//     {
//         return _books;
//     }

//     public Book? GetBook(int id)
//     {
//         return _books.FirstOrDefault(x => x.Id == id);
//     }

//     public void DeleteBook(int id)
//     {
//         var book = _books.FirstOrDefault(x => x.Id == id);
//         if (book is not null)
//         {
//             _books.Remove(book);

//         }
//     }

//     public List<Author> GetAllAuthors()
//     {
//         return _authors;
//     }

//     public Author? GetAuthor(int id)
//     {
//         return _authors.FirstOrDefault(a => a.Id == id);

//     }

//     public void DeleteAuthor(int id)
//     {
//         var author = _authors.FirstOrDefault(a => a.Id == id);
//         if (author != null)
//         {
//             _authors.Remove(author);
//         }
//     }

//     public List<User> GetUsers()
//     {
//         return _users;
//     }

//     public User? GetUser(int id)
//     {
//         var user = _users.FirstOrDefault(a => a.Id == id);
//         return user;
//     }

//     public void DeleteUser(int id)
//     {
//         var user = _users.FirstOrDefault(a => a.Id == id);
//         if (user is not null)
//         {
//             _users.Remove(user);

//         }
//     }

//     public bool CheckPassword(int id, string password)
//     {
//         var user = _users.FirstOrDefault(a => a.Id == id);
//         if (user is not null && user.Password == password)
//         {
//             return true;
//         }

//         return false;
//     }

//     public void CreateUser(User user)
//     {
//         if (!_users.Any(u => u.Id == user.Id))
//         {
//             _users.Add(user);
//         }

//     }

//     public void CreateCustomer(Customer customer)
//     {
//         if (!_customers.Any(a => a.Id == customer.Id))
//         {

//             _customers.Add(customer);
//         }
//     }

//     public List<Customer> GetCustomers()
//     {
//         return _customers;
//     }

//     public BuyResult BuyBook(int customerId, int bookId, int quantity)
//     {
//         var result = new BuyResult();
//         var customer = _customers.FirstOrDefault(a => a.Id == customerId);
//         if (customer == null)
//         {
//             result.Error = "لا يوجد مشتري بهذا المعرف";
//             return result;
//         }

//         var book = _books.FirstOrDefault(a => a.Id == bookId);
//         if (book == null)
//         {
//             result.Error = "لا يوجد كتاب بهذا المعرف";
//             return result;
//         }

//         var finalPrice = book.Price * quantity;
//         if (customer.IsBalanceLessThan(finalPrice))
//         {
//             result.Error = "رصيد المشتري غير كافي";
//             return result;
//         }
//         if (book.Quantity < quantity)
//         {
//             result.Error = "الكمية المطلوبة غير متوفرة";
//             return result;
//         }

//         book.DecreaseQuantity(quantity);
//         customer.Balance -= finalPrice;

//         result.Success = true;
//         return result;


//     }

//     public List<Pen> GetPens()
//     {
//         return _pens;
//     }

//     public Pen? GetPen(int id)
//     {
//         return _pens.FirstOrDefault(x => x.Id == id);
//     }

//     public BuyResult BuyPen(int customerId, int penId, int quantity)
//     {
//         var result = new BuyResult();
//         var customer = _customers.FirstOrDefault(a => a.Id == customerId);
//         if (customer == null)
//         {
//             result.Error = "لا يوجد مشتري بهذا المعرف";
//             return result;
//         }

//         var pen = _pens.FirstOrDefault(a => a.Id == penId);
//         if (pen == null)
//         {
//             result.Error = "لا يوجد كتاب بهذا المعرف";
//             return result;
//         }

//         var finalPrice = pen.Price * quantity;
//         if (customer.IsBalanceLessThan(finalPrice))
//         {
//             result.Error = "رصيد المشتري غير كافي";
//             return result;
//         }
//         if (pen.Quantity < quantity)
//         {
//             result.Error = "الكمية المطلوبة غير متوفرة";
//             return result;
//         }

//         pen.DecreaseQuantity(quantity);
//         customer.Balance -= finalPrice;

//         result.Success = true;
//         return result;
//     }

//     public void CreateAuthor(Author author)
//     {
//         if (!_authors.Any(x => x.Id == author.Id))
//         {
//             _authors.Add(author);

//         }
//     }

//     public void CreateBook(Book book)
//     {
//         if (!_books.Any(a => a.Id == book.Id))
//         {
//             _books.Add(book);
//         }
//     }

//     public Customer? GetCustomer(int id)
//     {
//         return _customers.FirstOrDefault(a => a.Id == id);
//     }

//     public List<Category> GetCategories()
//     {
//         throw new NotImplementedException();
//     }

//     public void CreateCategory(Category category)
//     {
//         throw new NotImplementedException();
//     }

//     public void DeleteCategory(int id)
//     {
//         throw new NotImplementedException();
//     }

//     public Category? GetCategory(int id)
//     {
//         throw new NotImplementedException();
//     }
// }
