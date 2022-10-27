using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIAssignment2.Repositories;
using APIAssignment2.Entities;

namespace HandsOnEFDBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookRepository bookRepository;
        public BookController()
        {
            bookRepository = new BookRepository();
        }

        
        [HttpGet, Route("GetBooks")]
        public IActionResult GetAll()
        {
            try
            {
                return StatusCode(200, bookRepository.GetBooks());
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetBooksByAuthor/{author}")]
        public IActionResult GetAllByAuthor(string author)
        {
            try
            {
                return StatusCode(200, bookRepository.GetBooksByAuthor(author));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetBooksByPublisher/{publisher}")]
        public IActionResult GetAllByPublisher(string publisher)
        {
            try
            {
                return StatusCode(200, bookRepository.GetBooksByPublisher(publisher));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet, Route("GetBookByName/{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                return StatusCode(200, bookRepository.GetBookByName(name));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetBook/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return StatusCode(200, bookRepository.GetBookById(id));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost, Route("AddBook")]
        public IActionResult Add(Book book)
        {
            //try
            //{
                bookRepository.AddBook(book);
                return StatusCode(200, book);
            //}
            //catch (Exception ex)
            //{

              //  return StatusCode(500, ex.Message);
            //}
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            bookRepository.DeleteBook(id);
            return StatusCode(200, "Book with " + id + " Deleted");
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit(Book book)
        {
            bookRepository.EditBook(book);
            return StatusCode(200, book);
        }
    }
}