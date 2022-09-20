using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HormonaDeCrecimiento.App.Dominio;

namespace HormonaDeCrecimiento.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        IEnumerable<Paciente> GetAllPacientes();
        Paciente AddPaciente(Paciente paciente);
        Paciente UpdatePaciente(Paciente paciente);
        void DeletePaciente(int idpaciente);
        Paciente GetPaciente(int idpaciente);
        Medico AsignarMedico(int idpaciente, int idmedico);
        Medico ConsultarEndocrino(int idpaciente);
        Medico ConsultarPediatra(int idpaciente);
        Familiar ConsultarFamiliar(int idpaciente);
        IEnumerable<Patron> GetPatronesPacientes(int idpaciente);
        Familiar AsignarFamiliar(int idpaciente, int idfamiliar);

    }
}