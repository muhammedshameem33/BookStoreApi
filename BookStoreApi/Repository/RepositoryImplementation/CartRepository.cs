namespace BookStoreRepositoryLayer.RepositoryImplementation
{
    using BookStoreModelLayer.Book;
    using BookStoreModelLayer.Cart;
    using BookStoreRepositoryLayer.DbContext;
    using BookStoreRepositoryLayer.RepositoryInterface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Code for Cart Repository
    /// </summary>
    public class CartRepository : ICartRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly UserDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CartRepository(UserDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds the book to cart.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int> AddBookToCart(Cart model)
        {
            await this.context.Carts.AddAsync(model);
            return await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the book from cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<int> DeleteBookFromCart(int id)
        {
            var result = this.context.Carts.Where(x=>x.BookId.Equals(id)).FirstOrDefault();
            if (result != null)
            {
                this.context.Remove(result);
            }

            return await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all book from cart.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IEnumerable<Object> GetAllBookFromCart(string email)
        {
            var result = (from book in this.context.Books
                          join cart in this.context.Carts.Where(x=>x.CustomerEmail.Equals(email)) on book.Id equals cart.BookId 
                          orderby book.Id
                          select new
                          {
                              cart.CartId,
                              cart.BookId,
                              book.BookName,
                              book.BookDetail,
                              book.Price,
                              book.TotalNumberOfBooks,
                              book.Auther,
                              book.CoverPhoto,
                              cart.Quantity
                          }
                        ).ToList();

            return result;
        }

        /// <summary>
        /// Updates the cart.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int> UpdateCart(List<Cart> model)
        {
            var rowsEffected = 0;
            foreach (var item in model)
            {
                var result = await this.context.Carts.FindAsync(item.CartId);
                this.context.Entry(result).CurrentValues.SetValues(item);
                rowsEffected = await this.context.SaveChangesAsync();
            }

            return rowsEffected;
        }
    }
}
