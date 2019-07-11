using ApiGestionObra.Models.BancoModel;
using AutoMapper;
using GestionObra.Interfaces.Banco.DTOs;

namespace ApiGestionObra.AutoMapperModels
{
    public class PerfilCreacionDto : Profile
    {
        public PerfilCreacionDto()
        {
            CreateMap<BancoCreationDto, BancoDto>().ReverseMap();
        }
    }
}
