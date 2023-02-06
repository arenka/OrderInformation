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
    public class MaterialRepository : GenericRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }
        public void AddOrderInfo(Material material)
        {
            this.Add(material);
        }

        public async Task AddOrderInfoAsync(Material material)
        {
           await this.AddAsync(material);
        }
    }
}
