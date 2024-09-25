using System.ComponentModel.DataAnnotations;

namespace Valasztas.Models
{
    public class Part
    {
        [Key]

        public string rovidnev { get; set; }
        public string? hosszunev { get; set; }

        public ICollection<Jelolt> Jeloltek
        {
            get; set;

        }
    }
}
