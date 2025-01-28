using Application.DTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Serialization;
using Infrastructure.Utilities;
using System.IO;

namespace EntryPoints.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {
        private readonly ProcessAccountRequest _processAccountRequest;
        private readonly XmlSerializer _xmlSerializer;

        public BankController(ProcessAccountRequest processAccountRequest, XmlSerializer xmlSerializer)
        {
            _processAccountRequest = processAccountRequest;
            _xmlSerializer = xmlSerializer;
            
        }

        [HttpPost("ProcessRequest")]
        public IActionResult ProcessRequest([FromBody] AccountRequestDTO request)
        {
            var account = new Core.Entities.Account { AccountNumber = request.AccountNumber };
            var result = _processAccountRequest.Process(account);
            return Ok(result);
        }

        [HttpPost("ProcessBalanceRequest")]
        [Consumes("application/xml")]
        public async Task<IActionResult> ProcessBalanceRequest()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var request = await reader.ReadToEndAsync();

                var xsdFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Schemas", "BalanceRequest.xsd");
                XmlValidator.Validate(request, xsdFilePath);

                var xmlResponse = await _processAccountRequest.ProcessBalanceRequestAsync(request);

                return Content(xmlResponse, "application/xml");
            }
        }

    }
}