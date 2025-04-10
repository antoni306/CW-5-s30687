using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;
[ApiController]
[Route("[controller]")]
public class AnimalController : Controller
{
    private List<Animal> animals = 
            [
                new Animal(1,"Reks","York",1.7,"White"),
                new Animal(2,"Princess","Pitbull",3.5,"Black"),
                new Animal(3,"Perla","Husky",4.2,"Brown")
            ];

   
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(animals);
    }
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
            return NotFound();
        return Ok(animal);
    }
    [HttpPost]
    public IActionResult AddAnimal([FromBody] Animal animal)
    {
        int id = animals.Max(a => a.Id) + 1;
        animal.Id = id;
        
        animals.Add(animal);
        return Created($"/animals/{animal.Id}",animal);
    }
}