namespace BookStoreModelLayer.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Microsoft.AspNetCore.Identity;


    /// <summary>
    /// code for user model
    /// </summary>
    /// <seealso cref="IdentityUser" />
    public class Users : IdentityUser
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address for this user.
        /// </summary>
        [Key]
        public override string Email { get; set; }
    }
}
