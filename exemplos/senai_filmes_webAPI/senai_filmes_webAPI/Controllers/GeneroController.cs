using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Controllers
{
    [Produces ("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private IGeneroRepository _GeneroRepository { get; set; }

        public GeneroController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        [HttpGet]
        public IActionResult Get()
        { 
            List<GeneroDomain> listaGeneros = _GeneroRepository.ListarTodos();

            return Ok(listaGeneros);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound("Nenhum Genero foi encontrado");
            }

            return Ok(generoBuscado);
        }

        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero) 
        {
            _GeneroRepository.Cadastrar(novoGenero);

            return StatusCode(201);
        }

        [HttpDelete("{idGenero}")]
        public IActionResult Delete(int idGenero)
        {
            _GeneroRepository.Deletar(idGenero);

            return NoContent();
        }

        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {
            if (generoAtualizado.nomeGenero == null || generoAtualizado.idGenero <= 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Nome ou Id do Genero nao foi informado!"
                    });
            }

            GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(generoAtualizado.idGenero);

            if (generoBuscado != null)
            {
                try
                {
                    _GeneroRepository.AtualizarIdCorpo(generoAtualizado);

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
                    mensagem = "Genero nao encontrado!",
                    errorStatus = true
                }

                );
        }
    }
}
