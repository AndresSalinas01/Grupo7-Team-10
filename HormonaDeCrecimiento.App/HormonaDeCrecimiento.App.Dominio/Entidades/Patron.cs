namespace HormonaDeCrecimiento.App.Dominio
{
    public class Patron
    {
        public int Id{get;set;}
        public DateTime FechaHora{get;set;}
        public float Valor{get;set;}
        public TipoPatron TipoPatron{get;set;}
    }
}