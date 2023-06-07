using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class PolizaRepository : IPolizaRepository
{
	private readonly DataContext _context;
	private readonly IMapper _mapper;

	public PolizaRepository(DataContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}



	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<PolizaDto> AddPoliza(PolizaCreateDto polizaCreateDto, int usuarioId)
	{
		var polizaCode = usuarioId + "-" + polizaCreateDto.Modelo + "-" + polizaCreateDto.Vehiculo;

		var poliza = _mapper.Map<Poliza>(polizaCreateDto);

		poliza.PolizaCode = polizaCode;
		poliza.UsuarioId = usuarioId;

		_context.Polizas.Add(poliza);

		if (await SaveAllAsync()) return _mapper.Map<PolizaDto>(poliza);

		return null;
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<PolizaDto> Update(Poliza poliza, PolizaUpdateDto polizaUpdateDto)
	{
		_mapper.Map(polizaUpdateDto, poliza);

		var polizaCode = poliza.UsuarioId + "-" + poliza.Modelo + "-" + poliza.Vehiculo;
		poliza.PolizaCode = polizaCode;


		if (await SaveAllAsync()) return _mapper.Map<PolizaDto>(poliza);

		return null;
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<bool> DeletePoliza(Poliza poliza)
	{
		_context.Polizas.Remove(poliza);

		return await SaveAllAsync();
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<Poliza> GetPolizaByIdAsync(int id)
	{
		return await _context.Polizas.FindAsync(id);
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<IEnumerable<PolizaDto>> GetPolizasAsync()
	{
		var polizas = await _context.Polizas.ToListAsync();

		var polizasDto = _mapper.Map<IEnumerable<PolizaDto>>(polizas);

		return polizasDto;
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<bool> SaveAllAsync()
	{
		return await _context.SaveChangesAsync() > 0;
	}
}
