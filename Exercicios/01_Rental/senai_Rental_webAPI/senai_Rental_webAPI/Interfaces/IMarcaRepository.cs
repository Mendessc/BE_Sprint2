using senai_Rental_webAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Rental_webAPI.Interfaces
{
    interface IMarcaRepository
    {
        List<MarcaDomain> ListarTodos();


        MarcaDomain BuscarPorId(int idMarca);

        void Cadastrar(MarcaDomain novoMarca);


        void AtualizarIdCorpo(MarcaDomain MarcaAtualizado);



        void Deletar(int idMarca);
    }
}
