using GestionObra.Helpers;

namespace GestionObra.Dominio.Entidades
{
    using System.Collections.Generic;
    public class Banco : EntityBase
    {
        private string _descripcion;
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string CBU { get; set; }
        public string Sucursal { get; set; }
        public string Descripcion
        {
            get
            {
               return _descripcion;
            }
            set
            {
                _descripcion = Capitalize.CapitalizeFirstLetter(value);
            }
        }

        //Conexiones
        public virtual ICollection<FormaPagoCheque> FormaPagoCheques{ get; set; }
        public virtual ICollection<ChequeEntrada> ChequesEntrada { get; set; }
        public virtual ICollection<ChequeSalida> ChequesSalida { get; set; }
        public virtual ICollection<Transferencia> Transferencias { get; set; }
        public virtual ICollection<Deposito> Depositos { get; set; }
        public virtual ICollection<CuentaCorriente> CuentaCorrientes { get; set; }
        public string Path { get; set; }
    }
}
