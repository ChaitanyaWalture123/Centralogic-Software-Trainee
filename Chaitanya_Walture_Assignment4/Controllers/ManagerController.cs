using Chaitanya_Walture_Assignment4.DTO;
using Chaitanya_Walture_Assignment4.Interfaces;
using Chaitanya_Walture_Assignment4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chaitanya_Walture_Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : Controller
    {
        public readonly IManagerService _managerService;
        private readonly ISecurityService _securityService;
        private readonly IOfficeService _ioffceService;
        private readonly IVisitorService _visitorService;

        public ManagerController(IManagerService managerService, ISecurityService securityService, IOfficeService ioffceService, IVisitorService visitorService)
        {
            _managerService = managerService;
            _securityService = securityService;
            _ioffceService = ioffceService;
            _visitorService = visitorService;

        }

        [HttpPost("RegisterManager")]
        public async Task<ManagerDTO> ManagerRegister(ManagerDTO managerModel)
        {
            var response = await _managerService.RegisterManager(managerModel);
            return response;


        }
        [HttpPost("RegisterOffice")]
        public async Task<OfficeDTO> RegisterOffice(OfficeDTO officeModel)
        {
            var response = await _ioffceService.RegisterOffice(officeModel);
            return response;


        }
        [HttpPost("RegisterSecurity")]
        public async Task<SecurityDTO> RegisterSecurity(SecurityDTO securityDTO)
        {
            var response = await _securityService.RegisterSecurity(securityDTO);
            return response;


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

        [HttpGet("LoginManager")]
        public async Task<IActionResult> ManagerLogin(string username, string password)
        {
            try
            {
               
                var manager = await _managerService.LoginManager(username, password);

                if (manager != null)
                {
                    return Ok($" Name : {manager.Name}  \n Login Successfully !!! ");
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
    }
}
