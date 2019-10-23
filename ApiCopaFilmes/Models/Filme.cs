using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCopaFilmes.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public decimal Nota { get; set; }
    }


}
