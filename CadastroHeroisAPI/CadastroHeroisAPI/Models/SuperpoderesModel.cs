using System.ComponentModel.DataAnnotations;
using CadastroHeroisAPI.Models;

namespace CadastroHeroisAPI.Models
{
    public class SuperpoderesModel
    {
        public int Id { get; set; }
        public string Superpoder { get; set; }
        public string Descricao { get; set; }

        public List<HeroisSuperpoderesModel> Herois { get; set; } = new();
    }
}