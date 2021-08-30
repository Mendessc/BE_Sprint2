using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    public class FilmeDomain
    {
        /// <summary>
        /// classe que representa a entidade(TABELA) FILME
        /// </summary>
        public int idFilme { get; set; }
        public int idGenero { get; set; }
        public string tituloFilme { get; set; }
        public GeneroDomain genero { get; set; }
    }
}
