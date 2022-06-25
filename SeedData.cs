namespace BlazingPizza;
/// <summary>
/// 数据种子 初始化用
/// </summary>
public static class SeedData
{
    public static void Initialize(PizzaStoreContext db)
    {
        var specials = new PizzaSpecial[]
        {
            new PizzaSpecial()
            {
                Name = "Basic Cheese Pizza",
                Description = "It's cheesy and delicious. Why wouldn't you want one?",
                BasePrice = 9.99m,
                ImageUrl = "img/pizzas/cheese.jpg",
            },
            new PizzaSpecial()
            {
                Id = 2,
                Name = "The Baconatorizor",
                Description = "It has EVERY kind of bacon",
                BasePrice = 11.99m,
                ImageUrl = "img/pizzas/bacon.jpg",
            },
            new PizzaSpecial()
            {
                Id = 3,
                Name = "Classic Pepperoni",
                Description = "It's the pizza you grew up with, but Blazing hot!",
                BasePrice = 10.50m,
                ImageUrl = "img/pizzas/pepperoni.jpg",
            },
            new PizzaSpecial()
            {
                Id = 4,
                Name = "Buffalo Chicken",
                Description = "Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up",
                BasePrice = 12.75m,
                ImageUrl = "img/pizzas/meaty.jpg",
            },
            new PizzaSpecial()
            {
                Id = 5,
                Name = "Mushroom Lovers",
                Description = "It has mushrooms. Isn't that obvious?",
                BasePrice = 11.00m,
                ImageUrl = "img/pizzas/mushroom.jpg",
            },
            new PizzaSpecial()
            {
                Id = 6,
                Name = "The Brit",
                Description = "When in London...",
                BasePrice = 10.25m,
                ImageUrl = "img/pizzas/brit.jpg",
            },
            new PizzaSpecial()
            {
                Id = 7,
                Name = "Veggie Delight",
                Description = "It's like salad, but on a pizza",
                BasePrice = 11.50m,
                ImageUrl = "img/pizzas/salad.jpg",
            },
            new PizzaSpecial()
            {
                Id = 8,
                Name = "Margherita",
                Description = "Traditional Italian pizza with tomatoes and basil",
                BasePrice = 9.99m,
                ImageUrl = "img/pizzas/margherita.jpg",
            },
        };

        var sauces = new Sauce[] {
            new Sauce() {
                Id = 1,
                Name = "Tomato Sauce",
                Price = 1.50m
            },
            new Sauce() {
                Id = 2,
                Name = "Basil Sauce",
                Price = 2.00m
            },
            new Sauce() {
                Id = 3,
                Name = "Thai Chili Sauce",
                Price = 2.50m
            },
            new Sauce() {
                Id = 4,
                Name = "Honey Mustard Sauce",
                Price = 2.25m
            }
        };

        var fruits = new Fruit[] {
            new Fruit() {
                Id = 1,
                Name = "Eggplant",
                Price = 0.50m
            },
            new Fruit() {
                Id = 2,
                Name = "Olive",
                Price = 1.00m
            },
            new Fruit() {
                Id = 3,
                Name = "Green Pepper",
                Price = 0.23m
            },
            new Fruit() {
                Id = 4,
                Name = "Pineapple",
                Price = 0.35m
            },
            new Fruit() {
                Id = 5,
                Name = "Blueberry",
                Price = 1.50m
            }
        };

        db.Specials.AddRange(specials);
        db.Sauces.AddRange(sauces);
        db.Fruits.AddRange(fruits);
        db.SaveChanges();
    }
}