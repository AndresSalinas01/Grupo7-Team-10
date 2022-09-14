using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HormonaDeCrecimiento.App.Dominio;


namespace HormonaDeCrecimiento.App.Persistencia
{
    public interface IRepositorioFamiliarMemoria
    {
        IEnumerable<Familiar> GetAllFamiliares();
        Familiar AddFamiliar(Familiar Familiar);
        Familiar UpdateFamiliar(Familiar Familiar);
        void DeleteFamiliar(int idFamiliar);
        Familiar GetFamiliar(int idFamiliar);
    }
}