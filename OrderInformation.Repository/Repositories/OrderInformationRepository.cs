using OrderInformation.Core.Models;
using OrderInformation.Core.Repositories;
using OrderInformation.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Repository.Repositories
{
    public class OrderInformationRepository : GenericRepository<OrderInfo>, IOrderInformationRepository
    {
        public OrderInformationRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }
        public void AddOrderInfo(OrderInfo orderInformation)
        {
            this.Add(orderInformation);
        }

        public async Task AddOrderInfoAsync(OrderInfo orderInformation)
        {
            await this.AddAsync(orderInformation);
        }

        public void UpdateOrderInfo(OrderInfo orderInformation)
        {
            this.Update(orderInformation);
        }
    }
}
