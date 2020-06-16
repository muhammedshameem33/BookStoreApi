namespace BookStoreManagerLayer.ManagerImplementation
{
    using BookStoreManagerLayer.ManagerInterface;
    using BookStoreModelLayer.Book;
    using BookStoreRepositoryLayer.RepositoryInterface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// manager code for Book
    /// </summary>
    public class BookManager : IBookManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IBookRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public BookManager(IBookRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets the books.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> GetBooks()
        {
            return this.repository.GetBooks();
        }

        /// <summary>
        /// Adds the books.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int> AddBooks(AddBookModel model)
        {
            return await this.repository.AddBooks(model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<int> Delete(int id)
        {
            return await this.Delete(id);
        }

        public Book GetBook(int id)
        {
            return this.repository.GetBook(id);
        }
    }
}
