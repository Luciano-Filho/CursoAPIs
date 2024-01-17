using EstudandoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstudandoAPI.Controllers;
[ApiController]
[Route("[controller]")]


public class CarrosController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private static int id = 1;
    private static List<CarroModel> carros  = new List<CarroModel>();

    public CarrosController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public ActionResult AdicionaCarro([FromBody] CarroModel carro)
    {
        carro.Id = id++;
        carros.Add(carro);
        return CreatedAtAction(nameof(RetornaCarroPorId), new { id = carro.Id }, carro);
    }
    [HttpGet]
    public IEnumerable<CarroModel> RetornaCarros(int skip = 0, int take = 5)
    {
        return carros.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public ActionResult RetornaCarroPorId(int id)
    {
        var carro = carros.FirstOrDefault(x => x.Id == id);
        if(carro == null)
        {
            return NotFound($"Nenhum carro encontrado com o id {id}");
        }
        return Ok(carro);
    }

    [HttpDelete("{id}")]
    public ActionResult ApagaCarro(int id)
    {
        var carro = carros.FirstOrDefault(x => x.Id == id);
        if (carro == null) return NotFound($"Nenhum carro encontrado com o id {id}");
        
        carros.Remove(carro);
        return Ok("Carro Apagado!");

    }
}

