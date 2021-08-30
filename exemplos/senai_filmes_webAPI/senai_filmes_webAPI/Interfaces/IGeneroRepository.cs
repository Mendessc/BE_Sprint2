using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// interface responsavel pelo repositorio GeneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        List<GeneroDomain> ListarTodos();

        GeneroDomain BuscarPorId(int idGenero);

        void Cadastrar(GeneroDomain novoGenero);

        void AtualizarIdCorpo(GeneroDomain generoAtualizado);

        void Deletar(int idGenero);
    }
}
