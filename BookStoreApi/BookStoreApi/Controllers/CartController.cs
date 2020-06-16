    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.ManagerInterface;
using BookStoreModelLayer.Cart;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly ICartManager manager;

        public CartController(ICartManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Adds the book to cart.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddBookToCart([FromBody] Cart model)
        {
            var result = await this.manager.AddBookToCart(model);
            if (result != 0)
            {
                return this.Ok(new { Succeeded = true });
            }

            return this.BadRequest(new { Succeeded = false });
        }

        /// <summary>
        /// Deletes the book from cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBookFromCart(int id)
        {
            var result = await this.manager.DeleteBookFromCart(id);
            if (result != 0)
            {
                return this.Ok(new { Succeeded = true });
            }

            return this.BadRequest(new { Succeeded = false });
        }

        [HttpGet]
        public IActionResult GetAllCartBook([FromQuery] string email)
        {
            var result = this.manager.GetAllBookFromCart(email);
            if (result != null)
            {
                return this.Ok(result);
            }

            return this.BadRequest(new { Succeeded = false });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCart([FromBody] List<Cart> model)
        {
            var result = await this.manager.UpdateCart(model);
            if (result != 0)
            {
                return this.Ok(new { Succeeded = true });
            }

            return this.BadRequest(new { Succeeded = false });
        }
    }
}
