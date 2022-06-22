using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza;

// 订单控制器，所有函数均异步执行
[Route("orders")]
[ApiController]
public class OrdersController : Controller {
    private readonly PizzaStoreContext _db;

    public OrdersController(PizzaStoreContext db) {
        _db = db;
    }

    // 查看所有订单，附带状态。使用OrderWithStatus包装
    [HttpGet]
    public async Task<ActionResult<List<OrderWithStatus>>> GetOrders() {
        var orders = await _db.Orders
 	    .Include(o => o.Pizzas).ThenInclude(p => p.Special)
        .Include(o => o.Pizzas).ThenInclude(s => s.Sauces).ThenInclude(t => t.Sauce)
        .Include(o => o.Pizzas).ThenInclude(f => f.Fruits).ThenInclude(t => t.Fruit)
 	    .OrderByDescending(o => o.CreatedTime)
 	    .ToListAsync();

        return orders.Select(o => OrderWithStatus.FromOrder(o)).ToList();
    }

    // 生成订单，只需显示包含披萨模板，其他成分在联系表中插入
    [HttpPost]
    public async Task<ActionResult<int>> PlaceOrder(Order order) {
        order.CreatedTime = DateTime.Now;
        //
        foreach (var pizza in order.Pizzas)
        {
            pizza.SpecialId = pizza.Special.Id;
            pizza.Special = null;
        }

        _db.Orders.Attach(order);
        await _db.SaveChangesAsync();

        return order.OrderId;
    }

    // 查看单一订单，与查看所有类似
    [HttpGet("{orderId}")]
    public async Task<ActionResult<OrderWithStatus>> GetOrderWithStatus(int orderId) {
        var order = await _db.Orders
            .Where(o => o.OrderId == orderId)
            .Include(o => o.Pizzas).ThenInclude(p => p.Special)
            .Include(o => o.Pizzas).ThenInclude(s => s.Sauces).ThenInclude(t => t.Sauce)
            .Include(o => o.Pizzas).ThenInclude(f => f.Fruits).ThenInclude(t => t.Fruit)
            .SingleOrDefaultAsync();

        if (order == null) {
            return NotFound();
        }

        return OrderWithStatus.FromOrder(order);
    }
}