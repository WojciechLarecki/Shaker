using System.Collections.Generic;

namespace Shaker.WebUI.Models.Interfaces
{
    public interface IDrinkRepository
    {
        IEnumerable<Drink> GetAllCoctailsByLetter(char a);
    }
}