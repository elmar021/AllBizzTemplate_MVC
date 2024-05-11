﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Core.Entities
{
    public class Profession : BaseEntity
    {
        public string Name { get; set; }    
        public List<Member> Members { get; set; }   
    }
}
