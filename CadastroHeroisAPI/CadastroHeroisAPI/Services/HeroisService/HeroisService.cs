using CadastroHeroisAPI.Data;
using CadastroHeroisAPI.DTO;
using CadastroHeroisAPI.Models;
using CadastroHeroisAPI.Services.HeroisService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CadastroHeroisAPI.Services.Herois
{

    public class HeroisService : IHeroisInterface


    {
        private readonly AppDbContext _context;
        public HeroisService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<HeroisModel>>> CreateHeroi(AddHeroiDto novoHeroi)
        {
            var response = new ServiceResponse<List<HeroisModel>>();

            if (await _context.Herois.AnyAsync(h => h.NomeHeroi.ToLower() == novoHeroi.NomeHeroi.ToLower()))
            {
                response.Sucesso = false;
                response.Mensagem = "Já existe um herói com esse NomeHeroi.";
                return response;
            }

            var heroi = new HeroisModel
            {
                Nome = novoHeroi.Nome,
                NomeHeroi = novoHeroi.NomeHeroi,
                DataDeNascimento = novoHeroi.DataDeNascimento,
                Altura = novoHeroi.Altura,
                Peso = novoHeroi.Peso,
                Superpoderes = new List<HeroisSuperpoderesModel>()
            };

            foreach (int spId in novoHeroi.SuperpoderesIds)
            {
                var superpoder = await _context.Superpoderes.FindAsync(spId);
                if (superpoder != null)
                {
                    heroi.Superpoderes.Add(new HeroisSuperpoderesModel
                    {
                        Heroi = heroi,
                        Superpoder = superpoder,
                        HeroisId = heroi.Id,
                        SuperpoderesId = superpoder.Id
                    });
                }
            }

            _context.Herois.Add(heroi);
            await _context.SaveChangesAsync();

            response.Dados = await _context.Herois.ToListAsync();

            return response;
        }


        public async Task<ServiceResponse<List<HeroisModel>>> DeleteHeroi(int id)
        {
            ServiceResponse<List<HeroisModel>> serviceResponse = new ServiceResponse<List<HeroisModel>>();

            try
            {
                HeroisModel heroi = _context.Herois.FirstOrDefault(x => x.Id == id);

                if (heroi == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Herói não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }


                _context.Herois.Remove(heroi);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Herois.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<HeroisModel>> GetHeroiById(int id)
        {
            ServiceResponse<HeroisModel> serviceResponse = new ServiceResponse<HeroisModel>();

            try
            {
                HeroisModel heroi = _context.Herois.FirstOrDefault(x => x.Id == id);

                serviceResponse.Dados = heroi;

                if (serviceResponse.Dados == null)
                {
                    serviceResponse.Mensagem = "Heroi não encontrado!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<HeroisModel>>> GetHerois()
        {
            ServiceResponse<List<HeroisModel>> serviceResponse = new ServiceResponse<List<HeroisModel>>();

            try
            {

                serviceResponse.Dados = _context.Herois.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum herói encontrado!";
                }


            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<HeroisModel>>> UpdateHeroi(HeroisModel editarHeroi)
        {
            ServiceResponse<List<HeroisModel>> serviceResponse = new ServiceResponse<List<HeroisModel>>();

            try
            {
                HeroisModel heroi = _context.Herois.AsNoTracking().FirstOrDefault(x => x.Id == editarHeroi.Id);

                if (heroi == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }
                               
                _context.Herois.Update(editarHeroi);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Herois.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<List<SuperpoderesModel>> GetSuperpoderes()
{
    return await _context.Superpoderes.ToListAsync();
}

      
    }
}