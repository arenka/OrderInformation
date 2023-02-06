using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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


        public OrderInformationsController(IOrderInformationService orderInformationService, IMapper mapper)
        {
            _orderInformationService = orderInformationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOrder()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(OrderInfoDTO[] orderInfoDTO)
        {

            var result = await _orderInformationService.AddOrderInformationAsync(orderInfoDTO);
            if (result.Any())
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        public IActionResult AddOrder(OrderInfoDTO[] orderInfoDTO)
        {

            var result = _orderInformationService.AddOrderInformation(orderInfoDTO);
            if (result.Any())
            {
                return Ok(result);
            }
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
