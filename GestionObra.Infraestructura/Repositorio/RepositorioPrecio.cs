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
   public class RepositorioPrecio : Repositorio<Precio>, IRepositorioPrecio
    {
        public RepositorioPrecio() : base()
        {

        }

        public async Task<Precio> GetByLast(long id, Func<IQueryable<Precio>, IOrderedQueryable<Precio>> orderBy = null,
            Func<IQueryable<Precio>, IIncludableQueryable<Precio, object>> include = null,
            bool enableTracking = true)
        {
            using (var context = new DataContext())
            {
                IQueryable<Precio> query = context.Set<Precio>();

                if (enableTracking)
                {
                    query = query.AsNoTracking();
                }

                if (include != null)
                {
                    query = include(query);
                }

                return await query.FirstOrDefaultAsync(x => x.MaterialId == id && x.FechaActualizacion == context.Precios.Where(y => y.MaterialId == id).Max(y => y.FechaActualizacion));
            }
        }

    }
}
