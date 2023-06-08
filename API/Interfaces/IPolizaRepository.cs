using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IPolizaRepository
{
	Task<PolizaDto> AddPoliza(PolizaCreateDto polizaCreateDto, int usuarioId);

	Task<bool> DeletePoliza(Poliza poliza);

	//Task<PolizaDto> Update(Poliza poliza, PolizaUpdateDto polizaUpdateDto);
	Task<PolizaDto> Update(Poliza poliza, PoCoUpdateDto poCoUpdateDto);


	Task<Poliza> GetPolizaByIdAsync(int id);

	Task<Poliza> GetPoWithCoByIdAsync(int id);


	Task<IEnumerable<PolizaWithCobsDto>> GetPolizasAsync();


	Task<bool> SaveAllAsync();
}
