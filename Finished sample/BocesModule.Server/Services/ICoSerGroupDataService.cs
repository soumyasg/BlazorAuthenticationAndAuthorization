using System.Collections.Generic;
using System.Threading.Tasks;
using BocesModule.Shared;

namespace BocesModule.Server.Services
{
    public interface ICoSerGroupDataService
    {
        Task<IEnumerable<CoSerGroup>> GetAllCoSerGroups();
        Task<CoSerGroup> GetCoSerGroupById(int coSerGroupId);
    }
}
