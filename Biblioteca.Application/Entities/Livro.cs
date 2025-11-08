using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Entities
{
    public class Livro : Entity
    {
        public string Titulo { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty; 
        public int AnoPublicacao { get; set; }
        public int AutorId { get; set; }

        public Autor Autor { get; set; }
    }
}
