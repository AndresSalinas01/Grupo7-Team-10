using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HormonaDeCrecimiento.App.Dominio;


namespace HormonaDeCrecimiento.App.Persistencia
{
    public class RepositorioMedicoMemoria : IRepositorioMedicoMemoria
    {
        List<Medico> medicos;

        public RepositorioMedicoMemoria()
        {
             medicos = new List<Medico>(){
                new Medico{
                    Id = 1,
                    Nombre = "Carlos",
                    Apellido = "Ramirez",
                    Telefono = "111221",
                    Documento = "12333",
                    Genero = Genero.Masculino,
                    Especialidad = "Pediatra",
                    Codigo = "1222",
                    RegistroRethus = "PE1236"
                },
                new Medico{
                    Id = 2,
                    Nombre = "Luisa",
                    Apellido = "Rosales",
                    Telefono = "1111121",
                    Documento = "333333",
                    Genero = Genero.Femenino,
                    Especialidad = "Endocrino",
                    Codigo = "13333",
                    RegistroRethus = "PE13336"
                }
            };

        }

        public IEnumerable<Medico> GetAllMedicos(){
            return medicos;
        }
        public Medico AddMedico(Medico medico){
            medico.Id = medicos.Max(m=>m.Id)+1;
            medicos.Add(medico);
            return medico;
        }
        public Medico UpdateMedico(Medico medico){

            var medicoEncontrado  = medicos.SingleOrDefault( m=> m.Id == medico.Id);
            var index = medico.Id -1;
            if(medicoEncontrado !=null){
                medicos[index].Nombre = medico.Nombre;
                medicos[index].Apellido = medico.Apellido;
                medicos[index].Telefono = medico.Telefono;
                medicos[index].Documento = medico.Documento;
                medicos[index].Genero = medico.Genero;
                medicos[index].Especialidad = medico.Especialidad;
                medicos[index].Codigo = medico.Codigo;
                medicos[index].RegistroRethus = medico.RegistroRethus;
            }
            return medicoEncontrado;
        }
        public void DeleteMedico(int idmedico){

            
            var medicoEncontrado = medicos.SingleOrDefault( m=> m.Id == idmedico);

            if(medicoEncontrado==null){
                return;
            }

            medicos.Remove(medicoEncontrado);

            
        }
        public Medico GetMedico(int idmedico){
            return medicos.SingleOrDefault( m=> m.Id == idmedico);
        }

    }
}