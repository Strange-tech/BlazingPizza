namespace BlazingPizza
{
    // 披萨-酱汁 关系
    public class PizzaSauce
    {
        public Sauce Sauce { get; set; }

        public int SauceId { get; set; }

        public int PizzaId { get; set; }
    }
}