using System;
using System.Collections.Generic;

#nullable disable

namespace ArSpFi.Models
{
    public partial class Modulo
    {
        public Modulo()
        {
            Operaciones = new HashSet<Operacione>();
        }

        public int IdModulo { get; set; }
        public string NombModulo { get; set; }

        public virtual ICollection<Operacione> Operaciones { get; set; }
    }
}
