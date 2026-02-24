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

    [HttpGet("VratiStanove")]
    public async Task<ActionResult> VratiStanove()
    {
        var stan=await Context.Stans
        .Select(p => new
        {
            p.ID,
            p.imevlasnika
        }).ToListAsync();

        if (stan == null)
        {
            return NotFound("nema");
        }
        return Ok(stan);
    }

    [HttpGet("VratiStan/{id}")]
    public async Task<ActionResult>VratiStan(int id)
    {
        var stan=await Context.Stans
        .Where(p=>p.ID==id)
        .Select(p => new
        {
            ImeVlasnika=p.imevlasnika,
            Povrsina=p.povrsina,
            BrojClanova=p.brojClanova
        }).FirstOrDefaultAsync();

        if (stan == null)
        {
            return NotFound("Nema");
        }
        return Ok(stan);
    }
    [HttpGet("VratiRacune/{stanid}")]
    public async Task<ActionResult>VratiRacune(int stanid)
    {
        var racun=await Context.Racuns
        .Include(p=>p.Stan)
        .Where(p=>p.Stan.ID==stanid)
        .Select(p => new
        {
            p.MesecIzdavanja,
            p.CenaVode,
            p.CenaStruje,
            p.KomUsluge,
            p.Placen
        }).ToListAsync();

        if (racun == null)
        {
            return BadRequest("nema");
        }

        return Ok(racun);
    }

    [HttpGet("IzracunajZaduzenje/{stanid}")]
    public async Task<ActionResult>IzracunajZaduzenje(int stanid)
    {
        var racuni=await Context.Racuns
        .Include(p=>p.Stan)
        .Where(p=>p.Stan.ID==stanid)
        .Where(r=>r.Placen==false)
        .ToListAsync();

        double ukupno=0;
        foreach(var r in racuni)
        {
            ukupno+=r.CenaStruje+r.CenaVode+r.KomUsluge;
        }
        return Ok(ukupno);
    }
}
