


using LaGuineuData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LaGuineuService.Services
{
    public class ClaseService : IClaseService
    {
        private laguineuContext db = new laguineuContext();

        public Clase GetClase(int id)
        {
            return db.Clase.Find(id);
        }



        public List<Clase> GetClaseEscuela(int idEscuela)
        {
            return db.Clase.Where(x => x.IdEscuela == idEscuela).ToList();
        }

        public List<ClaseModel> GetClaseEscuelaFecha(int idEscuela, string fecha)
        {
            var aux = fecha.Split('/');
            var fec = new DateTime(int.Parse(aux[2]), int.Parse(aux[1]), int.Parse(aux[0]));
            var clasesList = db.Clase.Where(x => x.IdEscuela == idEscuela && x.FechaInicio.Value.Day == fec.Day && x.FechaInicio.Value.Year == fec.Year && x.FechaInicio.Value.Month == fec.Month).ToList();
            var clases = new List<ClaseModel>{ };
            clasesList.ForEach(clase =>
            {
                var c = new ClaseModel { };
                c.Clase = clase;
                c.Monitores = new List<ClaseMonitor>();
                c.Alumnos = new List<Alumno>();
                var claseMonitor = db.ClaseMonitor.Where(x => x.IdClase == clase.Id).ToList();
                claseMonitor.ForEach(cm =>
               {
                   c.Monitores.Add(cm);
               });
                clases.Add(c);
            });
            return clases;
        }

        public int PostAsignada(ClaseModel asignada)
        {
            Clase c = db.Clase.Find(asignada.Clase.Id);
            c.FechaInicio = asignada.Clase.FechaInicio;
            c.FechaFin = asignada.Clase.FechaFin;
            c.IdEstacion = asignada.Clase.IdEstacion;
            db.SaveChanges();
            var claseMontior = db.ClaseMonitor.Where(x => 
                x.IdClase == asignada.Clase.Id
            ).ToList();
            db.ClaseMonitor.RemoveRange(claseMontior);
            db.ClaseMonitor.AddRange(asignada.Monitores);
            db.SaveChanges();
            return asignada.Clase.Id;
        }

        public Clase PostClase(ClaseModel clase)
        {
            if(clase.Operacion == "Crear")
            {
                // clase.Clase = db.Clase.Add(clase.Clase);
                db.SaveChanges();
                clase.Monitores.ForEach(m =>
                {
                    db.ClaseMonitor.Add(new ClaseMonitor
                    {
                        IdClase = clase.Clase.Id,
                        IdMonitor = m.IdMonitor
                    });
                });
                db.SaveChanges();
                return clase.Clase;
            }
            if(clase.Operacion == "Editar")
            {
                var id = 0;
                Clase c = db.Clase.Where(x => x.Id == clase.Clase.Id).FirstOrDefault();
                id = c.Id;
                c = clase.Clase;
                c.Id = id;
                db.SaveChanges();
                var claseMontior = db.ClaseMonitor.Where(x =>
                x.IdClase == clase.Clase.Id
                ).ToList();
                db.ClaseMonitor.RemoveRange(claseMontior);
                db.SaveChanges();
                clase.Monitores.ForEach(m =>
                {
                    db.ClaseMonitor.Add(new ClaseMonitor
                    {
                        IdClase = clase.Clase.Id,
                        IdMonitor = m.IdMonitor
                    });
                });
                db.SaveChanges();
                return clase.Clase;
            }
            return null;
        }

        public bool DeleteClase(int idClase)
        {
            Clase c = db.Clase.Where(x => x.Id == idClase).FirstOrDefault();
            var l = db.ClaseMonitor.Where(x => x.IdClase == idClase);
            db.ClaseMonitor.RemoveRange(l);
            db.Clase.Remove(c);
            db.SaveChanges();
            return true;
        }


    }
}


