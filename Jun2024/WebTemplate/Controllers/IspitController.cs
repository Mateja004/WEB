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

    [HttpGet("VratiModele")]
    async public Task<ActionResult> VratiModele()
    {
        try
        {
            var model=await Context.Vozilos
            .Select(p=>new{Model=p.Model}).Distinct().ToListAsync();
            
            return Ok(model);
        }catch(Exception e)
        {
            return BadRequest(e.Message);
        }
         
    }
    
    [HttpGet("VratiAutomobile")]
    async public Task<ActionResult> VratiAuta()
    {
        var auta=await Context.Vozilos
        .Select(p => new
        {   
            p.ID,
            p.Model,
            p.PredjenaKilometraza,
            p.godiste,
            p.brojSedista,
            p.cenapodanu,
            p.iznajmljen
            
        }).ToListAsync();

        return Ok(auta);
    }

   [HttpGet("Filtriraj")]

   public async Task<ActionResult>Filtriraj(int kilometraza, int brsedista, int cenadana, string model)
    {
        var upit=Context.Vozilos.AsQueryable();

        if (kilometraza > 0)
        {
            upit=upit.Where(a=>a.PredjenaKilometraza<=kilometraza);
        }
        if (brsedista > 0)
        {
            upit=upit.Where(a=>a.brojSedista>=brsedista);
        }
        if (!string.IsNullOrEmpty(model))
        {
            upit=upit.Where(a=>a.Model==model);
        }
        if (cenadana > 0)
        {
            upit=upit.Where(a=>a.cenapodanu<=cenadana);
        }

        var rezultat=await upit
        .Select(p=> new
        {
            p.ID,
            p.Model,
            p.PredjenaKilometraza,
            p.godiste,
            p.brojSedista,
            p.cenapodanu,
            p.iznajmljen
        }).ToListAsync();

        return Ok(rezultat);
    }

    [HttpPost("IznajmiAuto")]

    public async Task<ActionResult> IznajmiAuto(int autoID, string Ime, string Prezime, string jmg, int BrojDozvole, int BrojDana)
    {
        var auto = await Context.Vozilos.FindAsync(autoID);
        if (auto == null)
        {
            return BadRequest("Nema");
        }
        if (auto.iznajmljen)
        {
            return BadRequest("Iznajmljen");
        }

        var korisnik=new Korisnik
        {
            ime=Ime,
            prezime=Prezime,
            JMBG=jmg,
            brojDozvole=BrojDozvole
        };
        Context.Korisniks.Add(korisnik);

        var iznajmljivanje=new Iznajmljivanje
        {
            brojDana=BrojDana,
            Vozilo=auto,
            Korisnik=korisnik
        };

        Context.Iznajmljivanjes.Add(iznajmljivanje);

        auto.iznajmljen=true;
        await Context.SaveChangesAsync();

        return Ok("Uspeno iznajmljen auto");

    }
    
}
