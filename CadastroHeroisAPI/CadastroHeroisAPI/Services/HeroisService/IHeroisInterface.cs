using CadastroHeroisAPI.DTO;
using CadastroHeroisAPI.Models;

namespace CadastroHeroisAPI.Services.HeroisService
{
    public interface IHeroisInterface
    {
        Task<ServiceResponse<List<HeroisModel>>> GetHerois();
        Task<ServiceResponse<List<HeroisModel>>> CreateHeroi(AddHeroiDto novoHeroi);
        Task<ServiceResponse<HeroisModel>> GetHeroiById(int id);
        Task<ServiceResponse<List<HeroisModel>>> UpdateHeroi(HeroisModel editarHeroi);
        Task<ServiceResponse<List<HeroisModel>>> DeleteHeroi(int id);
        Task<List<SuperpoderesModel>> GetSuperpoderes();
        //Task<object?> UpdateHeroi(UpdateHeroiDto editarHeroi);
    }
}

