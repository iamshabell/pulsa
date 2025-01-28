using Application.DTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace EntryPoints.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {
        private readonly ProcessAccountRequest _processAccountRequest;

        public BankController(ProcessAccountRequest processAccountRequest)
        {
            _processAccountRequest = processAccountRequest;
        }

        [HttpPost("ProcessRequest")]
        public IActionResult ProcessRequest([FromBody] AccountRequestDTO request)
        {
            var account = new Core.Entities.Account { AccountNumber = request.AccountNumber };
            var result = _processAccountRequest.Process(account);
            return Ok(result);
        }
    }
}