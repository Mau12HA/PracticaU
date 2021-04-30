using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ArSpFi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Nombre { get; set; }
        public string Correo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime FechaCreado { get; set; }
        public bool? Activo { get; set; }

        [DisplayName("Perfil")]
        public int FkRol { get; set; }

        public virtual Rol FkRolNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
