using Sl_Resturent_API.Models;
using Sl_Resturent_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sl_Resturent_API.Controllers;

[ApiController]
[Route("[controller]")]
public class FoodController : ControllerBase
{
    public FoodController()
    {
    }

    // GET all pizzas
    [HttpGet]
    public ActionResult<List<Foods>> GetAll() =>
    FoodService.GetAll();

    // GET by Id action,Retrieve a single pizza
    [HttpGet("{id}")]
    public ActionResult<Foods> Get(int id)
    {
        var pizza = FoodService.Get(id);

        if(pizza == null)
            return NotFound();

        return pizza;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Foods pizza)
    {            
        FoodService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }
    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Foods pizza)
    {
        if (id != pizza.Id)
            return BadRequest();
            
        var existingPizza = FoodService.Get(id);
        if(existingPizza is null)
            return NotFound();
    
        FoodService.Update(pizza);           
    
        return NoContent();
    }
    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = FoodService.Get(id);
    
        if (pizza is null)
            return NotFound();
        
        FoodService.Delete(id);
    
        return NoContent();
    }
}