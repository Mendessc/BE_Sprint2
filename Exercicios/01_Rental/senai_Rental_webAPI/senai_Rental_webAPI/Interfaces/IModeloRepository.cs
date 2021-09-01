using senai_Rental_webAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Rental_webAPI.Interfaces
{
    interface IModeloRepository
    {
        List<ModeloDomain> ListarTodos();


        ModeloDomain BuscarPorId(int idModelo);

        void Cadastrar(ModeloDomain novoModelo);


        void AtualizarIdCorpo(ModeloDomain ModeloAtualizado);



        void Deletar(int idModelo);
    }
}
