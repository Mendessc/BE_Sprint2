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

        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero) 
        {
            _GeneroRepository.Cadastrar(novoGenero);

            return StatusCode(201);

        }
    }
}
