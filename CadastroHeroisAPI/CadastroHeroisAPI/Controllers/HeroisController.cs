using CadastroHeroisAPI.DTO;
using CadastroHeroisAPI.Models;
using CadastroHeroisAPI.Services.HeroisService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CadastroHeroisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroisController : ControllerBase
    {
        private readonly IHeroisInterface _heroisInterface;
        public HeroisController(IHeroisInterface heroisInterface)
        {
            _heroisInterface = heroisInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetHeroiDto>>>> GetHerois()
        {
            return Ok(await _heroisInterface.GetHerois());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<HeroisModel>>> GetHeroiById(int id)
        {
            ServiceResponse<HeroisModel> serviceResponse = await _heroisInterface.GetHeroiById(id);
            return Ok(serviceResponse);
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<HeroisModel>>> CreateHeroi(AddHeroiDto novoHeroi)
        {
            return Ok(await _heroisInterface.CreateHeroi(novoHeroi));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<HeroisModel>>> UpdateHeroi(HeroisModel editarHeroi)

        {
            ServiceResponse<List<HeroisModel>> serviceResponse = (ServiceResponse<List<HeroisModel>>)await _heroisInterface.UpdateHeroi(editarHeroi);   
            return Ok(await _heroisInterface.UpdateHeroi(editarHeroi));
        }

        [HttpGet("superpoderes")]
        public async Task<ActionResult<List<SuperpoderesModel>>> GetSuperpoderes()
        {
            var superpoderes = await _heroisInterface.GetSuperpoderes();
            return Ok(superpoderes);
        }
    }
}
