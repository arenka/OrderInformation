using OrderInformation.Core.DTOs;
using OrderInformation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Core.Services
{
    public interface IMaterialService
    {
        Task AddMaterialAsync(MaterialDTO materialDTO);
        void AddMaterial(MaterialDTO materialDTO);
        bool IsCheckMaterialCode(string code);
        Task<bool> IsCheckMaterialCodeAsync(string code);
    }
}
