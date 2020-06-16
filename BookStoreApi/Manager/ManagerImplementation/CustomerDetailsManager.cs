namespace BookStoreManagerLayer.ManagerImplementation
{
    using BookStoreManagerLayer.ManagerInterface;
    using BookStoreModelLayer.CustomerDetails;
    using BookStoreRepositoryLayer.RepositoryInterface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Code for Customer Details Manager Implementation
    /// </summary>
    public class CustomerDetailsManager : ICustomerDetailsManager
    {
        private readonly ICustomerDetailsRepository repository;

        public CustomerDetailsManager(ICustomerDetailsRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adds the customer details.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int> AddCustomerDetails(CustomerDetails model)
        {
            return await this.repository.AddCustomerDetails(model);
        }

        /// <summary>
        /// Deletes the customer details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<int> DeleteCustomerDetails(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public CustomerDetails GetCustomer(string email, string type)
        {
            return this.repository.GetCustomer(email, type);
        }
    }
}
