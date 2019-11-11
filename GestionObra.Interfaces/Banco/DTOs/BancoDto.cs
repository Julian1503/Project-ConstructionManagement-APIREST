using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.Banco.DTOs
{
    public class BancoDto : DtoBase
    {
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public string Descripcion { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string CBU { get; set; }
        public string Path { get; set; }
        public string Mail { get; set; }
        public string Sucursal { get; set; }
    }
}
