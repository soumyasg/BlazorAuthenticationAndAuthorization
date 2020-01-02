using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BocesModule.Shared;

namespace BocesModule.Api.Models
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
    }
}
