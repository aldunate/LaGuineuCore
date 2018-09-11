using LaGuineuData;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LaGuineuService.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly laguineuContext _db = new laguineuContext();
        private readonly ITokenService _tokenService = new TokenService();

        public Usuario GetUsuario(int id)
        {
            return _db.Usuario.FirstOrDefault(x => x.Id == id);
        }
        public Usuario GetUsuario(string usuario)
        {
            return _db.Usuario.FirstOrDefault(x => x.Email == usuario);
        }

        public List<UsuarioModel> GetUsuariosEscuela(int idEscuela)
        {
            List<Usuario> list =  _db.Usuario.Where(x=> x.IdEscuela == idEscuela).ToList();
            List<UsuarioModel> response = new List<UsuarioModel>();
            
            list.ForEach(u =>
            {
                UsuarioModel o = new UsuarioModel {Id = u.Id, Email = u.Email};
                //o.EsGestor = u.EsGestor;
                //o.FechaDesactivado = u.FechaDesactivado;
                Monitor m = _db.Monitor.FirstOrDefault(x => x.IdUsuario == u.Id);
                if (m != null) {
                    o.Nombre = m.Nombre + " "+ m.Apellidos;
                    o.IdMonitor = m.Id;
                }
                Cliente c = _db.Cliente.FirstOrDefault(x => x.IdUsuario == u.Id);
                if (c != null)
                {
                    //o.Nombre = c.Nombre + " " + c.Apellidos;
                    o.IdCliente = c.Id;
                }
                response.Add(o);
            });
            return response;
        }

        public string EditarUsuario(Usuario usuario, string operacion)
        {
            if(operacion == "Editar")
            {
                Usuario found = _db.Usuario.FirstOrDefault(x => x.Id != usuario.Id && x.Email != usuario.Email);
                if (found == null) return "El email ya esta registrado";
                found = _db.Usuario.FirstOrDefault(x => x.Id == usuario.Id);
                if (found == null) return "No se encuentra el usuario";
                found.Email = usuario.Email;
                if (usuario.Password != null)
                {
                    found.Password = usuario.Password;
                }
                //found.EsGestor = usuario.EsGestor;
                _db.SaveChanges();
                return "Cambios guardados";
            }
            if (operacion == "Crear")
            {
                Usuario found = _db.Usuario.FirstOrDefault(x => x.Email != usuario.Email);
                if (found == null) return "El email ya esta registrado";
                _db.Usuario.Add(usuario);
                _db.SaveChanges();
                return "Cambios guardados";
            }
            return "null";
        }

        public Boolean ExisteUsuarioEmail(string email)
        {
            var u = _db.Usuario.Where(x => x.Email == email).ToArray();
            if (u.Length == 0) return false;
            return true;
        }
        public Boolean ExisteUsuarioEmail(string email, int idUsuario)
        {
            var u = _db.Usuario.Where(x => x.Email == email && x.Id != idUsuario ).ToArray();
            if (u.Length == 0) return false;
            return true;
        }

        public Token LoginUsuario(Usuario usuario)
        {
            usuario = _db.Usuario.FirstOrDefault(x => x.Email == usuario.Email && x.Password == usuario.Password);
            if (usuario != null)
            {
                var operacion = "Gestion";
                // if (usuario.IdMonitor != null) operacion = "Monitor";
                return _tokenService.CreateToken(usuario, operacion);
            }
            return null;
        }
    }
}




















































































































































































































