using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Core.DTOs
{
    public class OrderStatusDTO
    {
        public string CustomerOrderNo { get; set; }
        public int Statu { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
