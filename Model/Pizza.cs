using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace BlazingPizza
{

    /// <summary>
    /// 定制后的披萨（信息完整）
    /// </summary>
    public class Pizza
    {
        public const int DefaultSize = 12;
        public const int MinimumSize = 9;
        public const int MaximumSize = 17;

        public int Id { get; set; }

        public int OrderId { get; set; }

        public PizzaSpecial Special { get; set; }

        public int SpecialId { get; set; }

        public int Size { get; set; }

        public List<PizzaTopping> Toppings { get; set; }

        public List<PizzaSauce> Sauces { get; set; }

        public List<PizzaFruit> Fruits { get; set; }

        public decimal GetBasePrice() {
            return ((decimal)Size / (decimal)DefaultSize) * Special.BasePrice;
        }

        public decimal GetTotalPrice() {
            decimal totalPrice = GetBasePrice();
            if (Sauces != null) {
                totalPrice += Sauces.Sum(s => s.Sauce.Price);
            }
            if(Fruits != null) {
                totalPrice += Fruits.Sum(f => f.Fruit.Price);
            }
            return totalPrice;
        }

        public String GetFormattedTotalPrice() {
            return DllHelper.GetFormattedPrice(Decimal.ToDouble(GetTotalPrice()));
        }
    }
}
