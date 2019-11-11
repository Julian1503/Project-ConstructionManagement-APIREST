using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Dominio.Repositorio
{
    public interface IRepositorioPrecio : IRepositorio<Precio>
    {
        Task<Precio> GetByLast(long id, Func<IQueryable<Precio>, IOrderedQueryable<Precio>> orderBy = null,
            Func<IQueryable<Precio>, IIncludableQueryable<Precio, object>> include = null,
            bool enableTracking = true);
    }
}
