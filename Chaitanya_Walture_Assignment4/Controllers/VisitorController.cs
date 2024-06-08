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
            return response;
        }

        [HttpGet("RequestStatus")]
        public async Task<RequestDTO> CheckRequestStatus(string VisitorId)
        {
            var visitor = await _visitorService.GetVisitorByVisitorId(VisitorId);

            return visitor;
        }


        



    }
}
