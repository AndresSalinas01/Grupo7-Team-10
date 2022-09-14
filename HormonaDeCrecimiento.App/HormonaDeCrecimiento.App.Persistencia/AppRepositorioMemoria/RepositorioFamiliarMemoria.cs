using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HormonaDeCrecimiento.App.Dominio;


namespace HormonaDeCrecimiento.App.Persistencia
{
    public class RepositorioFamiliarMemoria : IRepositorioFamiliarMemoria
    {
        List<Familiar> Familiares;

        public RepositorioFamiliarMemoria()
        {
             Familiares = new List<Familiar>(){
                new Familiar{
                    Id = 1,
                    Nombre = "Carlos",
                    Apellido = "Ramirez",
                    Telefono = "111221",
                    Documento = "12333",
                    Genero = Genero.Masculino,
                    Parentesco= "Padre",
                    Correo = "Carlos.Ramirez@gmail.com"
                },
                new Familiar{
                    Id = 2,
                    Nombre = "Luisa",
                    Apellido = "Rosales",
                    Telefono = "1111121",
                    Documento = "333333",
                    Genero = Genero.Femenino,
                    Parentesco= "Madre",
                    Correo = "Luisa.Rosales@gmail.com"
                }
            };

        }

        public IEnumerable<Familiar> GetAllFamiliares(){
            return Familiares;
        }
        public Familiar AddFamiliar(Familiar Familiar){
            Familiar.Id = Familiares.Max(m=>m.Id)+1;
            Familiares.Add(Familiar);
            return Familiar;
        }
        public Familiar UpdateFamiliar(Familiar Familiar){

            var FamiliarEncontrado  = Familiares.SingleOrDefault( m=> m.Id == Familiar.Id);
            var index = Familiar.Id -1;
            if(FamiliarEncontrado !=null){
                Familiares[index].Nombre = Familiar.Nombre;
                Familiares[index].Apellido = Familiar.Apellido;
                Familiares[index].Telefono = Familiar.Telefono;
                Familiares[index].Documento = Familiar.Documento;
                Familiares[index].Genero = Familiar.Genero;
                Familiares[index].Parentesco = Familiar.Parentesco;
                Familiares[index].Correo = Familiar.Correo;
            }
            return FamiliarEncontrado;
        }
        public void DeleteFamiliar(int idFamiliar){

            
            var FamiliarEncontrado = Familiares.SingleOrDefault( m=> m.Id == idFamiliar);

            if(FamiliarEncontrado==null){
                return;
            }

            Familiares.Remove(FamiliarEncontrado);

            
        }
        public Familiar GetFamiliar(int idFamiliar){
            return Familiares.SingleOrDefault( m=> m.Id == idFamiliar);
        }

    }
}