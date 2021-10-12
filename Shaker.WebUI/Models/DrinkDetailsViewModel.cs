using System.Collections.Generic;

namespace Shaker.WebUI.Models
{
    public class DrinkDetailsViewModel
    {
        public DrinkDetailsViewModel(Drink drink)
        {
            Drink = drink;
            DrinkComponents = InitializeConmponents();
        }

        private Dictionary<string, string> InitializeConmponents()
        {
            var output = new Dictionary<string, string>();
            object ingridient;
            object quantity;

            for (int i = 1; i <= 15; i++)
            {
                ingridient = typeof(Drink).GetProperty("StrIngredient" + i).GetValue(Drink);
                quantity = typeof(Drink).GetProperty("StrMeasure" + i).GetValue(Drink);

                if (ingridient != null && quantity != null)
                {
                    output.Add(ingridient.ToString(), quantity.ToString());
                }
            }

            return output;
        }

        public Drink Drink { get; set; }
        public Dictionary<string, string> DrinkComponents { get; set; }
    }
}
