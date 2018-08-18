
using LaGuineuData;
using System;
using System.Collections.Generic;

namespace LaGuineuService.Services
{ 
    public interface IClubService
    {
        Object GetClub(int idEscuela);
        List<Club> GetClubesEscuela(int idEscuela);
        int EditarClub(ClubModel club);

    }
}