using CadastroHeroisAPI.DTO;
using CadastroHeroisAPI.Models;
using Microsoft.AspNetCore.Builder;

namespace CadastroHeroisAPI.Extensions
{
        public static class CadastroHeroisExtension
        {
            public static void CadastroHerois(this WebApplication app)
            {
                app.MapGet("CadastroHeroisAPI", () => "Cadastro de Herois!");
            }

            //public static GetHeroiDto ToGetHeroiDto(this HeroisModel heroi)
            //{
            //    return new GetHeroiDto
            //    {
            //        Id = heroi.Id,
            //        Nome = heroi.Nome,
            //        NomeHeroi = heroi.NomeHeroi,
            //        DataDeNascimento = heroi.DataDeNascimento,
            //        Altura = heroi.Altura,
            //        Peso = heroi.Peso,
            //        Superpoderes = heroi.HeroisSuperpoderes
            //            .Select(sp => sp.Heroi.Superpoderes.Descricao)
            //            .ToList()
            //    };
            //}
        }
    }
