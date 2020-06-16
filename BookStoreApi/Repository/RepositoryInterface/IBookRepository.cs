using BookStoreModelLayer.Book;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.RepositoryInterface
{
    public interface IBookRepository
    {
        Task<int> AddBooks(AddBookModel model);
        Task<int> Delete(int id);
        Book GetBook(int id);
        IEnumerable<Book> GetBooks();
    }
}