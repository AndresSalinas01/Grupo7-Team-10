namespace HormonaDeCrecimiento.App.Dominio
{
    public class Historia
    {
        public int Id{get;set;}
        public string Diagnostico{get;set;}
        public System.Collections.Generic.List<SugerenciaCuidado> Sugerencias{get;set;}
    }
}