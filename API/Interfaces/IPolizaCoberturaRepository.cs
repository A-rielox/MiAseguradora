using API.Entities;

namespace API.Interfaces;

public interface IPolizaCoberturaRepository
{
	void AddPolizaCobertura(PolizaCobertura polizaCobertura);
	
	void DeletePolizaCobertura(PolizaCobertura polizaCobertura);

	Task<IEnumerable<PolizaCobertura>> GetCoberturasForPoliza(int polizaId);

	Task<IEnumerable<PolizaCobertura>> UpdateCoberturasForPoliza(int polizaId);
	
	Task<bool> SaveAllAsync();
}
