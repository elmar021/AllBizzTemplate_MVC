using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Core.Entities
{
    public class Member : BaseEntity
    {
        public string FullName { get; set; }
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }
        public string InstaUrl { get; set; }
        public string FaceUrl { get; set; }
        public string TwitUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
