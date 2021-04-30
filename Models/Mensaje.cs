using System;
using System.Collections.Generic;

#nullable disable

namespace ArSpFi.Models
{
    public partial class Mensaje
    {
        public int Idmensaje { get; set; }
        public string NombreMensaje { get; set; }
        public string EmailMensaje { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaMensaje { get; set; }
        public bool EstadoMensaje { get; set; }
    }
}
