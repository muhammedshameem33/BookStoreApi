namespace BookStoreManagerLayer.ManagerInterface
{
    using BookStoreModelLayer.Cart;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for Cart Manager
    /// </summary>
    public interface ICartManager
    {
        /// <summary>
        /// Adds the book to cart.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<int> AddBookToCart(Cart model);

        /// <summary>
        /// Deletes the book from cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteBookFromCart(int id);

        /// <summary>
        /// Gets all book from cart.
        /// </summary>
        /// <returns></returns>
        IEnumerable<object> GetAllBookFromCart(string email);


        /// <summary>
        /// Updates the cart.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<int> UpdateCart(List<Cart> model);
    }
}

