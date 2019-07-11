using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
    public class SalidaMaterial:EntityBase
    {
        [DataType(DataType.DateTime)]
        public DateTime FechaEgreso { get; set; }
        public long MaterialId { get; set; }
        public long DeObraId { get; set; }
        public long ResponsableId { get; set; }
        public int Cantidad { get; set; }
        public long ParaObraId { get; set; }

        //Conexiones
        public virtual Obra ParaObra { get; set; }
        public virtual Obra DeObra { get; set; }
        public virtual Persona Responsable { get; set; }
        public virtual Material Material { get; set; }
    }
}
