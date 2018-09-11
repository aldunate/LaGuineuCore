
using LaGuineuData.Models;
using System;

namespace LaGuineuService.Services
{
    public interface ITokenService
    {
        Token CreateToken(Usuario usuario, string operacion);
        Token DecodingToken(string token);
    }
}