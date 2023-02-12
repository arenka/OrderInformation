using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderInformation.API.Services;
using OrderInformation.Core.DTOs;
using OrderInformation.Core.Services;

namespace OrderInformation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderInformationsController : ControllerBase
    {
        private readonly IOrderInformationService _orderInformationService;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderInformationsController> _logger;
        private readonly OrderStatuService _orderStatuService;

        public OrderInformationsController(IOrderInformationService orderInformationService, IMapper mapper, ILogger<OrderInformationsController> logger, OrderStatuService orderStatuService)
        {
            _orderInformationService = orderInformationService;
            _mapper = mapper;
            _logger = logger;
            _orderStatuService = orderStatuService;
        }

        [HttpGet]
        public IActionResult GetAllOrder()
        {
            _logger.LogInformation("Get All Orders", new { mesage = "success" });
            var models = _orderInformationService.GetAllOrders();
            return Ok(models);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(OrderInfoDTO[] orderInfoDTO)
        {

            var result = await _orderInformationService.AddOrderInformationAsync(orderInfoDTO);
            if (result.Any())
            {
                _logger.LogInformation("AddOrderAsync", new { mesage = "success" });
                return Ok(result);
            }
            _logger.LogError("AddOrderAsync", new { mesage = "error" });
            return BadRequest();
        }

        [HttpPost("[action]")]
        public IActionResult AddOrder(OrderInfoDTO[] orderInfoDTO)
        {

            var result = _orderInformationService.AddOrderInformation(orderInfoDTO);
            if (result.Any())
            {
                _logger.LogInformation("AddOrder", new { mesage = "success" });
                return Ok(result);
            }
            _logger.LogError("AddOrder", new { mesage = "error" });
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateOrder(int orderId, int statuId)
        {
            var result = _orderInformationService.SetOrderStatu(orderId, statuId);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
