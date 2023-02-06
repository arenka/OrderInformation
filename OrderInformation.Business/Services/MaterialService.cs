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
    public class MaterialService : Service<Material>, IMaterialService
    {

        //private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialService(IGenericRepository<Material> repository, IUnitOfWork unitOfWork, /*IMaterialRepository materialRepository,*/ IMapper mapper) : base(repository, unitOfWork)
        {
            //_materialRepository = materialRepository;
            _mapper = mapper;
        }
        public void AddMaterial(MaterialDTO materialDTO)
        {
            var material = _mapper.Map<Material>(materialDTO);
            this.Add(material);
        }

        public async Task AddMaterialAsync(MaterialDTO materialDTO)
        {
            var material = _mapper.Map<Material>(materialDTO);
            await this.AddAsync(material);

        }

        public bool IsCheckMaterialCode(string code)
        {
            var result = this.FirstOrDefault(x => x.Code == code);
            if (result is null)
            {
              return false;
            }
            return true;
        }
        public async Task<bool> IsCheckMaterialCodeAsync(string code)
        {
            var result =await this.FirstOrDefaultAsync(x => x.Code == code);
            if (result is null)
            {
                return false;
            }
            return true;
        }
    }
}
