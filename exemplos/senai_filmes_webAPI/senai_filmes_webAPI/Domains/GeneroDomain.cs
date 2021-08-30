using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    /// <summary>
    /// classe que representa a entidade(TABELA) GENERO
    /// </summary>
    public class GeneroDomain
    {
        public int idGenero { get; set; }

        public string nomeGenero { get; set; }
    }
}
