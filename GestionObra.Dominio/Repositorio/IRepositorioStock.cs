using GestionObra.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Dominio.Repositorio
{
    public interface IRepositorioStock : IRepositorio<Stock>
    {
        Task<Stock> GetByLast(long id, Func<IQueryable<Stock>, IOrderedQueryable<Stock>> orderBy = null,
            Func<IQueryable<Stock>, IIncludableQueryable<Stock, object>> include = null,
            bool enableTracking = true);
    }
}
