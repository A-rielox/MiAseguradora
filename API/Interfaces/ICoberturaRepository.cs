using API.Entities;

namespace API.Interfaces;

public interface ICoberturaRepository
{
	void AddCobertura(Cobertura cobertura);

	void DeleteCobertura(Cobertura cobertura);

	void Update(Cobertura cobertura);


	Task<Cobertura> GetCoberturaByIdAsync(int id);
	
	Task<IEnumerable<Cobertura>> GetCoberturasAsync();


	Task<bool> SaveAllAsync();
}
