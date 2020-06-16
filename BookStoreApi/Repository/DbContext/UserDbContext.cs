namespace BookStoreRepositoryLayer.DbContext
{
    using BookStoreModelLayer.Account;
    using BookStoreModelLayer.Book;
    using BookStoreModelLayer.Cart;
    using BookStoreModelLayer.CustomerDetails;
    using BookStoreModelLayer.OrderDetails;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Code for User Database
    /// </summary>
    /// <seealso cref="IdentityDbContext{Users}" />
    public class UserDbContext : IdentityDbContext<Users>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public DbSet<Users> User { get; set; }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>
        /// The books.
        /// </value>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets the carts.
        /// </summary>
        /// <value>
        /// The carts.
        /// </value>
        public DbSet<Cart> Carts { get; set; }

        /// <summary>
        /// Gets or sets the customer detail.
        /// </summary>
        /// <value>
        /// The customer detail.
        /// </value>
        public DbSet<CustomerDetails> CustomerDetail { get; set; }

        /// <summary>
        /// Gets or sets the get orders.
        /// </summary>
        /// <value>
        /// The get orders.
        /// </value>
        public DbSet<Order> GetOrders { get; set; }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>
        /// The order details.
        /// </value>
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
