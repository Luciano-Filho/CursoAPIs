using System.ComponentModel.DataAnnotations;

namespace EstudandoAPI.Models;

public class CarroModel
{
    public int Id { get; set; }
    public string Cor { get; set; }
    public int QuantidadePortas { get; set; }
    public string Fabricante { get; set; }
    public string Modelo { get; set; }
}
