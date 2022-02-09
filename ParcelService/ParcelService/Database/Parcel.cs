using System.ComponentModel.DataAnnotations;
namespace ParcelService.Database
{
    public class Parcel
    {
        [Key]
        public int BrojParcele  { get; set; }
        public int? KorisnikParcele { get; set; }
        public int? KatastarskaOpstina { get; set; }
        public int? Povrsina { get; set; }
        public int? BrListaNepokretnosti { get; set; }
        public string? Kultura { get; set; }
        public string? Klasa { get; set; }
        public string? Obradivost { get; set; }
        public string? ZasticenaZona { get; set; }
        public string? OblikSvojine { get; set; }
        public string? Odvodnjavanje { get; set; }
        public string? KulturaStvStanje { get; set; }
        public string? KlasaStvStanje { get; set; }
        public string? ObradivostStvStanje { get; set; }
        public string? ZasticenaZonaStvStanje { get; set; }
        public string? OblikSvojineStvStanje { get; set; }


    }
}
