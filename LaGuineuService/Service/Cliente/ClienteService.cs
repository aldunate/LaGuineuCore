using LaGuineuData;
using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LaGuineuService.Services
{
    public class ClienteService : IClienteService
    {
        
        private laguineuContext db = new laguineuContext();
        private IUsuarioService usuarioService = new UsuarioService();

        public Cliente GetCliente(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            return cliente;
        }

        public List<Cliente> GetClientesEscuela(int idEscuela)
        {
            return db.Cliente.Where(c=> c.IdEscuela == idEscuela).ToList();
        }
        public int PostCliente(ClienteModel cliente)
        {
            if (cliente.Operacion == "Crear")
            {
                if (!usuarioService.ExisteUsuarioEmail(cliente.Usuario.Email))
                {
                    cliente.Usuario.IdEscuela = cliente.Cliente.IdEscuela;
                    // cliente.Usuario.FechaCrea = cliente.Cliente.FechaCrea = DateTime.Now;
                    // cliente.Usuario = db.Usuario.Add(cliente.Usuario);
                    cliente.Cliente.Email = cliente.Usuario.Email;
                    db.SaveChanges();

                    cliente.Cliente.IdUsuario = cliente.Usuario.Id;
                    db.Cliente.Add(cliente.Cliente);
                    db.SaveChanges();
                    return cliente.Cliente.Id;
                }
                return 0;
            }

            if (cliente.Operacion == "Editar")
            {
                if (!usuarioService.ExisteUsuarioEmail(cliente.Usuario.Email))
                {
                    Cliente aux = db.Cliente.Find(cliente.Cliente.Id);
                    aux.Nombre = cliente.Cliente.Nombre;
                    aux.Telefono = cliente.Cliente.Telefono;
                    // aux.Apellidos = cliente.Cliente.Apellidos;
                    // aux.FechaNacimiento = cliente.Cliente.FechaNacimiento;
                    aux.Email = cliente.Usuario.Email;
                    db.SaveChanges();

                    Usuario u = db.Usuario.Find(aux.IdUsuario);
                    u.Email = cliente.Usuario.Email;
                    db.SaveChanges();
                    return cliente.Cliente.Id;
                }
                return 0;
            }
            return 0;
        }
    }
}




















































































































































































































