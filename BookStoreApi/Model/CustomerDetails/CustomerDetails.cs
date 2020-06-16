namespace BookStoreModelLayer.CustomerDetails
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Code for Customer Details
    /// </summary>
    public class CustomerDetails
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public int PinCode { get; set; }

        public string Locality { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Landmark { get; set; }

        public string Type { get; set; }
    }
}
