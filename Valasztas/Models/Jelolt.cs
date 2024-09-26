namespace Valasztas.Models
{
    public class Jelolt
    {
        public Jelolt()
        {
        }
        public int id { get; set; }
        public string name { get; set; }
        public int Kerulet { get; set; }
        public int szavazatszam { get; set; }

        public string PartRovidNev { get; set; }
        public Part Part { get; set; }
    }
}
