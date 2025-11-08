using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Application.Entities;


namespace Biblioteca.Application.Repositories
{
    public interface IAutorRepository
    {
        Autor? GetById(int id);
        IEnumerable<Autor> Get();

        void Adicionar(Autor autor);
        void Alterar(Autor autor);
        void Excluir(Autor autor);
    }
}
