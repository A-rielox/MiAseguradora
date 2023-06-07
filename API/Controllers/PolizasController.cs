using API.DTOs;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class PolizasController : BaseApiController
{
	private readonly IPolizaRepository _polizaRepo;
	private readonly IMapper _mapper;

	public PolizasController(IPolizaRepository polizaRepo, IMapper mapper)
	{
		_polizaRepo = polizaRepo;
		_mapper = mapper;
	}



	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	// POST:  api/Polizas
	[HttpPost]
	public async Task<ActionResult<PolizaDto>> CreatePoliza(PolizaCreateDto polizaCreateDto)
	{
		// viene marca vehiculo y modelo

		var usuarioId = User.GetUserId();

		var polizaDto = await _polizaRepo.AddPoliza(polizaCreateDto, usuarioId);

		if (polizaDto != null) return Ok(polizaDto);

		return BadRequest("No se pudo añadir la poliza.");
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	// PUT:   api/Polizas
	[HttpPut]
	public async Task<ActionResult> UpdatePoliza(PolizaUpdateDto polizaUpdateDto)
	{
		var usuarioId = User.GetUserId();

		var poliza = await _polizaRepo.GetPolizaByIdAsync(polizaUpdateDto.PolizaId);

		if (poliza == null) return NotFound("No existe la poliza que intentas editar.");

		if (usuarioId != poliza.UsuarioId) return Unauthorized("Solo puedes editar tus polizas.");

		var polizaDto = await _polizaRepo.Update(poliza, polizaUpdateDto);

		if (polizaDto != null) return NoContent();

		return BadRequest("No se pudo actualizar la poliza.");
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	// DELETE:  api/Polizas/{id}
	[HttpDelete("{id}")]
	public async Task<ActionResult> DeletePoliza(int id)
	{
		var usuarioId = User.GetUserId();

		var poliza = await _polizaRepo.GetPolizaByIdAsync(id);

		if (poliza == null) return NotFound("No existe la poliza que intentas borrar.");

		if (usuarioId != poliza.UsuarioId) return Unauthorized("Solo puedes borrar tus polizas.");

		var wasDeleted = await _polizaRepo.DeletePoliza(poliza);

		if(wasDeleted) return NoContent();

		return BadRequest("No se pudo borrar la poliza.");
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	// GET:  api/Polizas
	[HttpGet]
	public async Task<ActionResult<IEnumerable<PolizaDto>>> GetPolizas()
	{
		var polizasDto = await _polizaRepo.GetPolizasAsync();

		return Ok(polizasDto);
	}
}
