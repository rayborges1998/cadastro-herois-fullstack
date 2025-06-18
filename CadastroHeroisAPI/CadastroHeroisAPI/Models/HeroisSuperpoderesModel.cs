using System.ComponentModel.DataAnnotations;

namespace CadastroHeroisAPI.Models
{
    public class HeroisSuperpoderesModel
    {
        public int HeroisId { get; set; }
        public HeroisModel Heroi { get; set; }

        public int SuperpoderesId { get; set; }
        public SuperpoderesModel Superpoder { get; set; }
    }
}
