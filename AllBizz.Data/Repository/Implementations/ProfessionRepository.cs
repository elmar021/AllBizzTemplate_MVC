using AllBizz.Core.Entities;
using AllBizz.Core.Repository.Interfaces;
using AllBizz.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Data.Repository.Implementations
{
    public class ProfessionRepository : GenericRepository<Profession>, IProfessionRepository
    {
        public ProfessionRepository(AppDbContext appDb) : base(appDb)
        {
        }
    }
}
