using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class PolizaCoberturaRepository : IPolizaCoberturaRepository
{
	private readonly DataContext _context;
	private readonly IMapper _mapper;

	public PolizaCoberturaRepository(DataContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}




	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public void AddPolizaCobertura(PolizaCobertura polizaCobertura)
	{
		_context.PolizaCoberturas.Add(polizaCobertura);
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public void DeletePolizaCobertura(PolizaCobertura polizaCobertura)
	{
		_context.PolizaCoberturas.Remove(polizaCobertura);
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public Task<IEnumerable<PolizaCobertura>> UpdateCoberturasForPoliza(int polizaId)
	{
		throw new NotImplementedException();
	}


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
