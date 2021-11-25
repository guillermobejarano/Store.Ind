using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Ind.Insfrastructure.Services;

namespace Store.Ind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly ILogger<DiscountsController> _logger;
        private readonly IDiscountService _service;

        public DiscountsController(ILogger<DiscountsController> logger, IDiscountService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}
