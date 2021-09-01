using senai_Rental_webAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Rental_webAPI.Interfaces
{
    interface IEmpresaRepository
    {
        List<EmpresaDomain> ListarTodos();


        EmpresaDomain BuscarPorId(int idEmpresa);

        void Cadastrar(EmpresaDomain novoEmpresa);


        void AtualizarIdCorpo(EmpresaDomain EmpresaAtualizado);



        void Deletar(int idEmpresa);
    }
}
