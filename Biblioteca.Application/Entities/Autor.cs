using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Entities
{
    public class Autor : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public string Nacionalidade { get; set; } = string.Empty;

        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
