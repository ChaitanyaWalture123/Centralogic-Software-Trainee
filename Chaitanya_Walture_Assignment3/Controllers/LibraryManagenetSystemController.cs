using Chaitanya_Walture_Assignment3.Entities;
using Chaitanya_Walture_Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace Chaitanya_Walture_Assignment3.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class LibraryManagenetSystemController : ControllerBase
    {
        private Container container;

        public LibraryManagenetSystemController()
        {
            CosmosClient client = new CosmosClient("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            Database database = client.GetDatabase("LibraryManagementDB");
            container = database.GetContainer("Books");
        }

        //BOOK OPERATION

        [HttpPost]
        public async Task<Book> AddBooks(Book bookmodel)
        {
            BookEntity bookEntity = new BookEntity();
           
            bookEntity.Title = bookmodel.Title;
            bookEntity.Author = bookmodel.Author;
            bookEntity.PublishedDate = bookmodel.PublishedDate;
            bookEntity.ISBN = bookmodel.ISBN;
            bookEntity.IsIssued = bookmodel.IsIssued;

            bookEntity.UId = Guid.NewGuid().ToString();
            bookEntity.Id = bookEntity.UId;
            bookEntity.DocumentType = "Book";
            bookEntity.CreatedBy = "Chaitanya";
            bookEntity.Createdon = DateTime.Now;
            bookEntity.UpdatedBy = "Chaitanya";
            bookEntity.UpdatedOn = DateTime.Now;
            bookEntity.Version = 1;
            bookEntity.Active = true;
            bookEntity.Archived = false;
            BookEntity Response = await container.CreateItemAsync(bookEntity);


            Book bookM = new Book();
            bookM.Title = Response.Title;
            bookM.Author = Response.Author;
            bookM.PublishedDate = Response.PublishedDate;
            bookM.ISBN = Response.ISBN;
            bookM.IsIssued = Response.IsIssued;
            return bookM;
        }
        [HttpGet]
        public async Task<Book> GetBookByUId(string UId)
        {
            var book = container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.UId == UId && q.Active == true && q.Archived == false).FirstOrDefault();

         

            Book bookmodel = new Book();
            bookmodel.UId = book.UId;
            bookmodel.Title = book.Title;
            bookmodel.Author = book.Author;
            bookmodel.PublishedDate = book.PublishedDate;
            bookmodel.ISBN = book.ISBN;
            bookmodel.IsIssued = book.IsIssued;
            return bookmodel;
        }
        [HttpGet]
        public async Task<Book> GetBookByTitle(string title)
        {
            var book = container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.Title == title && q.Active == true && q.Archived == false).FirstOrDefault();
            Book bookmodel = new Book();
            bookmodel.UId = book.UId;
            bookmodel.Title = book.Title;
            bookmodel.Author = book.Author;
            bookmodel.PublishedDate = book.PublishedDate;
            bookmodel.ISBN = book.ISBN;
            bookmodel.IsIssued = book.IsIssued;
            return bookmodel;
        }

        [HttpGet]
        public async Task<List<Book>> GetAllBooks()
        {
            var Books = container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == "Book").ToList();
            List<Book> bookModels = new List<Book>();
            for (var i = 0; i < Books.Count; i++)
            {
                Book BookModel = new Book();
                BookModel.UId = Books[i].UId;
                BookModel.Title = Books[i].Title;
                BookModel.Author = Books[i].Author;
                BookModel.PublishedDate = Books[i].PublishedDate;
                BookModel.ISBN = Books[i].ISBN;
                BookModel.IsIssued = Books[i].IsIssued;
                bookModels.Add(BookModel);
            }
            return bookModels;
        }

        [HttpGet]
        public async Task<List<Book>> GetAllNonIssuedBook()
        {
            var Books = container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.IsIssued == false && q.Active == true && q.Archived == false && q.DocumentType == "Book").ToList();
            List<Book> bookModels = new List<Book>();
            for (var i = 0; i < Books.Count; i++)
            {
                Book bookModel = new Book();
                bookModel.UId = Books[i].UId;
                bookModel.Title = Books[i].Title;
                bookModel.Author = Books[i].Author;
                bookModel.PublishedDate = Books[i].PublishedDate;
                bookModel.ISBN = Books[i].ISBN;
                bookModel.IsIssued = Books[i].IsIssued;
                bookModels.Add(bookModel);
            }
            return bookModels;
        }

        [HttpGet]
        public async Task<List<Book>> GetAllIssuedBook()
        {
            var Books = container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.IsIssued == true && q.Active == true && q.Archived == false && q.DocumentType == "Book").ToList();
            List<Book> bookModels = new List<Book>();
            for (var i = 0; i < Books.Count; i++)
            {
                Book BookModel = new Book();
                BookModel.UId = Books[i].UId;
                BookModel.Title = Books[i].Title;
                BookModel.Author = Books[i].Author;
                BookModel.PublishedDate = Books[i].PublishedDate;
                BookModel.ISBN = Books[i].ISBN;
                BookModel.IsIssued = Books[i].IsIssued;
                bookModels.Add(BookModel);
            }
            return bookModels;
        }

        [HttpPost]
        public async Task<Book> UpdateBook(Book book)
        {
            var existingBook = container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.UId == book.UId && q.Active == true && q.Archived == false).FirstOrDefault();

            existingBook.Archived = true;
            existingBook.Active = false;
            await container.ReplaceItemAsync(existingBook, existingBook.Id);


            existingBook.Id = Guid.NewGuid().ToString();
            existingBook.UpdatedBy = "Chaitanya";
            existingBook.UpdatedOn = DateTime.Now;
            existingBook.Version = ++existingBook.Version;
            existingBook.Active = true;
            existingBook.Archived = false;

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.PublishedDate = book.PublishedDate;
            existingBook.ISBN = book.ISBN;
            existingBook.IsIssued = book.IsIssued;


            existingBook = await container.CreateItemAsync(existingBook);


            Book Response = new Book();
            Response.UId = existingBook.UId;
            Response.Title = existingBook.Title;
            Response.Author = existingBook.Author;
            Response.PublishedDate = existingBook.PublishedDate;
            Response.ISBN = existingBook.ISBN;
            Response.IsIssued = existingBook.IsIssued;
            return Response;
        }


        [HttpPost]
        public async Task<Member> AddMembers(Member memberModel)
        {
            MemberEntity memberEntity = new MemberEntity();
            memberEntity.Name = memberModel.Name;
            memberEntity.DateOfBirth = memberModel.DateOfBirth;
            memberEntity.Email = memberModel.Email;

            memberEntity.UId = Guid.NewGuid().ToString();
            memberEntity.Id = memberEntity.UId;
            memberEntity.DocumentType = "Member";
            memberEntity.CreatedBy = "Member";
            memberEntity.Createdon = DateTime.Now;
            memberEntity.UpdatedBy = "";
            memberEntity.UpdatedOn = DateTime.Now;
            memberEntity.Version = 1;
            memberEntity.Active = true;
            memberEntity.Archived = false;

            MemberEntity Response = await container.CreateItemAsync(memberEntity);


            Member MemberM = new Member();
            MemberM.Name = Response.Name;
            MemberM.Email = Response.Email;
            MemberM.DateOfBirth = Response.DateOfBirth;
            return MemberM;
        }

        [HttpGet]
        public async Task<Member> GetMemberByUid(string Uid)
        {
            var member = container.GetItemLinqQueryable<MemberEntity>(true).Where(q => q.UId == Uid && q.Active == true && q.Archived == false && q.DocumentType == "Member").FirstOrDefault();
            Member MemberM = new Member();
            MemberM.Name = member.Name;
            MemberM.Email = member.Email;
            MemberM.DateOfBirth = member.DateOfBirth;
            return MemberM;
        }

        [HttpGet]
        public async Task<List<Member>> GetAllMembers()
        {
            var Members = container.GetItemLinqQueryable<MemberEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == "Member").ToList();
            List<Member> MemberModels = new List<Member>();
            for (var i = 0; i < Members.Count; i++)
            {
                Member MemberModel = new Member();
                MemberModel.UId = Members[i].UId;
                MemberModel.Name = Members[i].Name;
                MemberModel.Email = Members[i].Email;
                MemberModel.DateOfBirth = Members[i].DateOfBirth;
                MemberModels.Add(MemberModel);
            }
            return MemberModels;
        }

        [HttpPost]
        public async Task<Member> UpdateMember(Member memberModel)
        {   //fetch
            var existingMember = container.GetItemLinqQueryable<MemberEntity>(true).Where(q => q.UId == memberModel.UId && q.Active == true && q.Archived == false).FirstOrDefault();

            
            existingMember.Archived = true;
            existingMember.Active = false;
            await container.ReplaceItemAsync(existingMember, existingMember.Id);

            existingMember.Id = Guid.NewGuid().ToString();
            existingMember.UpdatedBy = "Chaitanya";
            existingMember.UpdatedOn = DateTime.Now;
            existingMember.Version = ++existingMember.Version;
            existingMember.Active = true;
            existingMember.Archived = false;

            
            existingMember.Name = memberModel.Name;
            existingMember.Email = memberModel.Email;
            existingMember.DateOfBirth = memberModel.DateOfBirth;

            existingMember = await container.CreateItemAsync(existingMember);

    
            Member Response = new Member();
            Response.UId = existingMember.UId;
            Response.Name = existingMember.Name;
            Response.Email = existingMember.Email;
            return Response;
        }


        [HttpPost]
        public async Task<Issue> IssueBooks(Issue issueModel)
        {
            IssueEntity issueEntity = new IssueEntity();
            issueEntity.BookId = issueModel.BookId;
            issueEntity.MemberId = issueModel.MemberId;
            issueEntity.IssueDate = issueModel.IssueDate;
            issueEntity.isReturned = issueModel.isReturned;

            issueEntity.UId = Guid.NewGuid().ToString();
            issueEntity.Id = issueEntity.UId;
            issueEntity.DocumentType = "IssueBook";
            issueEntity.CreatedBy = "Chaitanya";
            issueEntity.Createdon = DateTime.Now;
            issueEntity.UpdatedBy = "Chaitanya";
            issueEntity.UpdatedOn = DateTime.Now;
            issueEntity.Version = 1;
            issueEntity.Active = true;
            issueEntity.Archived = false;

            IssueEntity Response = await container.CreateItemAsync(issueEntity);

            Issue IssueM = new Issue();
            IssueM.BookId = Response.BookId;
            IssueM.MemberId = Response.MemberId;
            IssueM.IssueDate = Response.IssueDate;

            IssueM.isReturned = Response.isReturned;
            return IssueM;
        }

        [HttpGet]
        public async Task<Issue> GetIssueByUid(string Uid)
        {
            var issuebook = container.GetItemLinqQueryable<IssueEntity>(true).Where(q => q.UId == Uid && q.Active == true && q.Archived == false && q.DocumentType == "IssueBook").FirstOrDefault();
            var book = container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.Id == issuebook.BookId && q.Active == true && q.Archived == false && q.DocumentType == "Book").FirstOrDefault();
            Issue issueM = new Issue();
            issueM.BookId = issuebook.BookId;
            issueM.BookTitle = book.Title;
            issueM.MemberId = issuebook.MemberId;
            issueM.IssueDate = issuebook.IssueDate;
            issueM.ReturnDate = issuebook.ReturnDate;
            issueM.isReturned = issuebook.isReturned;
            return issueM;

        }
        [HttpGet]
        public async Task<Issue> GetIssueBookByUid(string Uid)
        {
            var issuebook = container.GetItemLinqQueryable<IssueEntity>(true).Where(q => q.UId == Uid && q.Active == true && q.Archived == false && q.DocumentType == "IssueBook").FirstOrDefault();
            var book = container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.UId == issuebook.BookId && q.Active == true && q.Archived == false && q.DocumentType == "Book").FirstOrDefault();
            Issue issueM = new Issue();
            issueM.BookId = issuebook.BookId;
            issueM.BookTitle = book.Title;
            return issueM;
        }

        [HttpPost]
        public async Task<Issue> updateexistingissue(Issue issueModel)
        {
           
            var existingissue = container.GetItemLinqQueryable<IssueEntity>(true).Where(q => q.UId == issueModel.UId && q.Active == true && q.Archived == false).FirstOrDefault();
            
            existingissue.Archived = true;
            existingissue.Active = false;
            await container.ReplaceItemAsync(existingissue, existingissue.Id);
            
            existingissue.Id = Guid.NewGuid().ToString();
            existingissue.UpdatedBy = "Chaitanya";
            existingissue.UpdatedOn = DateTime.Now;
            existingissue.Version = ++existingissue.Version;
            existingissue.Active = true;
            existingissue.Archived = false;
            
            existingissue.BookId = issueModel.BookId;
            existingissue.MemberId = issueModel.MemberId;
            existingissue.IssueDate = issueModel.IssueDate;
            existingissue.ReturnDate = issueModel.ReturnDate;
            existingissue.isReturned = issueModel.isReturned;
            
            existingissue = await container.CreateItemAsync(existingissue);
            
            Issue Response = new Issue();
            Response.UId = existingissue.UId;
            Response.BookId = existingissue.BookId;
            Response.MemberId = existingissue.MemberId;
            Response.IssueDate = existingissue.IssueDate;
            Response.ReturnDate = existingissue.ReturnDate;
            Response.isReturned = existingissue.isReturned;
            return Response;
        }
    }
}
