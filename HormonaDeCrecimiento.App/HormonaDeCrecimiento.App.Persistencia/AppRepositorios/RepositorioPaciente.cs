using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HormonaDeCrecimiento.App.Dominio;

namespace HormonaDeCrecimiento.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private readonly AppContext _appContext;
        public RepositorioPaciente(AppContext appContext){
            _appContext = appContext;
        }
        public IEnumerable<Paciente> GetAllPacientes(){
            return _appContext.Pacientes;
        }
        public Paciente AddPaciente(Paciente paciente){
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity;
        }
        public Paciente UpdatePaciente(Paciente paciente){
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p=>p.Id==paciente.Id);
            if(pacienteEncontrado!=null){
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellido = paciente.Apellido;
                pacienteEncontrado.Telefono = paciente.Telefono;
                pacienteEncontrado.Documento = paciente.Documento;
                pacienteEncontrado.Genero = paciente.Genero;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Latitud = paciente.Latitud;
                pacienteEncontrado.Longitud = paciente.Longitud;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                pacienteEncontrado.FechadeNacimiento = paciente.FechadeNacimiento;
                pacienteEncontrado.Patrones = paciente.Patrones;
                pacienteEncontrado.Familiar = paciente.Familiar;
                pacienteEncontrado.Historia = paciente.Historia;
                pacienteEncontrado.Endocrino = paciente.Endocrino;
                pacienteEncontrado.Pediatra = paciente.Pediatra;

               // _appContext.Pacientes.Update(pacienteEncontrado);
                _appContext.SaveChanges();
            }
            return pacienteEncontrado;
        }
        public void DeletePaciente(int idpaciente){

            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p=>p.Id==idpaciente);

            if(pacienteEncontrado==null){
                return;
            }

            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();

        }
        public Paciente GetPaciente(int idpaciente){

            return _appContext.Pacientes.FirstOrDefault(p=>p.Id==idpaciente);
        }

        public Medico AsignarMedico(int idpaciente, int idmedico){

            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p=>p.Id==idpaciente);           
            var medicoEncontrado =  _appContext.Medicos.FirstOrDefault(m=>m.Id==idmedico);
            
            if(pacienteEncontrado!=null && medicoEncontrado!=null){
                
                if( medicoEncontrado.Especialidad.ToLower() == "endocrino"){
                    pacienteEncontrado.Endocrino = medicoEncontrado;
                }
                if( medicoEncontrado.Especialidad.ToLower() == "pediatra"){
                    pacienteEncontrado.Pediatra = medicoEncontrado;
                }

                _appContext.SaveChanges();

                return medicoEncontrado;
            }

            return null;

        }

        public Familiar AsignarFamiliar(int idpaciente, int idfamiliar){

            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p=>p.Id==idpaciente);           
            var familiarEncontrado =  _appContext.Familiares.FirstOrDefault(f=>f.Id==idfamiliar);
            
            if(pacienteEncontrado!=null && familiarEncontrado!=null){
                
                pacienteEncontrado.Familiar = familiarEncontrado;

                _appContext.SaveChanges();

                return familiarEncontrado;
            }

            return null;

        }

    }
}