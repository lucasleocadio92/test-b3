using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using TestB3.Investment.Domain;
using TestB3.Investment.WepApi.DTO;

namespace TestB3.Investment.WepApi.Controllers
{
    [ApiController]
    [Route("api/investimento")]
    [Produces("application/json")]
    public class InvestmentController : ControllerBase
    {
        private readonly ICdbService _cdbService;
        private readonly IMapper _mapper;

        public InvestmentController(ICdbService cdbService, IMapper mapper)
        {
            _cdbService = cdbService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(InvestmentResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] InvestmentRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok
            (
                _mapper.Map<InvestmentResponse>(await _cdbService.CalculateInvestment(request.StartingMoney, request.Month))
            );
        }
    }
}
