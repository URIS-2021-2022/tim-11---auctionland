using System.ComponentModel.DataAnnotations;

namespace ParcelService.Database
{
    public class KatastarskaOpstina
    {
        [Key]
        public int IdOpstine { get; set; }
        public string NazivOpstine { get; set; }
    }
}
