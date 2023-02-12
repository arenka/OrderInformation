using OrderInformation.Core.DTOs;

namespace OrderInformation.API.Services
{
    public class OrderStatuService
    {
        private readonly HttpClient _httpClient;

        public OrderStatuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetOrderStatu(OrderStatusDTO orderStatuDTO)
        {
            //statu
            var response = await _httpClient.PostAsJsonAsync<OrderStatusDTO>("status", orderStatuDTO);
            var responseStatu = response.Content.ReadAsStringAsync().Result;
            if (responseStatu is null)
            {
                throw new Exception("Gönderilemedi...");
            }
        }
    }
}
