using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BocesModule.Shared;

namespace BocesModule.Server.Services
{
    public class CoSerGroupDataService : ICoSerGroupDataService
    {
        private readonly HttpClient _httpClient;

        public CoSerGroupDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CoSerGroup>> GetAllCoSerGroups()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<CoSerGroup>>
                (await _httpClient.GetStreamAsync($"api/cosergroups"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


        public async Task<CoSerGroup> GetCoSerGroupById(int coSerGroupId)
        {
            return await JsonSerializer.DeserializeAsync<CoSerGroup>
                (await _httpClient.GetStreamAsync($"api/cosergroups{coSerGroupId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

    }
}
