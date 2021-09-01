using senai_Rental_webAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Rental_webAPI.Interfaces
{
    interface IClientesRepository
    {
        List<ClientesDomain> ListarTodos();


        ClientesDomain BuscarPorId(int idCliente);

        void Cadastrar(ClientesDomain novoCliente);


        void AtualizarIdCorpo(ClientesDomain ClienteAtualizado);



        void Deletar(int idCliente);
    }
}
