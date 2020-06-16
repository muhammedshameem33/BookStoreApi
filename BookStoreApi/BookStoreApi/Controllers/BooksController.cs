using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.ManagerInterface;
using BookStoreModelLayer.Book;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookManager manager;

        public BooksController(IBookManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody]AddBookModel model)
        {
            var result = await this.manager.AddBooks(model);
            if (result > 0)
            {
                return this.Ok(new { Succeeded=true});
            }

            return this.BadRequest(new { Succeeded = false });
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return this.manager.GetBooks();
        }
    }
}
