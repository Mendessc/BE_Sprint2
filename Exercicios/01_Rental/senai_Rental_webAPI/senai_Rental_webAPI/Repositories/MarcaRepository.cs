using senai_Rental_webAPI.Domain;
using senai_Rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Rental_webAPI.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        public void AtualizarIdCorpo(MarcaDomain MarcaAtualizado)
        {
            throw new NotImplementedException();
        }


        public void Cadastrar(MarcaDomain novoMarca)
        {
            throw new NotImplementedException();
        }


        public void Deletar(int idMarca)
        {
            throw new NotImplementedException();
        }


        MarcaDomain IMarcaRepository.BuscarPorId(int idMarca)
        {
            throw new NotImplementedException();
        }

        List<MarcaDomain> IMarcaRepository.ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
