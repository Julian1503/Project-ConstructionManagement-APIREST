using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
    public class FormaPagoCheque : FormaPago
    {
        public long BancoId { get; set; }
        public string Numero { get; set; }
        public string EnteEmisor { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public int Dias { get; set; }
        //Conexion
        public virtual Banco Banco { get; set; }
    }
}
