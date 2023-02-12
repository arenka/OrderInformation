using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderInformation.Core.DTOs;

namespace OrderInformation.StatusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStatus(OrderStatusDTO orderStatuDTO)
        {
            return Ok(orderStatuDTO);
        }
    }
}
