namespace BookStoreRepositoryLayer.RepositoryImplementation
{
    using AutoMapper;
    using BookStoreModelLayer.Book;
    using BookStoreRepositoryLayer.DbContext;
    using BookStoreRepositoryLayer.RepositoryInterface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Data Access Layer for book
    /// </summary>
    public class BookRepository : IBookRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly UserDbContext context;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public BookRepository(UserDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the books.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> GetBooks()
        {
            return context.Books.ToList();
        }

        /// <summary>
        /// Adds the books.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int> AddBooks(AddBookModel model)
        {
            var book = new Book();
            book = mapper.Map<AddBookModel, Book>(model);
            await context.Books.AddAsync(book);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<int> Delete(int id)
        {
            var result = await context.Books.FindAsync(id);
            if (result != null)
            {
                context.Books.Remove(result);
            }

            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets the book.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Book GetBook(int id)
        {
            var result = context.Books.ToList();
            return result.Where(i => i.Id.Equals(id)).FirstOrDefault();
        }
    }
}
