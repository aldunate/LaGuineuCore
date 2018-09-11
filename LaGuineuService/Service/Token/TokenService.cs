using LaGuineuData.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace LaGuineuService.Services
{
    public class TokenService : ITokenService
    {
        private laguineuContext db = new laguineuContext();
        private string _secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
        private IConfiguration _config;

        public TokenService()
        {
        }

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public Token CreateToken(Usuario usuario, string operacion)
        {
            var token = new Token
            {
                Nombre = "",
                IdUsuario = usuario.Id,
                IdEscuela = usuario.IdEscuela,
                FechaCrea = DateTime.Now,
            };
            return token;
        }

        // Verifica
        public Token DecodingToken(string token)
        {
            return null;
        }

    }
}


