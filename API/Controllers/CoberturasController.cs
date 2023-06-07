using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class CoberturasController : BaseApiController
{
	private readonly ICoberturaRepository _coberturaRepo;
	private readonly IMapper _mapper;

	public CoberturasController(ICoberturaRepository coberturaRepo, IMapper mapper)
	{
		_coberturaRepo = coberturaRepo;
		_mapper = mapper;
	}



	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	// POST:  api/Coberturas
	[HttpPost]
	public async Task<ActionResult<Cobertura>> CreateCobertura(CoberturaCreateDto coberturaCreateDto)
	{
		var cobertura = _mapper.Map<Cobertura>(coberturaCreateDto);

		_coberturaRepo.AddCobertura(cobertura);

		if (await _coberturaRepo.SaveAllAsync()) return Ok(cobertura);

		return BadRequest("No se pudo añadir la cobertura.");
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	// PUT:   api/Coberturas
	[HttpPut]
	public async Task<ActionResult> UpdateCobertura(CoberturaUpdateDto coberturaUpdateDto)
	{
		var cobertura = await _coberturaRepo.GetCoberturaByIdAsync(coberturaUpdateDto.CoberturaId);

		if(cobertura == null) return NotFound("Cobertura no encontrada.");

		_mapper.Map(coberturaUpdateDto, cobertura);

		if (await _coberturaRepo.SaveAllAsync()) return NoContent();

		return BadRequest("Error al actualizar la cobertura.");
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	// DELETE:  api/Coberturas/{id}
	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteCobertura(int id)
	{
		var cobertura = await _coberturaRepo.GetCoberturaByIdAsync(id);

		if (cobertura == null) return NotFound("No existe la cobertura que intentas borrar.");

		_coberturaRepo.DeleteCobertura(cobertura);

		if(await _coberturaRepo.SaveAllAsync() ) return NoContent();

		return BadRequest("Error al borrar la cobertura.");
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	// GET:  api/Coberturas
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Cobertura>>> GetCoberturas()
	{
		var coberturas = await _coberturaRepo.GetCoberturasAsync();

		return Ok(coberturas);
	}

}
