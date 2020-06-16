namespace BookStoreManagerLayer.ManagerImplementation
{
    using BookStoreManagerLayer.ManagerInterface;
    using BookStoreModelLayer.OrderDetails;
    using BookStoreRepositoryLayer.RepositoryInterface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Code for Order Detail Manager
    /// </summary>
    /// <seealso cref="BookStoreManagerLayer.ManagerInterface.IOrderDetailsManager" />
    public class OrderDetailsManager : IOrderDetailsManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IOrderDetailsRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailsManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public OrderDetailsManager(IOrderDetailsRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adds the order detail.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int> AddOrderDetail(List<OrderDetails> model)
        {
            return await this.repository.AddOrderDetail(model);
        }

        /// <summary>
        /// Gets the order information.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public IEnumerable<object> GetOrderInfo(string email)
        {
            return this.repository.GetOrderInfo(email);
        }
    }
}
