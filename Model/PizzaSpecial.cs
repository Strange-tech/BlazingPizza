namespace BlazingPizza
{
    /// <summary>
    /// 披萨模板（底子）
    /// </summary>
    public class PizzaSpecial
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal BasePrice { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string GetFormattedBasePrice() {
            return DllHelper.GetFormattedPrice(Decimal.ToDouble(BasePrice));
        }
    }
}
