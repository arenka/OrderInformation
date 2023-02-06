using OrderInformation.Core.DTOs;
using OrderInformation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Core.Services
{
    public interface IOrderInformationService
    {
        Task<List<ResponseDTO>> AddOrderInformationAsync(OrderInfoDTO[] orderInfoDTO);
        List<ResponseDTO> AddOrderInformation(OrderInfoDTO[] orderInfoDTO);

        void Update(OrderInfoDTO orderInfoDTO);

        bool SetOrderStatu(int id, int statu);
    }
}
