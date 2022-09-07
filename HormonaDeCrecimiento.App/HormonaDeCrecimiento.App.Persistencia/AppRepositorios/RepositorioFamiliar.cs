using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HormonaDeCrecimiento.App.Dominio;

namespace HormonaDeCrecimiento.App.Persistencia
{
    public class RepositorioFamiliar : IRepositorioFamiliar
    {
        private readonly AppContext _appContext;
        public RepositorioFamiliar(AppContext appContext){
            _appContext = appContext;
        }
        public IEnumerable<Familiar> GetAllFamiliares(){
            return _appContext.Familiares;
        }
        public Familiar AddFamiliar(Familiar familiar){

            if(familiar.Correo.Contains("@")){
            
                var familiarAdicionado = _appContext.Familiares.Add(familiar);
                _appContext.SaveChanges();
                return familiarAdicionado.Entity;

            }

            Console.WriteLine("Error el correo no contiene @,  "+ familiar.Correo);
            return null;
        }
        public Familiar UpdateFamiliar(Familiar familiar){
            var familiarEncontrado  = _appContext.Familiares.FirstOrDefault(f=>f.Id==familiar.Id);
            if(familiarEncontrado !=null){
                familiarEncontrado.Nombre = familiar.Nombre;
                familiarEncontrado.Apellido = familiar.Apellido;
                familiarEncontrado.Telefono = familiar.Telefono;
                familiarEncontrado.Documento = familiar.Documento;
                familiarEncontrado.Genero = familiar.Genero;
                familiarEncontrado.Parentesco = familiar.Parentesco;
                familiarEncontrado.Correo = familiar.Correo;

                if(familiarEncontrado.Correo.Contains("@")){
                    _appContext.SaveChanges();
                    return familiarEncontrado;

                }

                Console.WriteLine("Error el correo no contiene @,  "+ familiarEncontrado.Correo);
            }

            return familiarEncontrado;
        }
        public void DeleteFamiliar(int idfamiliar){

            var familiarEncontrado = _appContext.Familiares.FirstOrDefault(f=>f.Id==idfamiliar);

            if(familiarEncontrado==null){
                return;
            }

            _appContext.Familiares.Remove(familiarEncontrado);
            _appContext.SaveChanges();

        }
        public Familiar GetFamiliar(int idfamiliar){

            return _appContext.Familiares.FirstOrDefault(f=>f.Id==idfamiliar);
        }

    }
}