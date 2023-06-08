using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IPolizaCoberturaRepository
{
	Task<bool> AddPolizaCobertura(PoCoCreateDto poCoCreateDto, int polizaId);

	Task<bool> UpdateCoberturasForPoliza(PoCoUpdateDto poCoUpdateDto);

	Task<IEnumerable<PolizaCobertura>> GetCoberturasForPoliza(int polizaId);

	//Task<IEnumerable<PolizaCobertura>> UpdateCoberturasForPoliza(int polizaId);
	Task<bool> DeleteCoberturasForPoliza(int polizaId);

	Task<bool> SaveAllAsync();
}
