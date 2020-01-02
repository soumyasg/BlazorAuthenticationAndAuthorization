using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BocesModule.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace BocesModule.Server.Services
{
    public class CoSerGroupDataService : ICoSerGroupDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CoSerGroupDataService(HttpClient httpClient,
                                        IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient ??
                throw new System.ArgumentNullException(nameof(httpClient));
            _httpContextAccessor = httpContextAccessor ??
                throw new System.ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<IEnumerable<CoSerGroup>> GetAllCoSerGroups()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            if (accessToken != null)
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            }
            return await JsonSerializer.DeserializeAsync<IEnumerable<CoSerGroup>>
                (await _httpClient.GetStreamAsync($"api/cosergroups"), new JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
        }


        public async Task<CoSerGroup> GetCoSerGroupById(int coSerGroupId)
        {
            return await JsonSerializer.DeserializeAsync<CoSerGroup>
                (await _httpClient.GetStreamAsync($"api/cosergroups{coSerGroupId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

    }
}
