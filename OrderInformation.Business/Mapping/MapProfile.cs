using AutoMapper;
using OrderInformation.Core.DTOs;
using OrderInformation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Business.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<OrderInfo, OrderInfoDTO>().ReverseMap();
            CreateMap<Material, MaterialDTO>().ReverseMap();
        }
    }
}
