using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valasztas.Models
{
    public class Part
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]

        public string rovidnev { get; set; }
        public string? hosszunev { get; set; }

        public ICollection<Jelolt> Jeloltek
        {
            get; set;

        }
    }
}
