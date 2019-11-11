using GestionObra.Dominio.Entidades;
using GestionObra.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Infraestructura.Repositorio
{
    public class RepositorioStock: Repositorio<Stock>, IRepositorioStock
    {
        public RepositorioStock() : base()
        {

        }

        public async Task<Stock> GetByLast(long id,Func<IQueryable<Stock>, IOrderedQueryable<Stock>> orderBy = null,
            Func<IQueryable<Stock>, IIncludableQueryable<Stock, object>> include = null,
            bool enableTracking = true)
        {
            using (var context = new DataContext())
            {
                IQueryable<Stock> query = context.Set<Stock>();

                if (enableTracking)
                {
                    query = query.AsNoTracking();
                }

                if (include != null)
                {
                    query = include(query);
                }

                return await query.FirstOrDefaultAsync(x=> x.MaterialId == id && x.FechaActualizacion == context.Stocks.Where(y=>y.MaterialId == id).Max(y=>y.FechaActualizacion));
            }
        }

    }
}
