using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.ManagerInterface;
using BookStoreModelLayer.CustomerDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly ICustomerDetailsManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDetailsController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public CustomerDetailsController(ICustomerDetailsManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Adds the customer detail.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCustomerDetail([FromBody] CustomerDetails model)
        {
            var result = await this.manager.AddCustomerDetails(model);
            if (result != 0)
            {
                return this.Ok(new { Succeeded = true });
            }

            return this.BadRequest(new { Succeeded = false });
        }

        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomer([FromQuery] string email,[FromQuery] string type)
        {
            var result = this.manager.GetCustomer(email,type);
            if (result != null)
            {
                return this.Ok(result);
            }

            return this.BadRequest(new { Succeeded = false });
        }
    }
}