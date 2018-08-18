﻿using LaGuineuData;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LaGuineuService.Services
{
    public class UsuarioService : IUsuarioService
    {
        private laguineuContext db = new laguineuContext();
        private ITokenService tokenService = new TokenService();

        public Usuario GetUsuario(int id)
        {
            return db.Usuario.Where(x => x.Id == id).FirstOrDefault();
        }
        public Usuario GetUsuario(string usuario)
        {
            return db.Usuario.Where(x => x.Email == usuario).FirstOrDefault();
        }

        public List<UsuarioModel> GetUsuariosEscuela(int idEscuela)
        {
            List<Usuario> list =  db.Usuario.Where(x=> x.IdEscuela == idEscuela).ToList();
            List<UsuarioModel> response = new List<UsuarioModel>();
            
            list.ForEach(u =>
            {
                UsuarioModel o = new UsuarioModel();
                o.Id = u.Id;
                o.Email = u.Email;
                //o.EsGestor = u.EsGestor;
                //o.FechaDesactivado = u.FechaDesactivado;
                Monitor m = db.Monitor.Where(x => x.IdUsuario == u.Id).FirstOrDefault();
                if (m != null) {
                    o.Nombre = m.Nombre + " "+ m.Apellidos;
                    o.IdMonitor = m.Id;
                }
                Cliente c = db.Cliente.Where(x => x.IdUsuario == u.Id).FirstOrDefault();
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
                Usuario found = db.Usuario.Where(x => x.Id != usuario.Id && x.Email != usuario.Email).FirstOrDefault();
                if (found == null) return "El email ya esta registrado";
                found = db.Usuario.Where(x => x.Id == usuario.Id).FirstOrDefault();
                if (found == null) return "No se encuentra el usuario";
                found.Email = usuario.Email;
                if (usuario.Password != null)
                {
                    found.Password = usuario.Password;
                }
                //found.EsGestor = usuario.EsGestor;
                db.SaveChanges();
                return "Cambios guardados";
            }
            if (operacion == "Crear")
            {
                Usuario found = db.Usuario.Where(x => x.Email != usuario.Email).FirstOrDefault();
                if (found == null) return "El email ya esta registrado";
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return "Cambios guardados";
            }
            return "null";
        }

        public Boolean ExisteUsuarioEmail(string email)
        {
            var u = db.Usuario.Where(x => x.Email == email).ToArray();
            if (u.Length == 0) return false;
            return true;
        }
        public Boolean ExisteUsuarioEmail(string email, int idUsuario)
        {
            var u = db.Usuario.Where(x => x.Email == email && x.Id != idUsuario ).ToArray();
            if (u.Length == 0) return false;
            return true;
        }

        public Token LoginUsuario(Usuario usuario)
        {
            usuario = db.Usuario.Where(x => x.Email == usuario.Email && x.Password == usuario.Password).FirstOrDefault();
            if (usuario != null)
            {
                var operacion = "Gestion";
                // if (usuario.IdMonitor != null) operacion = "Monitor";
                return tokenService.CreateToken(usuario, operacion);
            }
            return null;
        }
    }
}




















































































































































































































