using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInformation.Core.Models
{
    public class Material : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
