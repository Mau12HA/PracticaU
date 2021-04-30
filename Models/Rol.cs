using System;
using System.Collections.Generic;

#nullable disable

namespace ArSpFi.Models
{
    public partial class Rol
    {
        public Rol()
        {
            RolOperacions = new HashSet<RolOperacion>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string NombRol { get; set; }

        public virtual ICollection<RolOperacion> RolOperacions { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
