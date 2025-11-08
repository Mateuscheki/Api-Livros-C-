using Biblioteca.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Commands.Autor
{
    public class AutorAlterarCommand : Notificavel
    {
        public int Id { get; set; } 
        public string Nome { get; set; } = string.Empty;
        public string Nacionalidade { get; set; } = string.Empty;

        public void Validar()
        {
            if (Id <= 0)
            {
                AddAlerta("O ID do autor é inválido!");
            }
            if (string.IsNullOrEmpty(Nome))
            {
                AddAlerta("O campo Nome do autor é obrigatório!");
            }
        }
    }
}
