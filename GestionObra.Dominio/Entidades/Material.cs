namespace GestionObra.Dominio.Entidades
{
    using System.Collections.Generic;
    using Constantes;
    public class Material : EntityBase
    {
        public string Codigo { get; set; }
        public TipoMaterial TipoMaterial { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public string Path { get; set; }
        
        //Conexiones
        public virtual ICollection<SalidaMaterial> SalidaMateriales { get; set; }
        public virtual ICollection<IngresoMaterial> IngresoMateriales { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Precio> Precios { get; set; }
    }
}
