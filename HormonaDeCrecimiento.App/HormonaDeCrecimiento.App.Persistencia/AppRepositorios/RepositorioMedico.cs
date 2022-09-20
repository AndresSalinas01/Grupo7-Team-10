using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HormonaDeCrecimiento.App.Dominio;

namespace HormonaDeCrecimiento.App.Persistencia
{
    public class RepositorioMedico : IRepositorioMedico
    {
        private readonly AppContext _appContext;
        public RepositorioMedico(AppContext appContext){
            _appContext = appContext;
        }
        public IEnumerable<Medico> GetAllMedicos(){
            return _appContext.Medicos;
        }
        public Medico AddMedico(Medico medico){
            var medicoAdicionado = _appContext.Medicos.Add(medico);
            _appContext.SaveChanges();
            return medicoAdicionado.Entity;
        }
        public Medico UpdateMedico(Medico medico){
            var medicoEncontrado  = _appContext.Medicos.FirstOrDefault(m=>m.Id==medico.Id);
            if(medicoEncontrado !=null){
                medicoEncontrado.Nombre = medico.Nombre;
                medicoEncontrado.Apellido = medico.Apellido;
                medicoEncontrado.Telefono = medico.Telefono;
                medicoEncontrado.Documento = medico.Documento;
                medicoEncontrado.Genero = medico.Genero;
                medicoEncontrado.Especialidad = medico.Especialidad;
                medicoEncontrado.Codigo = medico.Codigo;
                medicoEncontrado.RegistroRethus = medico.RegistroRethus;

                _appContext.SaveChanges();
            }
            return medicoEncontrado;
        }
        public void DeleteMedico(int idmedico){

            var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m=>m.Id==idmedico);

            if(medicoEncontrado==null){
                return;
            }

            _appContext.Medicos.Remove(medicoEncontrado);
            _appContext.SaveChanges();

        }
        public Medico GetMedico(int idmedico){

            return _appContext.Medicos.FirstOrDefault(m=>m.Id==idmedico);
        }

        public IEnumerable<Paciente> PacientesMedico(int idmedico){
            
            var medicoEncontrado =  _appContext.Medicos.FirstOrDefault(m=>m.Id==idmedico);
            
            if(medicoEncontrado!=null){
                
                if( medicoEncontrado.Especialidad.ToLower() == "endocrino"){
                    return _appContext.Pacientes.Where(p=>p.Endocrino.Id==idmedico).ToList();
                }
                if( medicoEncontrado.Especialidad.ToLower() == "pediatra"){
                    return _appContext.Pacientes.Where(p=>p.Pediatra.Id==idmedico).ToList();
                }
            }
            return null;
        }
        
    }
}