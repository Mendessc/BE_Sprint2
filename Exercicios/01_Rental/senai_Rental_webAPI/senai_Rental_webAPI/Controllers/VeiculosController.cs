using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_Rental_webAPI.Domain;
using senai_Rental_webAPI.Interfaces;
using senai_Rental_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Rental_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private IVeiculosRepository _VeiculosRepository { get; set; }

        public VeiculosController()
        {
            _VeiculosRepository = new VeiculosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculosDomain> listaVeiculos = _VeiculosRepository.ListarTodos();

            return Ok(listaVeiculos);
        }

        [HttpPost]
        public IActionResult Post(VeiculosDomain novoVeiculo)
        {
            _VeiculosRepository.Cadastrar(novoVeiculo);
            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _VeiculosRepository.Deletar(id);
            return StatusCode(204);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculosDomain veiculoBuscado = _VeiculosRepository.BuscarPorId(id);

            if (veiculoBuscado == null)
            {
                return NotFound("Nenhum veículo encontrado");
            }

            return Ok(veiculoBuscado);
        }

        [HttpPut]
        public IActionResult PutIdBody(VeiculosDomain veiculoAtualizado)
        {
            if (veiculoAtualizado.idEmpresa == 0 || veiculoAtualizado.idModelo == 0 || veiculoAtualizado.idVeiculo <= 0 || veiculoAtualizado.placa == null)
            {
                return BadRequest(
                        new
                        {
                            mensagem = "As Informações não foram informadas corretamente! "
                        }
                    );
            }
            VeiculosDomain veiculoBuscado = _VeiculosRepository.BuscarPorId(veiculoAtualizado.idVeiculo);

            if (veiculoBuscado != null)
            {
                try
                {
                    _VeiculosRepository.AtualizarIdCorpo(veiculoAtualizado);
                    return NoContent();
                }
                catch (Exception codErro)
                {

                    return BadRequest(codErro);
                }
            }
            return NotFound(
                    new
                    {
                        mensagem = "Veículo não encontrado",
                        erroStatus = true
                    }
                );
        }
    }
}
