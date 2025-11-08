using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Entities
{
    public class Entity : IEquatable<Entity>
    {
        public int Id { get; set; }
        public bool Equals(Entity? other)
        {
            return Id == other?.Id;
        }
    }
}
