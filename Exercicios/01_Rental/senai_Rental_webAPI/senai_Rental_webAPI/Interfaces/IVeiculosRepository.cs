using senai_Rental_webAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Rental_webAPI.Interfaces
{
    interface IVeiculosRepository
    {
        List<VeiculosDomain> ListarTodos();


        VeiculosDomain BuscarPorId(int idVeiculo);

        void Cadastrar(VeiculosDomain novoVeiculo);


        void AtualizarIdCorpo(VeiculosDomain VeiculoAtualizado);



        void Deletar(int idVeiculo);
    }
}
