using Chaitanya_Walture_Assignment3.Entities;
using Chaitanya_Walture_Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace Chaitanya_Walture_Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private Container _container;

        public IssueController()
        {
            CosmosClient client = new CosmosClient("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            Database database = client.GetDatabase("LibraryManagementDB");
            _container = database.GetContainer("Issues");
        }

        [HttpPost]
        public async Task<IActionResult> IssueBook(Issue issue)
        {
            var entity = new IssueEntity
            {
                Id = Guid.NewGuid().ToString(),
                UId = issue.UId,
                BookId = issue.BookId,
                MemberId = issue.MemberId,
                IssueDate = issue.IssueDate,
                ReturnDate = issue.ReturnDate,
                IsReturned = false
            };

            await _container.CreateItemAsync(entity);
            return Ok(issue);
        }

        [HttpGet("{uId}")]
        public async Task<IActionResult> GetIssueByUId(string uId)
        {
            var query = _container.GetItemLinqQueryable<IssueEntity>(true)
                .Where(i => i.UId == uId)
                .AsEnumerable()
                .FirstOrDefault();

            if (query == null)
                return NotFound();

            var issue = new Issue
            {
                UId = query.UId,
                BookId = query.BookId,
                MemberId = query.MemberId,
                IssueDate = query.IssueDate,
                ReturnDate = query.ReturnDate,
                IsReturned = query.IsReturned
            };

            return Ok(issue);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIssue(Issue issue)
        {
            var entity = _container.GetItemLinqQueryable<IssueEntity>(true)
                .Where(i => i.UId == issue.UId)
                .AsEnumerable()
                .FirstOrDefault();

            if (entity == null)
                return NotFound();

            entity.BookId = issue.BookId;
            entity.MemberId = issue.MemberId;
            entity.IssueDate = issue.IssueDate;
            entity.ReturnDate = issue.ReturnDate;
            entity.IsReturned = issue.IsReturned;

            await _container.ReplaceItemAsync(entity, entity.Id);
            return Ok(issue);
        }
    }
}
