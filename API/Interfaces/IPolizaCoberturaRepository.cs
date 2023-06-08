using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IPolizaCoberturaRepository
{
	Task<bool> AddPolizaCobertura(PoCoCreateDto poCoCreateDto, int polizaId);
	
	void DeletePolizaCobertura(PolizaCobertura polizaCobertura);

	Task<IEnumerable<PolizaCobertura>> GetCoberturasForPoliza(int polizaId);

	Task<IEnumerable<PolizaCobertura>> UpdateCoberturasForPoliza(int polizaId);
	
	Task<bool> SaveAllAsync();
}
