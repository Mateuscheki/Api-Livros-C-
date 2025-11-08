using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Application.Entities;

namespace Biblioteca.Application.Repositories
{
    public interface ILivroRepository
    {
        Livro? GetById(int id);
        IEnumerable<Livro> Get();
        
        void Adicionar(Livro livro);
        void Alterar(Livro livro);
        void Excluir(Livro livro);
    }
}
