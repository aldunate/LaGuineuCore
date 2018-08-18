using LaGuineuData;
using LaGuineuData.Models;
using System.Collections.Generic;
using System.Linq;

namespace LaGuineuService.Services
{
    public class DeporteService : IDeporteService
    {
        
        private laguineuContext db = new laguineuContext();


        public List<Deporte> GetDeportes()
        {
            return db.Deporte.ToList();
        }

        public List<Deporte> GetDeportes(int idEscuela)
        {
            List<EscuelaDeporte> ED =  db.EscuelaDeporte.Where(x => x.IdEscuela == idEscuela).ToList();
            List<Deporte> D = db.Deporte.ToList();
            var list = (from d in D
                    join ed in ED on d.Id equals ed.IdDeporte
                    select new {
                         Id = (int)ed.IdDeporte,
                         d.Nombre
                    }).ToList();

            List<Deporte> listDep = new List<Deporte>();
            
            foreach(var x in list)
            {
                Deporte dep = new Deporte();
                dep.Id = x.Id;
                dep.Nombre = x.Nombre;
                listDep.Add(dep);
            }
            return listDep;
        }

    }
}




















































































































































































































