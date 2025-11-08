using Biblioteca.Application.Commands;
using Biblioteca.Application.Commands.Livro;
using Biblioteca.Application.Entities;
using Biblioteca.Application.Repositories;
using Biblioteca.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IAutorRepository _autorRepository; 

        public LivroService(ILivroRepository livroRepository, IAutorRepository autorRepository)
        {
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
        }

        public CommandResult Adicionar(LivroAdicionarCommand command)
        {
            command.Validar();
            if (command.isInvalida)
            {
                return new CommandResult(false, "Dados do Livro inválidos!", command.Alertas);
            }

            if (_autorRepository.GetById(command.AutorId) == null)
            {
                return new CommandResult(false, "Autor não encontrado!", null);
            }

            var livro = new Livro
            {
                Titulo = command.Titulo,
                Isbn = command.Isbn,
                AnoPublicacao = command.AnoPublicacao,
                AutorId = command.AutorId
            };

            _livroRepository.Adicionar(livro);

            return new CommandResult(true, "Livro adicionado com sucesso!", livro);
        }

        public CommandResult Alterar(LivroAlterarCommand command)
        {
            command.Validar();
            if (command.isInvalida)
            {
                return new CommandResult(false, "Dados do Livro inválidos!", command.Alertas);
            }

            var livro = _livroRepository.GetById(command.Id);
            if (livro == null)
            {
                return new CommandResult(false, "Livro não encontrado!", null);
            }

            if (_autorRepository.GetById(command.AutorId) == null)
            {
                return new CommandResult(false, "Autor não encontrado!", null);
            }
            livro.Titulo = command.Titulo;
            livro.Isbn = command.Isbn;
            livro.AnoPublicacao = command.AnoPublicacao;
            livro.AutorId = command.AutorId;

            _livroRepository.Alterar(livro);

            return new CommandResult(true, "Livro alterado com sucesso!", livro);
        }

        public CommandResult Excluir(int id)
        {
            var livro = _livroRepository.GetById(id);
            if (livro == null)
            {
                return new CommandResult(false, "Livro não encontrado!", null);
            }
            _livroRepository.Excluir(livro);
            return new CommandResult(true, "Livro excluído com sucesso!", null);
        }

        public CommandResult Get()
        {
            var livros = _livroRepository.Get();
            return new CommandResult(true, "Livros listados com sucesso!", livros);
        }

        public CommandResult GetById(int id)
        {
            var livro = _livroRepository.GetById(id);
            if (livro == null)
            {
                return new CommandResult(false, "Livro não encontrado!", null);
            }
            return new CommandResult(true, "Livro encontrado!", livro);
        }
    }
}
