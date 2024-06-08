using Chaitanya_Walture_Assignment4.DTO;
using Chaitanya_Walture_Assignment4.Interfaces;
using Chaitanya_Walture_Assignment4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chaitanya_Walture_Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : Controller
    {

        public readonly ISecurityService _securityService;
        public readonly IVisitorService _visitorService;
        public readonly IOfficeService _officeService;
        public SecurityController(ISecurityService securityService, IVisitorService visitorService, IOfficeService officeService)
        {
            _securityService = securityService;
            _visitorService = visitorService;
            _officeService = officeService;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                
                var user = await _securityService.LoginSecurityUser(username, password);

                if (user != null)
                {
                    return Ok($" Username : {user.Username}  \n Login Successfully !!! ");
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

        [HttpGet("RequestStatus")]
        public async Task<RequestDTO> GetVisitorByVisitorId(string VisitorId)
        {
            var visitor = await _visitorService.GetVisitorByVisitorId(VisitorId);
            return visitor;
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



    }
}
