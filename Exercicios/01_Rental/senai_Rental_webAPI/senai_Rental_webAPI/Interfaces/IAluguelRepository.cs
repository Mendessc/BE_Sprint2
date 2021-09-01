using senai_Rental_webAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Rental_webAPI.Interfaces
{
    interface IAluguelRepository
    {
        List<AluguelDomain> ListarTodos();

       
        AluguelDomain BuscarPorId(int idAluguel);
        
        void Cadastrar(AluguelDomain novoAluguel);

        
        void AtualizarIdCorpo(AluguelDomain aluguelAtualizado);


        
        void Deletar(int idAluguel);
    }
}
    

