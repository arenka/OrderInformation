using OrderInformation.Core.Models;

namespace OrderInformation.Core.Repositories
{
    public interface IOrderInformationRepository 
    {
        Task AddOrderInfoAsync(OrderInfo orderInformation);
        void AddOrderInfo(OrderInfo orderInformation);
        void Update(OrderInfo orderInformation);
        Task<OrderInfo> GetByIdAsync(int id);
        OrderInfo GetById(int id);
    }
}
