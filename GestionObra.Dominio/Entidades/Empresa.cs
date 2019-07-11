namespace GestionObra.Dominio.Entidades
{
    using System.Collections.Generic;
    public class Empresa : EntityBase
    {
        public long? CondicionIvaId { get; set; }
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Sucursal { get; set; }
        public string Path { get; set; }

        //Conexiones
        public virtual ICollection<Obra> Obras { get; set; }
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
        public virtual ICollection<CuentaCorriente> CuentaCorrientes { get; set; }
        public virtual ICollection<IngresoMaterial> IngresoMateriales { get; set; }
        public virtual CondicionIva CondicionIva { get; set; }
    }
}
