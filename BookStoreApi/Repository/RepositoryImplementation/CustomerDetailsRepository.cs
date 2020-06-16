namespace BookStoreRepositoryLayer.RepositoryImplementation
{
    using BookStoreModelLayer.CustomerDetails;
    using BookStoreRepositoryLayer.DbContext;
    using BookStoreRepositoryLayer.RepositoryInterface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Code for Customer details implementation
    /// </summary>
    /// <seealso cref="BookStoreRepositoryLayer.RepositoryInterface.ICustomerDetailsRepository" />
    public class CustomerDetailsRepository : ICustomerDetailsRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly UserDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDetailsRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CustomerDetailsRepository(UserDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds the customer details.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int> AddCustomerDetails(CustomerDetails model)
        {
            await this.context.CustomerDetail.AddAsync(model);
            return await this.context.SaveChangesAsync();
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
            return this.context.CustomerDetail.Where(x=>x.Email.Equals(email) && x.Type.Equals(type)).FirstOrDefault();
        }
    }
}
