using NET_first_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NET_first_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        static private List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "The Midnight Library",
                Author = "Matt Haing",
                YearPublished = 2023
            },

            new Book
            {
                Id = 2,
                Title = "Inside the Magic Bookstore",
                Author = "Dr. James R.Doty",
                YearPublished = 2016
            },
            new Book
            {
                Id = 3,
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                YearPublished = 1960
            }
        };
        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            // status 200 code
            return Ok(books);
        }
        [HttpGet("{id}")]
        public ActionResult<Book>GetBookById(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                // status code 404 not found
                return NotFound();
            return Ok(book);
        }
        [HttpPost]
        public ActionResult<Book> AddBook(Book newBook)
        {
            if (newBook == null)
                // status 400 bad request
                return BadRequest();

            books.Add(newBook);
            return CreatedAtAction(nameof(GetBookById), new {id=newBook.Id}, newBook);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                // status code 404 not found
                return NotFound();

            book.Id = updatedBook.Id;
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.YearPublished = updatedBook.YearPublished;

            // status code 204 No Content 
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                // status code 404 not found
                return NotFound();

            books.Remove(book);
            return NoContent();
        }
    }
}
