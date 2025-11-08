using Biblioteca.Application.Entities;
using Biblioteca.Repository.Contexts;
using Biblioteca.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Repository.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly DataContext _context;

     
        public AutorRepository(DataContext context)
        {
            _context = context;
        }

        public void Adicionar(Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
        }

        public void Alterar(Autor autor)
        {
            _context.Entry(autor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Autor autor)
        {
            _context.Autores.Remove(autor);
            _context.SaveChanges();
        }

        public IEnumerable<Autor> Get()
        {
            
            return _context.Autores.AsNoTracking().ToList();
        }

        public Autor? GetById(int id)
        {
            
            return _context.Autores.AsNoTracking()
                           .FirstOrDefault(a => a.Id == id);
        }
    }
}
