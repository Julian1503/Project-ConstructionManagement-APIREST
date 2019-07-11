using GestionObra.Constantes;

namespace GestionObra.Dominio.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    public class Persona : EntityBase
    {
        private string _nombre;
        private string _apellido;

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = string.Join(' ',
                    value.Split(' ').Select(x => x[0].ToString().ToUpper() +
                                               x.Substring(1).ToLower()).ToArray());
            }
        }

        public string Apellido
        {
            get { return _apellido; }
            set
            {
                _apellido = string.Join(' ',
                    value.Split(' ').Select(x => x[0].ToString().ToUpper() +
                                                 x.Substring(1).ToLower()).ToArray());
            }
        }

        public string Dni { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public TipoSexo Sexo { get; set; }

        //Conexiones
        public virtual ICollection<SalidaMaterial> SalidaMateriales { get; set; }
        public virtual ICollection<Obra> Obras { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
