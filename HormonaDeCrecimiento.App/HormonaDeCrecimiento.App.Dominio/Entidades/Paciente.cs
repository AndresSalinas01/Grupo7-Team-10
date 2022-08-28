namespace HormonaDeCrecimiento.App.Dominio
{
    public class Paciente:Persona
    {

        public string Direccion{get;set;}
        public float Latitud{get;set;}
        public float Longitud{get;set;}
        public string Ciudad{get;set;}
        public DateTime FechadeNacimiento{get;set;}
        public Patron Patron{get;set;}
        public Familiar Familiar{get;set;}
        public Historia Historia{get;set;}
        public Medico Endocrino{get;set;}
        public Medico Pediatra{get;set;}
        public System.Collections.Generic.List<Patron> Patrones{get;set;}

    }
}