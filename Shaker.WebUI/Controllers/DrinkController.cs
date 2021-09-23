using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index(char? drinkFirstLetter = null)
        {
            if (drinkFirstLetter.HasValue)
            {
                var drinks = _drinkRepository.GetAllCoctailsByLetter(drinkFirstLetter.Value);

                return View(drinks);
            }
            return View();
        }
    }
}
