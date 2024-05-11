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
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(AppDbContext appDb) : base(appDb)
        {
        }
    }
}
