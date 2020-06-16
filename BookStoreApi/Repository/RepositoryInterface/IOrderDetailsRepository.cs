using BookStoreModelLayer.OrderDetails;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.RepositoryInterface
{
    /// <summary>
    /// Interface for Order detail repository
    /// </summary>
    public interface IOrderDetailsRepository
    {
        /// <summary>
        /// Adds the order detail.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<int> AddOrderDetail(List<OrderDetails> model);

        /// <summary>
        /// Gets the order information.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        IEnumerable<object> GetOrderInfo(string email);
    }
}
