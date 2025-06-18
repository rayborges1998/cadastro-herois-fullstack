namespace CadastroHeroisAPI.DTO
{
    public class GetHeroiDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }

        public List<string> Superpoderes { get; set; } = new();
    }
}
