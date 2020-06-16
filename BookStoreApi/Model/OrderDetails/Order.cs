namespace BookStoreModelLayer.OrderDetails
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Code for order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        /// <value>
        /// The customer email.
        /// </value>
        public string CustomerEmail { get; set; }

    }
}
