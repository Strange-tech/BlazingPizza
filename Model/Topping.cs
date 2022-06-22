﻿namespace BlazingPizza
{
    public class Topping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string GetFormattedPrice() {
            return DllHelper.GetFormattedPrice(Decimal.ToDouble(Price));
        }
    }
}
