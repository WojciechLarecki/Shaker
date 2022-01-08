using Microsoft.AspNetCore.Mvc;
using Shaker.WebUI.Models;
using Shaker.WebUI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shaker.WebUI.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;

        public DrinkController(IDrinkRepository dr)
        {
            _drinkRepository = dr;
        }

        [Route("Drink/{drinkFirstLetter?}")]
        public async Task<IActionResult> Index(char? drinkFirstLetter = null)
        {
            if (drinkFirstLetter.HasValue)
            {
                var drinks = await _drinkRepository.GetAllCoctailsByLetterAsync(drinkFirstLetter.Value);

                return View(drinks);
            }
            return View();
        }

        [Route("Drink/Details/{drinkId}")]
        public async Task<IActionResult> DrinkDetails(int drinkId)
        {
            var drink = await _drinkRepository.GetCoctailById(drinkId);
            var drinkViewModel = new DrinkDetailsViewModel(drink);

            return View(drinkViewModel);
        }

        public async Task<IActionResult> GetRandomDrink()
        {
            var coctail = await _drinkRepository.GetRandomCoctailAsync();

            return RedirectToAction("DrinkDetails", new { drinkId = coctail.IdDrink });
        }
    }
}
