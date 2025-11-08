using Biblioteca.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Commands.Autor
{
    public class AutorAdicionarCommand : Notificavel
    {
        public string Nome { get; set; } = string.Empty;
        public string Nacionalidade { get; set; } = string.Empty;

        // Validação (fail fast validation)
        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                AddAlerta("O campo Nome do autor é obrigatório!");
            }
        }
    }
}
