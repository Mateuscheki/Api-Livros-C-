using Biblioteca.Application.Commands;
using Biblioteca.Application.Commands.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services.Interfaces
{
    public interface IAutorService
    {
        CommandResult Adicionar(AutorAdicionarCommand command);
        CommandResult Alterar(AutorAlterarCommand command);
        CommandResult Excluir(int id);
        CommandResult Get();
        CommandResult GetById(int id);
    }
}
