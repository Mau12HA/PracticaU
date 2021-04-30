using System;
using System.Collections.Generic;

#nullable disable

namespace ArSpFi.Models
{
    public partial class Operacione
    {
        public Operacione()
        {
            RolOperacions = new HashSet<RolOperacion>();
        }

        public int IdOperacion { get; set; }
        public string NombOperacion { get; set; }
        public int FkModulo { get; set; }

        public virtual Modulo FkModuloNavigation { get; set; }
        public virtual ICollection<RolOperacion> RolOperacions { get; set; }
    }
}
