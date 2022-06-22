using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza;

// 水果
[Route("fruits")]
[ApiController]
public class FruitsController : Controller {
    private readonly PizzaStoreContext _db;

    public FruitsController(PizzaStoreContext db) {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Fruit>>> GetPizzas() {
        return (await _db.Fruits.ToListAsync()).OrderByDescending(f => f.Price).ToList();
    }

}