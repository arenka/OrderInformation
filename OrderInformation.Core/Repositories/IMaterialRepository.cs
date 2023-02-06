using OrderInformation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Core.Repositories
{
    public interface IMaterialRepository
    {
        Task AddOrderInfoAsync(Material material);
        void AddOrderInfo(Material material);
    }
}
