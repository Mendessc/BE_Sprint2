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
    public class ClientesController : ControllerBase
    {
        private IClientesRepository _ClienteRepository { get; set; }

        public ClientesController()
        {
            _ClienteRepository = new ClientesRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClientesDomain> listaCliente = _ClienteRepository.ListarTodos();

            return Ok(listaCliente);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClientesDomain clienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
            {
                return NotFound("Nenhum cliente encontrado");
            }

            return Ok(clienteBuscado);
        }

        [HttpPut]
        public IActionResult PutIdBody(ClientesDomain clienteAtualizado)
        {
            if (clienteAtualizado.nomeCliente == null || clienteAtualizado.sobrenomeCliente == null || clienteAtualizado.idCliente <= 0)
            {
                return BadRequest(
                        new
                        {
                            mensagem = "As Informações não foram informadas corretamente! "
                        }
                    );
            }
            ClientesDomain clienteBuscado = _ClienteRepository.BuscarPorId(clienteAtualizado.idCliente);

            if (clienteBuscado != null)
            {
                try
                {
                    _ClienteRepository.AtualizarIdCorpo(clienteAtualizado);
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
                        mensagem = "Cliente não encontrado",
                        erroStatus = true
                    }
                );
        }

        [HttpPost]
        public IActionResult Post(ClientesDomain novoCliente)
        {
            _ClienteRepository.Cadastrar(novoCliente);
            return StatusCode(201);
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ClienteRepository.Deletar(id);
            return StatusCode(204);

        }
    }
}

