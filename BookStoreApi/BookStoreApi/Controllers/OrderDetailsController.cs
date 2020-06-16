using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.ManagerInterface;
using BookStoreModelLayer.OrderDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly IOrderDetailsManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailsController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public OrderDetailsController(IOrderDetailsManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderInfo([FromBody] List<OrderDetails> model)
        {
            var result = await this.manager.AddOrderDetail(model);
            if (result != 0)
            {
                return this.Ok(new { succeeded = true });
            }

            return this.BadRequest(new { succeeded = false });
        }

        [HttpGet]
        public IActionResult GetOrderDetails([FromQuery] string email)
        {
            var result = this.manager.GetOrderInfo(email);

            if (result != null)
            {
                return this.Ok(result);
            }

            return this.BadRequest(new { succeeded = false });

        }
    }
}