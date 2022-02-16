using Microsoft.AspNetCore.Mvc;
using ParcelService.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParcelService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        ParcelDbContext db;

        public ParcelController()
        {
            db = new ParcelDbContext();
        }
        // GET: api/<ParcelController>
        [HttpGet]
        public IEnumerable<Parcel> Get()
        {
            return db.Parcels.ToList();
        }

        // GET: api/<ParcelController>/katop
        [HttpGet("katop")]
        public  IEnumerable<KatastarskaOpstina> Gets()
        {
            return db.KatastarskaOpstina.ToList();
        }

        

        // GET api/<ParcelController>/5
        [HttpGet("{id}")]
        public Parcel Get(int id)
        {
            return db.Parcels.Find(id);
        }


        // GET api/<ParcelController>/5
        [HttpGet("katop/{id}")]
        public KatastarskaOpstina Gets(int id)
        {
            return db.KatastarskaOpstina.Find(id);
        }

        // POST api/<ParcelController>
        [HttpPost]
        public ObjectResult Post([FromBody] Parcel model)
        {
            try { 
                db.Parcels.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        // PUT api/<ParcelController>/5
        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] Parcel model)
        {
            var temp = new Parcel();
            temp = db.Parcels.Find(id);
            if (temp.KorisnikParcele != null)
                temp.KorisnikParcele = model.KorisnikParcele;
            if(temp.KatastarskaOpstina != null)
                temp.KatastarskaOpstina = model.KatastarskaOpstina;
            if(temp.Povrsina != null)
                temp.Povrsina = model.Povrsina;
            if(temp.BrListaNepokretnosti != null)
                temp.BrListaNepokretnosti = model.BrListaNepokretnosti;
            if(temp.Kultura != null)
                temp.Kultura = model.Kultura;
            if(temp.Klasa != null)
                temp.Klasa = model.Klasa;
            if(temp.Obradivost != null)
                temp.Obradivost = model.Obradivost;
            if(temp.ZasticenaZona != null)
                temp.ZasticenaZona = model.ZasticenaZona;
            if(temp.OblikSvojine != null)
                temp.OblikSvojine = model.OblikSvojine;
            if(temp.Odvodnjavanje != null)
                temp.Odvodnjavanje = model.Odvodnjavanje;
            if(temp.KulturaStvStanje != null)
                temp.KulturaStvStanje = model.KulturaStvStanje;
            if(temp.KlasaStvStanje !=null)
                temp.KlasaStvStanje=model.KlasaStvStanje;
            if (temp.ObradivostStvStanje != null)
                temp.ObradivostStvStanje = model.ObradivostStvStanje;
            if (temp.ZasticenaZonaStvStanje != null)
                temp.ZasticenaZonaStvStanje = model.ZasticenaZonaStvStanje;
            if (temp.OblikSvojineStvStanje != null)
                temp.OblikSvojineStvStanje=model.OblikSvojineStvStanje;
            db.Parcels.Add(temp);
            db.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, temp);

        }

        // DELETE api/<ParcelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var temp = new Parcel() { BrojParcele = id };
            db.Parcels.Remove(temp);
            db.SaveChanges();
        }
    }
}
