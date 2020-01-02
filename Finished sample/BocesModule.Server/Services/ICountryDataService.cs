using System.Collections.Generic;
using System.Threading.Tasks;
using BocesModule.Shared;

namespace BocesModule.Server.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
    }
}
