namespace BlazingPizza
{
    /// <summary>
    /// 酱汁
    /// </summary>
    public class Sauce
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string GetFormattedPrice() {
            return DllHelper.GetFormattedPrice(Decimal.ToDouble(Price));
        }
    }
}