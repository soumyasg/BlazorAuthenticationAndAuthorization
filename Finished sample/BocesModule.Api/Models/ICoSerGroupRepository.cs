using System.Collections.Generic;
using BocesModule.Shared;

namespace BocesModule.Api.Models
{
    public interface ICoSerGroupRepository
    {
        IEnumerable<CoSerGroup> GetAllCoSerGroups();
        CoSerGroup GetCoSerGroupById(int coSerGroupId);
    }
}
