using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HormonaDeCrecimiento.App.Dominio;

namespace HormonaDeCrecimiento.App.Persistencia
{
    public interface IRepositorioFamiliar
    {
        IEnumerable<Familiar> GetAllFamiliares();
        Familiar AddFamiliar(Familiar familiar);
        Familiar UpdateFamiliar(Familiar familiar);
        void DeleteFamiliar(int idfamiliar);
        Familiar GetFamiliar(int idfamiliar);
    }
}