using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ArSpFi.Models
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }

       [DisplayName("Codigo")]
        public int  CodReserva { get; set; }
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [DisplayName("Cliente")]
        public string NombCliente { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [DisplayName("Correo")]
        [DataType(DataType.EmailAddress)]
        public string CorreoCliente { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [DisplayName("Telefono")]
        public string TelefonoCliente { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [DisplayName("Fecha Tour")]
        public DateTime FechaReservacion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [DisplayName("Tour")]
        public string TipoTour { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Duracion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [DisplayName("Pasajeros")]
        public int CantPasajeros { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Yate { get; set; }

        
        public string Estado { get; set; }

        [DisplayName("Usuario")]
        public int FkUsuario { get; set; }

        public virtual Usuario FkUsuarioNavigation { get; set; }
    }
}
