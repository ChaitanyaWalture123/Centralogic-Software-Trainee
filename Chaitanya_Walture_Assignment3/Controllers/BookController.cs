using Chaitanya_Walture_Assignment3.Entities;
using Chaitanya_Walture_Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace Chaitanya_Walture_Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private Container _container;

        public BookController()
        {
            CosmosClient client = new CosmosClient("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            Database database = client.GetDatabase("LibraryManagementDB");
            _container = database.GetContainer("Books");
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            var entity = new BookEntity
            {
                Id = Guid.NewGuid().ToString(),
                UId = book.UId,
                Title = book.Title,
                Author = book.Author,
                PublishedDate = book.PublishedDate,
                ISBN = book.ISBN,
                IsIssued = false
            };

            await _container.CreateItemAsync(entity);
            return Ok(book);
        }

        [HttpGet("{uId}")]
        public async Task<IActionResult> GetBookByUId(string uId)
        {
            var query = _container.GetItemLinqQueryable<BookEntity>(true)
                .Where(b => b.UId == uId)
                .AsEnumerable()
                .FirstOrDefault();

            if (query == null)
                return NotFound();

            var book = new Book
            {
                UId = query.UId,
                Title = query.Title,
                Author = query.Author,
                PublishedDate = query.PublishedDate,
                ISBN = query.ISBN,
                IsIssued = query.IsIssued
            };

            return Ok(book);
        }

        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetBookByTitle(string title)
        {
            var books = _container.GetItemLinqQueryable<BookEntity>(true)
                .Where(b => b.Title == title)
                .Select(b => new Book
                {
                    UId = b.UId,
                    Title = b.Title,
                    Author = b.Author,
                    PublishedDate = b.PublishedDate,
                    ISBN = b.ISBN,
                    IsIssued = b.IsIssued
                })
                .ToList();

            return Ok(books);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = _container.GetItemLinqQueryable<BookEntity>(true)
                .Select(b => new Book
                {
                    UId = b.UId,
                    Title = b.Title,
                    Author = b.Author,
                    PublishedDate = b.PublishedDate,
                    ISBN = b.ISBN,
                    IsIssued = b.IsIssued
                })
                .ToList();

            return Ok(books);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableBooks()
        {
            var books = _container.GetItemLinqQueryable<BookEntity>(true)
                .Where(b => !b.IsIssued)
                .Select(b => new Book
                {
                    UId = b.UId,
                    Title = b.Title,
                    Author = b.Author,
                    PublishedDate = b.PublishedDate,
                    ISBN = b.ISBN,
                    IsIssued = b.IsIssued
                })
                .ToList();

            return Ok(books);
        }

        [HttpGet("issued")]
        public async Task<IActionResult> GetIssuedBooks()
        {
            var books = _container.GetItemLinqQueryable<BookEntity>(true)
                .Where(b => b.IsIssued)
                .Select(b => new Book
                {
                    UId = b.UId,
                    Title = b.Title,
                    Author = b.Author,
                    PublishedDate = b.PublishedDate,
                    ISBN = b.ISBN,
                    IsIssued = b.IsIssued
                })
                .ToList();

            return Ok(books);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            var entity = _container.GetItemLinqQueryable<BookEntity>(true)
                .Where(b => b.UId == book.UId)
                .AsEnumerable()
                .FirstOrDefault();

            if (entity == null)
                return NotFound();

            entity.Title = book.Title;
            entity.Author = book.Author;
            entity.PublishedDate = book.PublishedDate;
            entity.ISBN = book.ISBN;
            entity.IsIssued = book.IsIssued;

            await _container.ReplaceItemAsync(entity, entity.Id);
            return Ok(book);
        }
    }
}
