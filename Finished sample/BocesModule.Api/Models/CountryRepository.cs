using System.Collections.Generic;
using System.Linq;
using BocesModule.Shared;

namespace BocesModule.Api.Models
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CountryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            // return _appDbContext.Countries;
            return new List<Country>();
        }

        public Country GetCountryById(int countryId)
        {
            // return _appDbContext.Countries.FirstOrDefault(c => c.CountryId == countryId);
            return new Country();
        }
    }
}
