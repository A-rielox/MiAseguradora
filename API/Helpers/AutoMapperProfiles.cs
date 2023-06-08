using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
	public AutoMapperProfiles()
	{
		CreateMap<Usuario, UsuarioShowDto>();
		CreateMap<UsuarioUpdateDto, Usuario>().ReverseMap();
		
		
		CreateMap<CoberturaCreateDto, Cobertura>().ReverseMap();
		CreateMap<CoberturaUpdateDto, Cobertura>().ReverseMap();


		CreateMap<Poliza, PolizaCreateDto>().ReverseMap();
		CreateMap<Poliza, PolizaDto>().ReverseMap();
		CreateMap<Poliza, PolizaUpdateDto>().ReverseMap();

		CreateMap<PoCoCreateDto, PolizaCreateDto>().ReverseMap();
		CreateMap<Poliza, PolizaWithCobsDto>().ReverseMap();
	}
}
