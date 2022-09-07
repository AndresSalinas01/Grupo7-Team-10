using System;
using HormonaDeCrecimiento.App.Dominio;
using HormonaDeCrecimiento.App.Persistencia;

namespace HormonaDeCrecimiento.App.Consola{

    class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        private static IRepositorioMedico _repoMedico = new RepositorioMedico(new Persistencia.AppContext());
        private static IRepositorioFamiliar _repoFamiliar = new RepositorioFamiliar(new Persistencia.AppContext());
        static void Main(string[] arg){
            //Console.WriteLine("");
            //AddPaciente();
            //BuscarPaciente(1);
            //EliminarPaciente(2);
            //ActualizarPaciente(1);
            //AddMedico();
            //AsignarMedico(1,3);
            MostrarPacientes();
            //BuscarMedico(3);
            //MostrarMedicos();
            //ActualizarMedico(4);
            //EliminarMedico(4);
            //AddFamiliar();
           // AsignarFamiliar(1,5);
            //BuscarFamiliar(6);
           // MostrarFamiliares();
           //EliminarFamiliar(6);
           //ActualizarFamiliar(7);
        }

        //PACIENTE

        private static void AddPaciente(){

            var paciente = new Paciente{

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
            };

            _repoPaciente.AddPaciente(paciente);
        }

        private static void BuscarPaciente(int idPaciente){

            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine(
                    "Id: " + paciente.Id +
                    "\nNombre: " + paciente.Nombre + 
                    "\nApellido: " + paciente.Apellido +
                    "\nTelefono: " + paciente.Telefono +
                    "\nDireccion: " + paciente.Direccion);
        }

        private static void MostrarPacientes(){

            var pacientes= _repoPaciente.GetAllPacientes();
            foreach(var paciente in pacientes){
            Console.WriteLine(
                    "\nId: " + paciente.Id +
                    "\nNombre: " + paciente.Nombre + 
                    "\nApellido: " + paciente.Apellido +
                    "\nTelefono: " + paciente.Telefono +
                    "\nDireccion: " + paciente.Direccion);
            }
        }

        private static void EliminarPaciente(int idPaciente){

            _repoPaciente.DeletePaciente(idPaciente);

        }

        private static void ActualizarPaciente(int idPaciente){

            var paciente = new Paciente{

                Id = idPaciente,
                Nombre = "Carolina",
                Apellido = "Toloza",
                Telefono = "312233",
                Documento = "75000",
                Genero = Genero.Masculino,
                Direccion = "Call3 1",
                Latitud = 0.1243F,
                Longitud = -1.2333F,
                Ciudad = "Manizales",
                FechadeNacimiento = new DateTime(2001,04,12)
            };

            _repoPaciente.UpdatePaciente(paciente);
        }

        private static void AsignarMedico(int idpaciente, int idmedico){

            var medico = _repoPaciente.AsignarMedico(idpaciente,idmedico);

        }

        private static void AsignarFamiliar(int idpaciente, int idfamiliar){

            var familiar = _repoPaciente.AsignarFamiliar(idpaciente,idfamiliar);

        }

        //MEDICO 

        private static void AddMedico(){

            var medico = new Medico{

                Nombre = "Carlos",
                Apellido = "Ramirez",
                Telefono = "111221",
                Documento = "12333",
                Genero = Genero.Masculino,
                Especialidad = "Pediatra",
                Codigo = "1222",
                RegistroRethus = "PE1236"

            };

            _repoMedico.AddMedico(medico);
        }

        private static void BuscarMedico(int idmedico){

            var medico = _repoMedico.GetMedico(idmedico);
            Console.WriteLine("Nombre Medico: " + medico.Nombre + " -- Apellido Medico: " + medico.Apellido);
        }

        private static void MostrarMedicos(){

            var medicos= _repoMedico.GetAllMedicos();
            foreach(var medico in medicos){
                Console.WriteLine("Nombre Medico: " + medico.Nombre + " -- Apellido Medico: " + medico.Apellido);
            }
        }

        private static void EliminarMedico(int idmedico){

            _repoMedico.DeleteMedico(idmedico);

        }

        private static void ActualizarMedico(int idmedico){

            var medico = new Medico{
                Id = idmedico,
                Nombre = "Pedro",
                Apellido = "Rios",
                Telefono = "34345",
                Documento = "34444",
                Genero = Genero.Masculino,
                Especialidad = "Pediatra",
                Codigo = "1233",
                RegistroRethus = "PE12444"
            };
            _repoMedico.UpdateMedico(medico);
        }

        //FAMILIAR

        private static void AddFamiliar(){

            var familiar = new Familiar{

                Nombre = "Marcos",
                Apellido = "Perez",
                Telefono = "33322",
                Documento = "121212",
                Genero = Genero.Masculino,
                Parentesco = "Padre",
                Correo = "marcos@gmail.com"

            };

            _repoFamiliar.AddFamiliar(familiar);
        }

        private static void BuscarFamiliar(int idfamiliar){

            var familiar = _repoFamiliar.GetFamiliar(idfamiliar);
            Console.WriteLine("Nombre Familiar: " + familiar.Nombre + " -- Apellido Familiar: " + familiar.Apellido);
        }

        private static void MostrarFamiliares(){

            var familiares = _repoFamiliar.GetAllFamiliares();
            foreach(var familiar in familiares){
                 Console.WriteLine("Nombre Familiar: " + familiar.Nombre + " -- Apellido Familiar: " + familiar.Apellido);
            }
        }

        private static void EliminarFamiliar(int idfamiliar){

            _repoFamiliar.DeleteFamiliar(idfamiliar);

        }

        private static void ActualizarFamiliar(int idfamiliar){

            var familiar = new Familiar{

                Id = idfamiliar,
                Nombre = "Marcos",
                Apellido = "Perez",
                Telefono = "33322",
                Documento = "121212",
                Genero = Genero.Masculino,
                Parentesco = "Padre",
                Correo = "marcosgmail.com"

            };

            _repoFamiliar.UpdateFamiliar(familiar);
        }

    }

}

