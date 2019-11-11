using GestionObra.Interfaces.Material.DTOs;
using System.Collections.Generic;

namespace GestionObra.Implementacion.IngresoMaterial
{
    class MaterialComparer : IEqualityComparer<MaterialDto>
    {

        public bool Equals(MaterialDto x, MaterialDto y)
        {
            return x.Descripcion == y.Descripcion &&
        x.Codigo == y.Codigo &&
        x.Detalle == y.Detalle &&
        x.EstaEliminado == y.EstaEliminado &&
        x.Id == y.Id &&
        x.Path == y.Path &&
        x.TipoMaterial == y.TipoMaterial;
        }

        public int GetHashCode(MaterialDto obj)
        {
            return 
            obj.Descripcion.GetHashCode() ^
            obj.Codigo.GetHashCode() ^
            obj.Detalle.GetHashCode() ^
            obj.EstaEliminado.GetHashCode() ^
            obj.Id.GetHashCode() ^
            obj.Path.GetHashCode() ^
            obj.TipoMaterial.GetHashCode();

        }
    }
}
