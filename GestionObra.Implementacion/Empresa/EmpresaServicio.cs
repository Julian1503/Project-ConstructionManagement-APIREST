using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Empresa;
using GestionObra.Interfaces.Empresa.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Empresa
{
    public class EmpresaServicio : IEmpresaRepositorio
    {
        private IRepositorio<Dominio.Entidades.Empresa> _empresaRepositorio;
        private IMapper _mapper;

        public EmpresaServicio(IRepositorio<Dominio.Entidades.Empresa> empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
            var config = new MapperConfiguration(x=>x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(EmpresaDto dto)
        {
            using (var context = new DataContext())
            {
                var empresa = _mapper.Map<Dominio.Entidades.Empresa>(dto);
                await _empresaRepositorio.Create(empresa);
            }
        }

        public async Task<IEnumerable<EmpresaDto>> Obtener(string cadena)
        {
            using (var context = new DataContext())
            {
                var empresas = await _empresaRepositorio.GetAll(x=>x.OrderByDescending(y=>y.NombreFantasia),x=>x.Include(y=>y.CondicionIva),true);
                return _mapper.Map<IEnumerable<EmpresaDto>>(empresas);
            }
        }

        public async Task<EmpresaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var empresas = await _empresaRepositorio.GetById(id, x => x.Include(y => y.CondicionIva), true);
                if (empresas == null)
                {
                    return null;

                }
                else
                {
                return _mapper.Map<EmpresaDto>(empresas);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var empresa = context.Empresas.FirstOrDefault(x => x.Id == id);
                await _empresaRepositorio.Delete(empresa);
            }
        }

        public async Task Modificar(EmpresaDto dto)
        {
            using (var context = new DataContext())
            {
                var empresa = context.Empresas.FirstOrDefault(x => x.Id == dto.Id);
                empresa = _mapper.Map<Dominio.Entidades.Empresa>(dto);
                await _empresaRepositorio.Update(empresa);
            }
        }
    }
}
