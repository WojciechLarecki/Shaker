using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shaker.WebUI.Models.Interfaces;
using Shaker.WebUI.Models;
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

        [HttpGet]
        public async Task<IEnumerable<Drink>> GetAllCoctailsByLetterAsync(char a)
        {
            DrinkArray drinkArray;
            var client = _httpClient.CreateClient();
            var uri = _config.GetConnectionString("GetAllCoctailsByLetter") + a.ToString();
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var responseString = await response.Content.ReadAsStringAsync();
                drinkArray = JsonSerializer.Deserialize<DrinkArray>(responseString, options);
            }
            else
            {
                drinkArray = null;
            }

            return drinkArray.drinks;
        }
    }
}
