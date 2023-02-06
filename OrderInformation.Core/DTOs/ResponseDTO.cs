using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Core.DTOs
{
    public class ResponseDTO
    {
        //        ⦁	Müşteri Sipariş No
        //⦁	Sistem Sipariş No
        //⦁	Statü( 0 başarılı , 1 hatalı)
        //⦁	Hata Açıklama
        public string CustomerOrderNo { get; set; }
        public string SystemOrderNo { get; set; }
        public int Statu { get; set; }
        public string ErrorMessage { get; set; }

    }
}
