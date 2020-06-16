namespace BookStoreManagerLayer.ManagerInterface
{
    using BookStoreModelLayer.Book;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Code for manager interface
    /// </summary>
    public interface IBookManager
    {
        /// <summary>
        /// Adds the books.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<int> AddBooks(AddBookModel model);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> Delete(int id);

        /// <summary>
        /// Gets the book.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Book GetBook(int id);

        /// <summary>
        /// Gets the books.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Book> GetBooks();
    }
}