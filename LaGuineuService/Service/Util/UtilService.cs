﻿using LaGuineuData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LaGuineuService.Services
{
    public class UtilService : IUtilService
    {
        
        private laguineuContext db = new laguineuContext();

        /*public List<Nivel> GetNiveles()
        {
            return db.Nivel.ToList();
        }*/

        public List<Titulo> GetTitulos()
        {
            return db.Titulo.ToList();
        }
    }
}




















































































































































































































