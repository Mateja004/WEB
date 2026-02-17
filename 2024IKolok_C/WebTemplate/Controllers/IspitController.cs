using WebTemplate.Migrations;

namespace WebTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class IspitController : ControllerBase
{
    public IspitContext Context { get; set; }

    public IspitController(IspitContext context)
    {
        Context = context;
    }

    [HttpPost("DodajRezervoar")]
    public async Task<IActionResult>DodajRezervoar([FromBody]Rezervoar rezervoar)
    {
        try
        {
            await Context.Rezervoars.AddAsync(rezervoar);
            await Context.SaveChangesAsync();
            return Ok($"Uspeno dodat rezervoar i dodeljen mu je id:{rezervoar.ID}");
        }catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPost("DodajRibu")]
    public async Task<IActionResult>DodajRibu([FromBody]Riba riba)
    {
        try
        {
            await Context.Ribas.AddAsync(riba);
            await Context.SaveChangesAsync();
            return Ok($"Uspeno dodat rezervoar i dodeljen mu je id:{riba.ID}");
        }catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPost("DodajURezervoar/{idRibe}/{idRezevoara}/{brJedinki}")]
    public async Task<IActionResult>DodajURezervoar(int idRibe, int idRezevoara, int brJedinki)
    {
        try
        {
            var rezervoar=await Context.Rezervoars.FindAsync(idRezevoara);
            if (rezervoar == null)
            {
                return NotFound("kara banana bato");
            }
            var riba=await Context.Ribas.FindAsync(idRibe);
            if (riba == null)
            {
                return NotFound("kara banana");
            }

            if (rezervoar.Kapacitet < brJedinki+rezervoar.BrojRiba)
            {
                return BadRequest("aha, kurcina...ovaj je pun");
            }
            var mogucaSmetnja= await Context
            .Akvarijums.Include(r=>r.P_Riba)
            .Where(p=>(p.P_Riba!.masa*10<=riba.masa)|| (p.P_Riba.masa>riba.masa*10))
            .FirstOrDefaultAsync();

            if (mogucaSmetnja != null)
            {
                return BadRequest("pojedose se");
            }
            rezervoar.BrojRiba+=brJedinki;
            Context.Rezervoars.Update(rezervoar);

            var Akvarijumm=new Akvarijum()
            {
                P_Rezervoar=rezervoar,
                P_Riba=riba,
                brojjediniki=brJedinki,
                DatumDodavanja=DateTime.Now,
            };
            
              await Context.Akvarijums.AddAsync(Akvarijumm);
              await Context.SaveChangesAsync();

              return Ok($"dodato{brJedinki}riba sa ID{idRibe} u rezervoar{idRezevoara}");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut("IzmeniBrojRibaUAkvarijumu/{idAkvarijuma}/{BrojJedinki}")]
    public async Task<IActionResult>IzmeniBrojJedinkiUAkvarijumu(int idAkvarijuma, int noviBrojJedinki)
    {
        try
        {
            var Akvarijum=await Context.Akvarijums.FindAsync(idAkvarijuma);
            if (Akvarijum == null)
            {
                return BadRequest("Kurcina");
            }

            if (Akvarijum.brojjediniki == noviBrojJedinki)
            {
                return BadRequest("vec ima toliko");
            }
            Akvarijum.brojjediniki=noviBrojJedinki;
            Akvarijum.DatumDodavanja=DateTime.Now;
            Context.Akvarijums.Update(Akvarijum);

            await Context.SaveChangesAsync();
            return Ok($"novi broj riba u akvarijumu{idAkvarijuma}je {noviBrojJedinki}");

        }catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("KojiTrebaDaSeOcisti")]
    public async Task<IActionResult> KojiTrebaDaSeCisti()
    {
        try
        {
            var rezervoar=await Context
            .Rezervoars
            .Where(p=>DateTime.Now.DayOfYear-p.PoslednjeCiscenje.DayOfYear>p.FrekvencijaCiscenja)
            .ToListAsync();

            if (rezervoar == null)
            {
                return Ok("ok");
            }
            return Ok(rezervoar);
        }catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
