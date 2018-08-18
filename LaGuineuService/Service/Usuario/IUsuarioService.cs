using LaGuineuData;
using LaGuineuData.Models;
using System;
using System.Collections.Generic;

namespace LaGuineuService.Services
{
    public interface IUsuarioService
    {
        List<UsuarioModel> GetUsuariosEscuela(int idEscuela);
        Usuario GetUsuario(int id);
        Usuario GetUsuario(string nombre);
        string EditarUsuario(Usuario usuario, string operacion);
        Token LoginUsuario(Usuario usuario);
        Boolean ExisteUsuarioEmail(string email);
        Boolean ExisteUsuarioEmail(string email,int idUsuario);
    }
}