using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HormonaDeCrecimiento.App.Dominio;

namespace HormonaDeCrecimiento.App.Persistencia
{
    public interface IRepositorioPacienteMemoria
    {
        IEnumerable<Paciente> GetAllPacientes();
        Paciente AddPaciente(Paciente paciente);
        Paciente UpdatePaciente(Paciente paciente);
        void DeletePaciente(int idpaciente);
        Paciente GetPaciente(int idpaciente);
        //Medico AsignarMedico(int idpaciente, int idmedico);
        //Familiar AsignarFamiliar(int idpaciente, int idfamiliar);
    }
}