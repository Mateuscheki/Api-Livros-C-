using Biblioteca.Application.Commands;
using Biblioteca.Application.Commands.Livro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services.Interfaces
{
    public interface ILivroService
    {
        CommandResult Adicionar(LivroAdicionarCommand command);
        CommandResult Alterar(LivroAlterarCommand command);
        CommandResult Excluir(int id);
        CommandResult Get();
        CommandResult GetById(int id);
    }
}
