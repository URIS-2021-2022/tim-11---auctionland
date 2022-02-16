using System.ComponentModel.DataAnnotations;

namespace ParcelService.Database
{
    public class DeoParcele
    {
        [Key]
        public int BrojDelaParcele { get; set; }
        public int Povrsina { get; set;}
    }
}
