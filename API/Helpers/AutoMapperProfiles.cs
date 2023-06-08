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
		CreateMap<Poliza, PoCoUpdateDto>().ReverseMap();

		CreateMap<PoCoCreateDto, PolizaCreateDto>().ReverseMap();
		CreateMap<Poliza, PolizaWithCobsDto>()
			.ForMember(dest => dest.CoberturasIdList, opt => opt.MapFrom(src =>
				src.CoberturaList.Select(pc => pc.CoberturaId)	))
			.ReverseMap();
	}
}
