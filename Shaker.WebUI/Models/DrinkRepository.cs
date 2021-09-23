using Microsoft.Extensions.Configuration;
using Shaker.WebUI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shaker.WebUI.Models
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _config;

        public DrinkRepository(IHttpClientFactory httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        public async Task<IEnumerable<Drink>> GetAllCoctailsByLetterAsync(char a)
        {
            IEnumerable<Drink> drinks;
            var client = _httpClient.CreateClient();
            var uri = _config.GetConnectionString("GetAllCoctailsByLetter");
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var responseString = await response.Content.ReadAsStringAsync();
                drinks = JsonSerializer.Deserialize<IEnumerable<Drink>>(responseString, options);
            }
            else
            {
                drinks = null;
            }

            return drinks;
        }
    }
}
