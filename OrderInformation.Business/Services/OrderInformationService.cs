using AutoMapper;
using OrderInformation.Core.DTOs;
using OrderInformation.Core.Models;
using OrderInformation.Core.Repositories;
using OrderInformation.Core.Services;
using OrderInformation.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Business.Services
{
    public class OrderInformationService : Service<OrderInfo>, IOrderInformationService
    {
        //private readonly IOrderInformationRepository _orderInformation;
        private readonly IMaterialService _materialService;
        private readonly IMapper _mapper;

        public OrderInformationService(IGenericRepository<OrderInfo> repository, IUnitOfWork unitOfWork, /*IOrderInformationRepository orderInformation,*/ IMapper mapper, IMaterialService materialService) : base(repository, unitOfWork)
        {
            //_orderInformation = orderInformation;
            _mapper = mapper;
            _materialService = materialService;
        }
        public List<ResponseDTO> AddOrderInformation(OrderInfoDTO[] orderInfoDTO)
        {
            List<ResponseDTO> responseList = new();
            try
            {
                if (orderInfoDTO is not null)
                {
                    List<string> customerOrderList = orderInfoDTO.Select(x => x.CustomerOrderNo).ToList();

                    foreach (var order in orderInfoDTO)
                    {
                        var orderInfo = _mapper.Map<OrderInfo>(order);
                        IsCheckMetarial(orderInfo.MaterialCode, orderInfo.Material);
                        var systemNo = Guid.NewGuid().ToString();
                        orderInfo.SystemOrderNo = systemNo;
                        orderInfo.OrderStatu = 1;
                        this.Add(orderInfo);
                        var response = AddResponseDTO(string.Empty, orderInfo.CustomerOrderNo, orderInfo.SystemOrderNo, 0);
                        responseList.Add(response);
                    }
                }
            }
            catch (Exception ex)
            {
                var response = AddResponseDTO(ex.Message, string.Empty, string.Empty, 1);
                responseList.Add(response);
            }
            return responseList;
        }
        public async Task<List<ResponseDTO>> AddOrderInformationAsync(OrderInfoDTO[] orderInfoDTO)
        {
            List<ResponseDTO> responseList = new();
            try
            {
                if (orderInfoDTO is not null)
                {
                    List<string> customerOrderList = orderInfoDTO.Select(x => x.CustomerOrderNo).ToList();

                    foreach (var order in orderInfoDTO)
                    {
                        var orderInfo = _mapper.Map<OrderInfo>(order);
                        await IsCheckMetarialAsync(orderInfo.MaterialCode, orderInfo.Material);
                        var systemNo = Guid.NewGuid().ToString();
                        orderInfo.SystemOrderNo = systemNo;
                        orderInfo.OrderStatu = 1;
                        await this.AddAsync(orderInfo);
                        var response = AddResponseDTO(string.Empty, orderInfo.CustomerOrderNo, orderInfo.SystemOrderNo, 0);
                        responseList.Add(response);
                    }
                }
            }
            catch (Exception ex)
            {
                var response = AddResponseDTO(ex.Message, string.Empty, string.Empty, 1);
                responseList.Add(response);
            }
            return responseList;
        }
        private async Task IsCheckMetarialAsync(string code, string name)
        {
            var isCheckMaterial = await _materialService.IsCheckMaterialCodeAsync(code);
            if (!isCheckMaterial)
            {
                await _materialService.AddMaterialAsync(new MaterialDTO()
                {
                    Code = code,
                    Name = name
                });
            }
        }
        private void IsCheckMetarial(string code, string name)
        {
            var isCheckMaterial = _materialService.IsCheckMaterialCode(code);
            if (!isCheckMaterial)
            {
                _materialService.AddMaterial(new MaterialDTO()
                {
                    Code = code,
                    Name = name
                });
            }
        }
        private ResponseDTO AddResponseDTO(string errorMessage, string customerOrderNo, string systemOrderNo, int statu)
        {
            ResponseDTO response = new();
            response.ErrorMessage = errorMessage;
            response.CustomerOrderNo = customerOrderNo;
            response.SystemOrderNo = systemOrderNo;
            response.Statu = statu;
            return response;
        }
        public bool SetOrderStatu(int id, int statu)
        {
            var order = this.GetById(id);
            if (order is not null)
            {
                order.OrderStatu = statu;
                try
                {
                    Update(order);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public void Update(OrderInfoDTO orderInfoDTO)
        {
            var orderInfo = _mapper.Map<OrderInfo>(orderInfoDTO);
            this.Update(orderInfo);
        }
    }
}
