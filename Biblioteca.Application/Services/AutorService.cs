using Biblioteca.Application.Commands;
using Biblioteca.Application.Entities;
using Biblioteca.Application.Repositories;
using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Application.Commands.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _repository;

        // O repositório é injetado, assim como no ModeloService
        public AutorService(IAutorRepository repository)
        {
            _repository = repository;
        }

        public CommandResult Adicionar(AutorAdicionarCommand command)
        {
            // 1. Validar o comando (Fail Fast)
            command.Validar();
            if (command.isInvalida)
            {
                return new CommandResult(false, "Dados do Autor inválidos!", command.Alertas);
            }

            // 2. Mapear o Comando para a Entidade
            var autor = new Autor
            {
                Nome = command.Nome,
                Nacionalidade = command.Nacionalidade
            };

            // 3. Chamar o Repositório
            _repository.Adicionar(autor);

            // 4. Retornar o resultado
            return new CommandResult(true, "Autor adicionado com sucesso!", autor);
        }

        public CommandResult Alterar(AutorAlterarCommand command)
        {
            // 1. Validar o comando
            command.Validar();
            if (command.isInvalida)
            {
                return new CommandResult(false, "Dados do Autor inválidos!", command.Alertas);
            }

            // 2. Verificar se o Autor existe
            var autor = _repository.GetById(command.Id);
            if (autor == null)
            {
                return new CommandResult(false, "Autor não encontrado!", null);
            }

            // 3. Mapear o Comando para a Entidade existente
            autor.Nome = command.Nome;
            autor.Nacionalidade = command.Nacionalidade;

            // 4. Chamar o Repositório
            _repository.Alterar(autor);

            // 5. Retornar o resultado
            return new CommandResult(true, "Autor alterado com sucesso!", autor);
        }

        public CommandResult Excluir(int id)
        {
            // 1. Verificar se o Autor existe
            var autor = _repository.GetById(id);
            if (autor == null)
            {
                return new CommandResult(false, "Autor não encontrado!", null);
            }

            // 2. Chamar o Repositório
            _repository.Excluir(autor);

            // 3. Retornar o resultado
            return new CommandResult(true, "Autor excluído com sucesso!", null);
        }

        public CommandResult Get()
        {
            var autores = _repository.Get();
            return new CommandResult(true, "Autores listados com sucesso!", autores);
        }

        public CommandResult GetById(int id)
        {
            var autor = _repository.GetById(id);
            if (autor == null)
            {
                return new CommandResult(false, "Autor não encontrado!", null);
            }

            return new CommandResult(true, "Autor encontrado!", autor);
        }
    }
}
