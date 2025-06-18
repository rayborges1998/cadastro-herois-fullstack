using CadastroHeroisAPI.Data;
using CadastroHeroisAPI.Models;
using CadastroHeroisAPI.Services.HeroisService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroHeroisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpoderesController : ControllerBase
    {
            private readonly AppDbContext _context;

            public SuperpoderesController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<List<SuperpoderesModel>>> GetSuperpoderes()
            {
                return Ok(await _context.Superpoderes.ToListAsync());
            }
        }


    }
