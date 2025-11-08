using Biblioteca.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Commands.Livro
{
    public class LivroAlterarCommand : Notificavel
    {
        public int Id { get; set; } 
        public string Titulo { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        public int AnoPublicacao { get; set; }
        public int AutorId { get; set; }

        public void Validar()
        {
            if (Id <= 0)
            {
                AddAlerta("O ID do livro é inválido!");
            }
            if (string.IsNullOrEmpty(Titulo))
            {
                AddAlerta("O campo Título do livro é obrigatório!");
            }
            if (AutorId <= 0)
            {
                AddAlerta("O ID do Autor é obrigatório!");
            }
        }
    }
}
