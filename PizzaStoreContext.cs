using Microsoft.EntityFrameworkCore;

namespace BlazingPizza;

public class PizzaStoreContext : DbContext
{
    public PizzaStoreContext(
        DbContextOptions options) : base(options)
    {
    }

    // 数据库中创建的表，名为Id的属性自动成为自增主键
    // 对于类中写好的一对一实体，数据库会自动在实体1中创建实体2的主键
    public DbSet<Order> Orders { get; set; }

    public DbSet<Pizza> Pizzas { get; set; }

    public DbSet<PizzaSpecial> Specials { get; set; }

    public DbSet<Topping> Toppings { get; set; }

    public DbSet<Sauce> Sauces { get; set; }

    public DbSet<Fruit> Fruits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 建立模型时的初始化工作：创建多对多实体的关联表，数据库中体现为由两个主键构成的实体

        //
        modelBuilder.Entity<PizzaTopping>().HasKey(pst => new { pst.PizzaId, pst.ToppingId });
        modelBuilder.Entity<PizzaTopping>().HasOne<Pizza>().WithMany(ps => ps.Toppings);
        modelBuilder.Entity<PizzaTopping>().HasOne(pst => pst.Topping).WithMany();

        // 配置Pizza-Sauce主码与多对多关系
        modelBuilder.Entity<PizzaSauce>().HasKey(pst => new { pst.PizzaId, pst.SauceId });
        modelBuilder.Entity<PizzaSauce>().HasOne<Pizza>().WithMany(ps => ps.Sauces);
        modelBuilder.Entity<PizzaSauce>().HasOne(pst => pst.Sauce).WithMany();

        // 配置Pizza-Fruit主码与多对多关系
        modelBuilder.Entity<PizzaFruit>().HasKey(pst => new { pst.PizzaId, pst.FruitId });
        modelBuilder.Entity<PizzaFruit>().HasOne<Pizza>().WithMany(ps => ps.Fruits);
        modelBuilder.Entity<PizzaFruit>().HasOne(pst => pst.Fruit).WithMany();
    }

}