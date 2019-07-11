using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Persona.DTOs;

namespace GestionObra.Interfaces.Persona
{
    public interface IPersonaRepositorio
    {
        Task Insertar(PersonaDto dto);
        Task<IEnumerable<PersonaDto>> Obtener(string cadena);
        Task<PersonaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(PersonaDto dto);
    }
}
