using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BocesModule.Shared;

namespace BocesModule.Api.Models
{
    public class CoSerGroupRepository: ICoSerGroupRepository
    {
        private readonly AppDbContext _appDbContext;

        public CoSerGroupRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<CoSerGroup> GetAllCoSerGroups()
        {
            return _appDbContext.CoSerGroups;
        }

        public CoSerGroup GetCoSerGroupById(int coSerGroupId)
        {
            return _appDbContext.CoSerGroups.FirstOrDefault(c => c.CoSerGroupId == coSerGroupId);
        }

    }
}
