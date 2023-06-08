using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class PolizaCoberturaRepository : IPolizaCoberturaRepository
{
	private readonly DataContext _context;
	private readonly IMapper _mapper;
	private readonly ICoberturaRepository _cobsRepo;

	public PolizaCoberturaRepository(DataContext context,
									 IMapper mapper,
									 ICoberturaRepository cobsRepo)
	{
		_context = context;
		_mapper = mapper;
		_cobsRepo = cobsRepo;
	}




	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	//public void AddPolizaCobertura(PolizaCobertura polizaCobertura)
	//{
	//	_context.PolizaCoberturas.Add(polizaCobertura);
	//}

	public async Task<bool> AddPolizaCobertura(PoCoCreateDto poCoCreateDto, int polizaId)
	{
		var cobsList = poCoCreateDto.CoberturasIdsList.ToList(); // esta de mas, ya es lista<int>

		foreach (var cobId in cobsList)
		{
			var cob = await _cobsRepo.GetCoberturaByIdAsync(cobId);
			var monto = Convert.ToInt32( cob.Monto + (cob.Monto * 
							 int.Parse( poCoCreateDto.Vehiculo ) * 0.001) );

			var poco = new PolizaCobertura
			{
				PolizaId = polizaId,
				CoberturaId = cobId,
				Monto = monto,
			};

			_context.PolizaCoberturas.Add(poco);
		}

		return await SaveAllAsync();		
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<bool> DeleteCoberturasForPoliza(int polizaId)
	{
		var coberturasForPolizaList = await _context.PolizaCoberturas
										.Where(pc => pc.PolizaId == polizaId)
										.ToListAsync();

		// borrar viejas
		foreach (var pc in coberturasForPolizaList)
		{
			_context.PolizaCoberturas.Remove(pc);
		}

		return await SaveAllAsync();
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<bool> UpdateCoberturasForPoliza(PoCoUpdateDto poCoUpdateDto)
	{
		var coberturasForPolizaList = await _context.PolizaCoberturas
										.Where(pc => pc.PolizaId == poCoUpdateDto.PolizaId)
										.ToListAsync();

		// borrar viejas
		foreach (var pc in coberturasForPolizaList)
		{
			_context.PolizaCoberturas.Remove(pc);
		}

		// crear nuevas
		foreach (var cobId in poCoUpdateDto.CoberturasIdsList)
		{
			var cob = await _cobsRepo.GetCoberturaByIdAsync(cobId);
			var monto = Convert.ToInt32(cob.Monto + (cob.Monto *
							 int.Parse(poCoUpdateDto.Vehiculo) * 0.001));

			var poco = new PolizaCobertura
			{
				PolizaId = poCoUpdateDto.PolizaId,
				CoberturaId = cobId,
				Monto = monto,
			};

			_context.PolizaCoberturas.Add(poco);
		}

		return await SaveAllAsync();
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	//public Task<IEnumerable<PolizaCobertura>> UpdateCoberturasForPoliza(int polizaId)
	//{
	//	throw new NotImplementedException();
	//}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<IEnumerable<PolizaCobertura>> GetCoberturasForPoliza(int polizaId)
	{
		var pocos = await _context.PolizaCoberturas
								  .OrderBy(pc => pc.Created)
								  .Where(pc => pc.PolizaId == polizaId)
								  .ToListAsync();

		return pocos;
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<bool> SaveAllAsync()
	{
		return await _context.SaveChangesAsync() > 0;
	}

}
