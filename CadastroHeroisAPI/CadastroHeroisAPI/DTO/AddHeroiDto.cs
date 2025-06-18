namespace CadastroHeroisAPI.DTO
{
    public class AddHeroiDto
    {
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public List<int> SuperpoderesIds { get; set; }
    }
}
