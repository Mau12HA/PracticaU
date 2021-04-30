using System;
using System.Collections.Generic;

#nullable disable

namespace ArSpFi.Models
{
    public partial class RolOperacion
    {
        public int Id { get; set; }
        public int FkRol { get; set; }
        public int FkOperacion { get; set; }

        public virtual Operacione FkOperacionNavigation { get; set; }
        public virtual Rol FkRolNavigation { get; set; }
    }
}
