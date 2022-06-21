using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza;

[Route("sauces")]
[ApiController]
public class SaucesController : Controller
{
    private readonly PizzaStoreContext _db;

    public SaucesController(PizzaStoreContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Sauce>>> GetPizzas()
    {
        return (await _db.Sauces.ToListAsync()).OrderByDescending(s => s.Price).ToList();
    }

}