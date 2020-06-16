namespace BookStoreModelLayer.Book
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Code for Book Model
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the book.
        /// </summary>
        /// <value>
        /// The name of the book.
        /// </value>
        public string BookName { get; set; }

        /// <summary>
        /// Gets or sets the book detail.
        /// </summary>
        /// <value>
        /// The book detail.
        /// </value>
        public string BookDetail { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the total number of books.
        /// </summary>
        /// <value>
        /// The total number of books.
        /// </value>
        public int TotalNumberOfBooks { get; set; }

        /// <summary>
        /// Gets or sets the auther.
        /// </summary>
        /// <value>
        /// The auther.
        /// </value>
        public string Auther { get; set; }

        /// <summary>
        /// Gets or sets the cover photo.
        /// </summary>
        /// <value>
        /// The cover photo.
        /// </value>
        public string CoverPhoto { get; set; }

    }
}
