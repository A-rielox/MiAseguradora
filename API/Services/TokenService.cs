﻿using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services;

public class TokenService : ITokenService
{
	private readonly SymmetricSecurityKey _key;

	public TokenService(IConfiguration config)
	{
		_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
	}

	////////////////////////////////////////////////
	///////////////////////////////////////////////////
	//
	public string CreateToken(Usuario usuario)
	{
		var claims = new List<Claim>
		{
			new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserName),
	        new Claim(JwtRegisteredClaimNames.NameId, usuario.Id.ToString())
	    };

		var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.Now.AddDays(7),
			SigningCredentials = creds
		};

		var tokenHandler = new JwtSecurityTokenHandler();

		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}
}
