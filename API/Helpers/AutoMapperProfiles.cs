using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
	public AutoMapperProfiles()
	{
		CreateMap<Usuario, UsuarioShowDto>();
		CreateMap<Poliza, PolizaDto>();
		CreateMap<UsuarioUpdateDto, Usuario>().ReverseMap();
	}
}
