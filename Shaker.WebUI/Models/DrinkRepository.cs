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
            var uri = _config.GetConnectionString("GetAllCoctailsByLetter") + a.ToString();
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync(uri);
            drinkArray = await ValidateResonse(response);

            return drinkArray.drinks;
        }

        public async Task<Drink> GetCoctailById(int drinkId)
        {
            DrinkArray drinkArray;
            var client = _httpClient.CreateClient();
            var uri = _config.GetConnectionString("GetCoctailById") + drinkId;
            var response = await client.GetAsync(uri);
            drinkArray = await ValidateResonse(response);

            return drinkArray.drinks.First();
        }

        public async Task<Drink> GetRandomCoctailAsync()
        {
            DrinkArray drinkArray;
            var client = _httpClient.CreateClient();
            var uri = _config.GetConnectionString("GetRandomCoctail");
            var response = await client.GetAsync(uri);
            drinkArray = await ValidateResonse(response);

            return drinkArray.drinks.First();
        }

        private static async Task<DrinkArray> ValidateResonse(HttpResponseMessage response)
        {
            DrinkArray drinkArray;

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

            return drinkArray;
        }
    }
}
