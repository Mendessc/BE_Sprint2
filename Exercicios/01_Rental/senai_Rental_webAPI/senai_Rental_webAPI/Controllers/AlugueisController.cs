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
    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }

        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> listaAlugueis = _AluguelRepository.ListarTodos();

            return Ok(listaAlugueis);
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain novoVeiculo)
        {
            _AluguelRepository.Cadastrar(novoVeiculo);
            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _AluguelRepository.Deletar(id);
            return StatusCode(204);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarPorId(id);

            if (aluguelBuscado == null)
            {
                return NotFound("Nenhum aluguel encontrado");
            }

            return Ok(aluguelBuscado);
        }

        [HttpPut]
        public IActionResult PutIdBody(AluguelDomain aluguelAtualizado)
        {
            if (aluguelAtualizado.idCliente == 0 || aluguelAtualizado.idVeiculo == 0 || aluguelAtualizado.idAluguel <= 0)
            {
                return BadRequest(
                        new
                        {
                            mensagem = "As Informações não foram informadas corretamente! "
                        }
                    );
            }
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarPorId(aluguelAtualizado.idAluguel);

            if (aluguelBuscado != null)
            {
                try
                {
                    _AluguelRepository.AtualizarIdCorpo(aluguelAtualizado);
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
                        mensagem = "Aluguel não encontrado",
                        erroStatus = true
                    }
                );
        }
    }
}
