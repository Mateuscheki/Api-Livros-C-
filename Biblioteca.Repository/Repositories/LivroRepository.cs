using Biblioteca.Application.Entities;
using Biblioteca.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Repository.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DataContext _context;

        public LivroRepository(DataContext context)
        {
            _context = context;
        }

        public void Adicionar(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }

        public void Alterar(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Livro livro)
        {
            _context.Livros.Remove(livro);
            _context.SaveChanges();
        }

        public IEnumerable<Livro> Get()
        {
            
            return _context.Livros
                           .Include(l => l.Autor)
                           .ToList();
        }

        public Livro? GetById(int id)
        {
         
            return _context.Livros
                           .Include(l => l.Autor)
                           .AsNoTracking()
                           .FirstOrDefault(l => l.Id == id);
        }
    }
}
