using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HormonaDeCrecimiento.App.Dominio;


namespace HormonaDeCrecimiento.App.Persistencia
{
    public class RepositorioPacienteMemoria: IRepositorioPacienteMemoria
    {
        List<Paciente> pacientes;
        public RepositorioPacienteMemoria(){
            pacientes = new List<Paciente>(){
                new Paciente{
                    Id = 1,
                    Nombre = "Julian",
                    Apellido = "Perez",
                    Telefono = "32222",
                    Documento = "12222",
                    Genero = Genero.Masculino,
                    Direccion = "Call3 1",
                    Latitud = 0.12333F,
                    Longitud = -2.12333F,
                    Ciudad = "Pereira",
                    FechadeNacimiento = new DateTime(2002,05,11)
                },
                new Paciente{
                    Id = 2,
                    Nombre = "Mauricio",
                    Apellido = "Perez",
                    Telefono = "32222",
                    Documento = "123333",
                    Genero = Genero.Masculino,
                    Direccion = "Call3 1",
                    Latitud = 0.12333F,
                    Longitud = -2.12333F,
                    Ciudad = "Pereira",
                    FechadeNacimiento = new DateTime(2002,05,11)
                }
            };
        }
        public IEnumerable<Paciente> GetAllPacientes(){
            return pacientes;
        }
        public Paciente AddPaciente(Paciente paciente){
            paciente.Id = pacientes.Max(p=>p.Id)+1;
            pacientes.Add(paciente);
            return paciente;
        }
        public Paciente UpdatePaciente(Paciente paciente){
            var pacienteEncontrado = pacientes.SingleOrDefault(p=>p.Id==paciente.Id);
            var index = paciente.Id -1;
            if(pacienteEncontrado!=null){
                pacientes[index].Nombre = paciente.Nombre;
                pacientes[index].Apellido = paciente.Apellido;
                pacientes[index].Telefono = paciente.Telefono;
                pacientes[index].Documento = paciente.Documento;
                pacientes[index].Genero = paciente.Genero;
                pacientes[index].Direccion = paciente.Direccion;
                pacientes[index].Latitud = paciente.Latitud;
                pacientes[index].Longitud = paciente.Longitud;
                pacientes[index].Ciudad = paciente.Ciudad;
                pacientes[index].FechadeNacimiento = paciente.FechadeNacimiento;
                // pacientes[index].Patrones = paciente.Patrones;
                // pacientes[index].Familiar = paciente.Familiar;
                // pacientes[index].Historia = paciente.Historia;
                // pacientes[index].Endocrino = paciente.Endocrino;
                // pacientes[index].Pediatra = paciente.Pediatra;

            }

            return pacienteEncontrado;
        }
        public void DeletePaciente(int idpaciente){
            var pacienteEncontrado = pacientes.SingleOrDefault( m=> m.Id == idpaciente);

            if(pacienteEncontrado==null){
                return;
            }

            pacientes.Remove(pacienteEncontrado);
        }

        public Paciente GetPaciente(int idpaciente){
            return pacientes.SingleOrDefault(p => p.Id == idpaciente);
        }
        // public paciente Asignarpaciente(int idpaciente, int idpaciente){

        // }

        // public Familiar AsignarFamiliar(int idpaciente, int idfamiliar){

        // }
    }
}