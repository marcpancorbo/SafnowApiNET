namespace Safnow.Model
{
    public class Ubication : Identifiable
    {
        public string Altitude { get; set; }
        public string Latitude { get; set; }
        public Alerta Alert { get; set; }
        public int AlertaId { get; set; }
    }
}