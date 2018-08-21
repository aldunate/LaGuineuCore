using LaGuineuData;
using LaGuineuData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LaGuineuService.Services
{
    public class ClubService : IClubService
    {
        
        private laguineuContext db = new laguineuContext();

        public Object GetClub(int id)
        {
            Club club = db.Club.Find(id);
            List<Alumno> clientes = db.Alumno.Where(x => x.IdGrupo == id).ToList();
            return new {
                Club = club,
                Clientes = clientes 
            };
        }

        public List<Club> GetClubesEscuela(int idEscuela)
        {
            return null;
            // return db.Club.Where(x => x.IdClub == idEscuela).ToList();
        }
        public int EditarClub(ClubModel club)
        {
            if (club.Operacion == "Crear")
            {
                // club.Club = db.Club.Add(club.Club);
                db.SaveChanges();
                club.Clientes.ForEach(ee =>
                {
                    // db.ClubCliente.Add(new ClubCliente { IdCliente = ee.Id, IdClub = club.Club.Id});
                });
                db.SaveChanges();
            }
            if (club.Operacion == "Editar")
            {
                // db.ClubCliente.RemoveRange(db.ClubCliente.Where(x => x.IdClub == club.Club.Id));
                db.SaveChanges();
                club.Clientes.ForEach(ee =>
                {
                    // db.ClubCliente.Add(new ClubCliente { IdCliente = ee.Id, IdClub = club.Club.Id });
                });
                db.SaveChanges();
                Club auxC = db.Club.Find(club.Club.IdClub);
                auxC.Nombre = club.Club.Nombre;
                // auxC.IdNivel = club.Club.IdNivel;
                db.SaveChanges();
            }
            return 0;// club.Club.Id;
        }

        

    }
}




















































































































































































































