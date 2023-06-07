using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UsuarioRepository : IUsuarioRepository
{
	private readonly DataContext _context;
	private readonly IMapper _mapper;

	public UsuarioRepository(DataContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}



	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<UsuarioShowDto> GetUserByIdAsync(int id)
	{
		var user = await _context.Usuarios
							.Where(u => u.Id == id)
							.ProjectTo<UsuarioShowDto>(_mapper.ConfigurationProvider)
							.FirstOrDefaultAsync();

		return user;
	}



	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<Usuario> GetUserByUsernameAsync(string username)
	{
		var user = await _context.Usuarios
							.FirstOrDefaultAsync(u => u.UserName == username);

		return user;
	}



	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<IEnumerable<UsuarioShowDto>> GetUsersAsync()
	{
		var users = await _context.Usuarios
							.OrderBy(u => u.UserName)
							.ProjectTo<UsuarioShowDto>(_mapper.ConfigurationProvider)
							.ToListAsync();

		return users;
	}



	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public async Task<bool> SaveAllAsync()
	{
		return await _context.SaveChangesAsync() > 0;
	}


	/////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////
	public void Update(Usuario user)
	{
		_context.Entry(user).State = EntityState.Modified;
	}
}
