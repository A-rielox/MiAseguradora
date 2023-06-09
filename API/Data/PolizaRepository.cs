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
	//public async Task<PolizaDto> Update(Poliza poliza, PolizaUpdateDto polizaUpdateDto)
	//{
	//	_mapper.Map(polizaUpdateDto, poliza);

	//	var polizaCode = poliza.UsuarioId + "-" + poliza.Modelo + "-" + poliza.Vehiculo;
	//	poliza.PolizaCode = polizaCode;


	//	if (await SaveAllAsync()) return _mapper.Map<PolizaDto>(poliza);

	//	return null;
	//}
	
	public async Task<PolizaDto> Update(Poliza poliza, PoCoUpdateDto poCoUpdateDto)
	{
		_mapper.Map(poCoUpdateDto, poliza);

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
	public async Task<Poliza> GetPoWithCoByIdAsync(int id)
	{
		return await _context.Polizas
							 .Include(p => p.CoberturaList)
							 .FirstOrDefaultAsync(p => p.PolizaId == id);
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<IEnumerable<PolizaWithCobsDto>> GetPolizasAsync()
	{
		var polizas = await _context.Polizas
									.Include(p => p.CoberturaList)
									.ToListAsync();

		var polizasDto = _mapper.Map<IEnumerable<PolizaWithCobsDto>>(polizas);

		return polizasDto;
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<IEnumerable<PolizaWithCobsDto>> GetPolizasForUserAsync(int userId)
	{
		var polizas = await _context.Polizas
									.Where(p => p.UsuarioId == userId)
									.Include(p => p.CoberturaList)
									.ToListAsync();

		var polizasDto = _mapper.Map<IEnumerable<PolizaWithCobsDto>>(polizas);

		return polizasDto;
	}



	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<bool> SaveAllAsync()
	{
		return await _context.SaveChangesAsync() > 0;
	}
}
