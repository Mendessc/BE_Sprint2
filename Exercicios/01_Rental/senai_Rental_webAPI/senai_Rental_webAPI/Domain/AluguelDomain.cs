using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Rental_webAPI.Domain
{
    public class AluguelDomain
    {
        public int idAluguel { get; set; }
        public int idCliente { get; set; }
        public int idVeiculo { get; set; }
        public DateTime dataAluguel { get; set; }

        public DateTime dataDevolucao { get; set; }
    }
}
