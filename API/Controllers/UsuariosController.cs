using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsuariosController : BaseApiController
{
	private readonly IUsuarioRepository _userRepo;
	private readonly IMapper _mapper;

	public UsuariosController(IUsuarioRepository userRepo, IMapper mapper)
	{
		_userRepo = userRepo;
		_mapper = mapper;
	}



	/////////////////////////////////////////////////
	/////////////////////////////////////////////////
	[HttpGet]
	public async Task<ActionResult<IEnumerable<UsuarioShowDto>>> GetUsuarios()
	{
		var usuarios = await _userRepo.GetUsersAsync();

		return Ok(usuarios);
	}

	/////////////////////////////////////////////////
	/////////////////////////////////////////////////
	[HttpGet("{id}")]
	public async Task<ActionResult<Usuario>> GetUsuario(int id)
	{
		var usuario = await _userRepo.GetUserByIdAsync(id);

		return Ok(usuario);
	}

	/////////////////////////////////////////////////
	/////////////////////////////////////////////////
	[HttpPut]
	public async Task<ActionResult> UpdateUsuario(UsuarioUpdateDto usuarioUpdateDto)
	{
		// var idUsuario = User.GetUserId();
		var nombreUsuario = User.GetUsername();

		var usuario = await _userRepo.GetUserByUsernameAsync(nombreUsuario);

		if (usuario == null) return NotFound("El usuario que intenta editar no existe.");

		_mapper.Map(usuarioUpdateDto, usuario);

		if (await _userRepo.SaveAllAsync()) return NoContent();

		return BadRequest("Error al actualizar el usuario.");
	}




}
