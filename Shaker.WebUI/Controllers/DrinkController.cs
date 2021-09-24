﻿using Microsoft.AspNetCore.Mvc;
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
    }
}