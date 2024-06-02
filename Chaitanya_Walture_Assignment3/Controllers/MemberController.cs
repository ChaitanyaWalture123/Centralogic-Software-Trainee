using Chaitanya_Walture_Assignment3.Entities;
using Chaitanya_Walture_Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace Chaitanya_Walture_Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private Container _container;

        public MemberController()
        {
            CosmosClient client = new CosmosClient("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            Database database = client.GetDatabase("LibraryManagementDB");
            _container = database.GetContainer("Members");
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(Member member)
        {
            var entity = new MemberEntity
            {
                Id = Guid.NewGuid().ToString(),
                UId = member.UId,
                Name = member.Name,
                DateOfBirth = member.DateOfBirth,
                Email = member.Email
            };

            await _container.CreateItemAsync(entity);
            return Ok(member);
        }

        [HttpGet("{uId}")]
        public async Task<IActionResult> GetMemberByUId(string uId)
        {
            var query = _container.GetItemLinqQueryable<MemberEntity>(true)
                .Where(m => m.UId == uId)
                .AsEnumerable()
                .FirstOrDefault();

            if (query == null)
                return NotFound();

            var member = new Member
            {
                UId = query.UId,
                Name = query.Name,
                DateOfBirth = query.DateOfBirth,
                Email = query.Email
            };

            return Ok(member);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = _container.GetItemLinqQueryable<MemberEntity>(true)
                .Select(m => new Member
                {
                    UId = m.UId,
                    Name = m.Name,
                    DateOfBirth = m.DateOfBirth,
                    Email = m.Email
                })
                .ToList();

            return Ok(members);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMember(Member member)
        {
            var entity = _container.GetItemLinqQueryable<MemberEntity>(true)
                .Where(m => m.UId == member.UId)
                .AsEnumerable()
                .FirstOrDefault();

            if (entity == null)
                return NotFound();

            entity.Name = member.Name;
            entity.DateOfBirth = member.DateOfBirth;
            entity.Email = member.Email;

            await _container.ReplaceItemAsync(entity, entity.Id);
            return Ok(member);
        }
    }
}
