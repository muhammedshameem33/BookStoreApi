namespace BookStoreManagerLayer.ManagerImplementation
{
    using BookStoreManagerLayer.ManagerInterface;
    using BookStoreModelLayer.Cart;
    using BookStoreRepositoryLayer.RepositoryInterface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Code for Cart Manager Implementation
    /// </summary>
    public class CartManager : ICartManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ICartRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CartManager(ICartRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adds the book to cart.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int> AddBookToCart(Cart model)
        {
            return await this.repository.AddBookToCart(model);
        }

        /// <summary>
        /// Deletes the book from cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<int> DeleteBookFromCart(int id)
        {
            return await this.repository.DeleteBookFromCart(id);
        }

        /// <summary>
        /// Gets all book from cart.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> GetAllBookFromCart(string email)
        {
            return this.repository.GetAllBookFromCart(email);
        }

        /// <summary>
        /// Updates the cart.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int> UpdateCart(List<Cart> model)
        {
            return await this.repository.UpdateCart(model);
        }
    }
}
