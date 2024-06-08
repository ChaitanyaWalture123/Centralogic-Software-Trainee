using Chaitanya_Walture_Assignment4.DTO;
using Chaitanya_Walture_Assignment4.Interfaces;

using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;
using SendGrid;



namespace Chaitanya_Walture_Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        public readonly IVisitorService _visitorService;
        public VisitorController(IVisitorService visitorService)
        {
            _visitorService = visitorService;

        }

        [HttpPost("Registervisitor")]
        public async Task<VisitorDTO> RegisterVisitor(VisitorDTO visitor)
        {
            var response = await _visitorService.RegisterVisitor(visitor);
            await Execute(response.Email);
            return response;
        }

        [HttpGet("RequestStatus")]
        public async Task<RequestDTO> CheckRequestStatus(string VisitorId)
        {
            var visitor = await _visitorService.GetVisitorByVisitorId(VisitorId);

            return visitor;
        }


        static async Task Execute(string email)
        {
            var apiKey = "apikeyaddapikey";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("tidkeshubham10@gmail.com", "Manager");
            var subject = "My Subject - Hi YouTube!";
            var to = new EmailAddress(email, "Hello");
            var plainTextContent = "How cool an email!";
            var htmlContent = "<strong>How cool an email!</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Body.ReadAsStringAsync());
           
        }



    }
}
