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
	private readonly IPolizaCoberturaRepository _poCoRepo;

	public PolizasController(IPolizaRepository polizaRepo,
							 IMapper mapper,
							 IPolizaCoberturaRepository poCoRepo)
	{
		_polizaRepo = polizaRepo;
		_mapper = mapper;
		_poCoRepo = poCoRepo;
	}



	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	// POST:  api/Polizas
	[HttpPost]
	public async Task<ActionResult<PolizaWithCobsDto>> CreatePolWithCobs(PoCoCreateDto poCoCreateDto)
	{
		// vehiculo tiene q ser el anho
		// checar coberturasIds validas

		var usuarioId = User.GetUserId();

		var polizaCreateDto = _mapper.Map<PolizaCreateDto>(poCoCreateDto);

		// crea la poliza
		var polizaDto = await _polizaRepo.AddPoliza(polizaCreateDto, usuarioId);

		if (polizaDto == null) return BadRequest("No se pudo añadir la poliza.");

		// inserta en tabla PolizaCobertura ( agrega la lista de coberturas a la poliza )
		var isPoCoAdded = await _poCoRepo.AddPolizaCobertura(poCoCreateDto, polizaDto.PolizaId);

		if (!isPoCoAdded)
		{
			// borrar poliza creada sin cobs
			return BadRequest("No se pudo añadir la poliza.");
		}

		// trae la poliza con lista de coberturas
		var poWithCos = await _polizaRepo.GetPoWithCoByIdAsync(polizaDto.PolizaId);
		
		var polizaWithCobsDto = _mapper.Map<PolizaWithCobsDto>(poWithCos);

		return Ok(polizaWithCobsDto);
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	// PUT:   api/Polizas
	[HttpPut]
	public async Task<ActionResult<PolizaWithCobsDto>> UpdatePoliza(PoCoUpdateDto poCoUpdateDto)
	{
		var usuarioId = User.GetUserId();

		var poliza = await _polizaRepo.GetPolizaByIdAsync(poCoUpdateDto.PolizaId);

		if (poliza == null) return NotFound("No existe la poliza que intentas editar.");

		if (usuarioId != poliza.UsuarioId) return Unauthorized("Solo puedes editar tus polizas.");

		await _polizaRepo.Update(poliza, poCoUpdateDto);

		// borrar todas las coberturas de esta poliza en PolizaCobertura
		// si no hay cambios me va a mandar false
		await _poCoRepo.UpdateCoberturasForPoliza(poCoUpdateDto);
		// tb anhade los nuevos

		var poWithCos = await _polizaRepo.GetPoWithCoByIdAsync(poCoUpdateDto.PolizaId);

		var polizaWithCobsDto = _mapper.Map<PolizaWithCobsDto>(poWithCos);

		return Ok(polizaWithCobsDto);
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

		// borra coberturas
		var isCobsDeleted = await _poCoRepo.DeleteCoberturasForPoliza(id);
		if (!isCobsDeleted) return BadRequest("No se pudo borrar la poliza.");


		// borra poliza
		var wasDeleted = await _polizaRepo.DeletePoliza(poliza);
		if (wasDeleted) return NoContent();


		// si se borro la poliza y no las cobs => revertir
		return BadRequest("Problemas al borrar la poliza.");
	}

	
	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	// GET:  api/Polizas
	//[HttpGet]
	//public async Task<ActionResult<IEnumerable<PolizaDto>>> GetPolizas()
	//{
	//	var polizasDto = await _polizaRepo.GetPolizasAsync();

	//	return Ok(polizasDto);
	//}

	//[HttpGet]
	//public async Task<ActionResult<IEnumerable<PolizaWithCobsDto>>> GetPolizas()
	//{
	//	var polizasDto = await _polizaRepo.GetPolizasAsync();

	//	return Ok(polizasDto);
	//}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	// GET:  api/Polizas
	[HttpGet]
	public async Task<ActionResult<IEnumerable<PolizaWithCobsDto>>> GetPolizas()
	{
		var usuarioId = User.GetUserId();

		var polizasDto = await _polizaRepo.GetPolizasForUserAsync(usuarioId);

		return Ok(polizasDto);
	}
}
