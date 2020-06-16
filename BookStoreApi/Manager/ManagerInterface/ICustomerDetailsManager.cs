namespace BookStoreManagerLayer.ManagerInterface
{
    using BookStoreModelLayer.CustomerDetails;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for Customer details
    /// </summary>
    public interface ICustomerDetailsManager
    {
        /// <summary>
        /// Adds the customer details.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<int> AddCustomerDetails(CustomerDetails model);

        /// <summary>
        /// Deletes the customer details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteCustomerDetails(int id);

        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        CustomerDetails GetCustomer(string email, string type);
    }
}
