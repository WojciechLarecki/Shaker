using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shaker.WebUI.Models.Interfaces
{
    public interface IDrinkRepository
    {
        Task<IEnumerable<Drink>> GetAllCoctailsByLetterAsync(char a);
        Task<Drink> GetCoctailById(int drinkId);
        Task<Drink> GetRandomCoctailAsync();
    }
}