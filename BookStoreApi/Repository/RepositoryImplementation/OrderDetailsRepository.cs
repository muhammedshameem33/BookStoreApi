namespace BookStoreRepositoryLayer.RepositoryImplementation
{
    using BookStoreModelLayer.OrderDetails;
    using BookStoreRepositoryLayer.DbContext;
    using BookStoreRepositoryLayer.RepositoryInterface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq;

    /// <summary>
    /// Code for Order details Repository
    /// </summary>
    /// <seealso cref="BookStoreRepositoryLayer.RepositoryInterface.IOrderDetailsRepository" />
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly UserDbContext context;

        /// <summary>
        /// The cart repository
        /// </summary>
        private readonly ICartRepository cartRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailsRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public OrderDetailsRepository(UserDbContext context,ICartRepository cartRepository)
        {
            this.context = context;
            this.cartRepository = cartRepository;
        }

        /// <summary>
        /// Adds the order detail.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int> AddOrderDetail(List<OrderDetails> model)
        {
            //order table
            var order = new Order();
            order.CustomerEmail = model[0].CustomerEmail;
            await this.context.GetOrders.AddAsync(order);
            await this.context.SaveChangesAsync();
            var rowsEffected = 0;
            order = this.context.GetOrders.LastOrDefault();

            foreach (var item in model)
            {
                //order detail table
                item.OrderId = order.Id;
                await this.context.OrderDetails.AddAsync(item);
                rowsEffected = await this.context.SaveChangesAsync();
                //update book
                var book = await this.context.Books.FindAsync(item.BookId);
                var previousBook = book;
                if (book.TotalNumberOfBooks >= item.Quantity)
                {
                    book.TotalNumberOfBooks = book.TotalNumberOfBooks - item.Quantity;
                    this.context.Entry(previousBook).CurrentValues.SetValues(book);
                }

                //delete cart
                await this.cartRepository.DeleteBookFromCart(item.BookId);
            }

            return rowsEffected;
        }

        public IEnumerable<Object> GetOrderInfo(string email)
        {
            var result = (from book in this.context.Books
                          join order in this.context.OrderDetails.Where(x => x.CustomerEmail.Equals(email)) on book.Id equals order.BookId
                          orderby book.Id
                          select new
                          {
                              order.OrderId,
                              order.BookId,
                              book.BookName,
                              book.BookDetail,
                              book.Price,
                              book.Auther,
                              book.CoverPhoto,
                              order.Quantity
                          }
                        ).ToList();

            return result;
        }
    }


}
