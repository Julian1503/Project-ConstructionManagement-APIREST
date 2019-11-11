using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
  
  public  class FormaPagoCtaCte : FormaPago
    {
        public long CustomerId { get; set; }
                //Conexion 
        public virtual Empresa Customer { get; set; }
    }
}
