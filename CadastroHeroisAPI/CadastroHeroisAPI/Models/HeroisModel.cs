using CadastroHeroisAPI.Models;

public class HeroisModel
{
    internal readonly IEnumerable<int> SuperpoderesIds;

    public int Id { get; set; }  
    public string Nome { get; set; }
    public string NomeHeroi { get; set; }  
    public DateTime DataDeNascimento { get; set; }
    public float Altura { get; set; }
    public float Peso { get; set; }

    public List<HeroisSuperpoderesModel> Superpoderes { get; set; } = new();
}