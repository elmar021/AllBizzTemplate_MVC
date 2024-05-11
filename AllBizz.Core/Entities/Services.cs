using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Core.Entities
{
    public class Services : BaseEntity
    {
        public string LogoUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
