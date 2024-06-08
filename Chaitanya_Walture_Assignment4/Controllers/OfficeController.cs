using Chaitanya_Walture_Assignment4.DTO;
using Chaitanya_Walture_Assignment4.Interfaces;
using Chaitanya_Walture_Assignment4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chaitanya_Walture_Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : Controller
    {
        public readonly IOfficeService _officeService;
        private readonly IVisitorService _visitorService;

        public OfficeController(IOfficeService officeService, IVisitorService visitorService)
        {
            _officeService = officeService;
            _visitorService = visitorService;
        }


        [HttpGet("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                
                var user = await _officeService.LoginOfficeUser(username, password);

                if (user != null)
                {
                    return Ok($" Username : {user.UserName}  \n Login Successfully !!! ");
                }
                else
                {
                    return Unauthorized("Invalid Credentials !!!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Login Get Failed");
            }
        }

        [HttpGet("AllRequest")]
        public async Task<List<VisitorDTO>> GetAllRequest()
        {
            var response = await _visitorService.GetAllRequest();
            return response;
        }

        [HttpGet("ApprovedRequest")]
        public async Task<List<RequestDTO>> GetApprovedRequest()
        {
            var response = await _visitorService.GetApprovedRequest();
            return response;
        }

        [HttpGet("RejectedRequest")]
        public async Task<List<RequestDTO>> GetRejectedRequest()
        {
            var response = await _visitorService.RejectedRequest();
            return response;
        }

        [HttpGet("PendingRequest")]
        public async Task<List<RequestDTO>> GetPendingRequest()
        {
            var response = await _visitorService.PendingRequest();
            return response;
        }

        [HttpPost("ApproveRequest")]
        public async Task<RequestDTO> ApproveRequest(string Id)
        {
            var response = await _visitorService.ApproveRequsest(Id);
            return response;
        }

        [HttpPost("RejectRequest")]
        public async Task<RequestDTO> RejectRequest(string Id)
        {
            var response = await _visitorService.RejectRequest(Id);
            return response;
        }


    }
}
