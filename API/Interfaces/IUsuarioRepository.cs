using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IUsuarioRepository
{
	void Update(Usuario user);
	Task<bool> SaveAllAsync();
	Task<IEnumerable<UsuarioShowDto>> GetUsersAsync();
	Task<UsuarioShowDto> GetUserByIdAsync(int id);
	Task<Usuario> GetUserByUsernameAsync(string username);

	//Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
	//Task<MemberDto> GetMemberAsync(string username);
}
