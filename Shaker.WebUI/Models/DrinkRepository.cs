using Shaker.WebUI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shaker.WebUI.Models
{
    public class DrinkRepository : IDrinkRepository
    {
        public IEnumerable<Drink> GetAllCoctailsByLetter(char a)
        {
            throw new NotImplementedException();
        }
    }
}
