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
    
    [HttpGet("VratiProjekciju/{id}")]

    public async Task<ActionResult>VratiProjekciju(int id)
    {
        var projeckija=await Context.Projekcijas
        .Include(p=>p.Sala)
        .Where(p=>p.ID==id)
        .Select(p => new
        {
            p.NazivProjekcije,
            p.VremePikaza,
            NazivSale=p.Sala.NazivSale
        }).FirstOrDefaultAsync();

        if (projeckija == null)
        {
            return NotFound();
        }
        return Ok(projeckija);
    }

    [HttpGet("VratiBrojRedova/{idProjekcije}")]
    public async Task<ActionResult>VratiBrojRedova(int idProjekcije)
    {
        var brojredova=await Context.Projekcijas
        .Include(p=>p.Sala)
        .Where(p=>p.ID==idProjekcije)
        .Select(p => new
        {
            p.Sala.BrojRedova
        }).FirstOrDefaultAsync();
        if (brojredova == null)
        {
            return NotFound();
        }
        return Ok(brojredova);
    }

    [HttpGet("VratiBrojSedista/{idprojekcije}")]
    public async Task<ActionResult>VratiBrojSedista(int idprojekcije)
    {
        var brojsedista=await Context.Projekcijas
        .Include(p=>p.Sala)
        .Where(p=>p.ID==idprojekcije)
        .Select(p => new
        {
            p.Sala.BrojSedista
        }).FirstOrDefaultAsync();
        if (brojsedista == null)
        {
            return NotFound();
        }
        return Ok(brojsedista);
    }
    
   [HttpGet("VratiCenuKarte/{idprojekcije}/{red}/{sediste}")]
public async Task<ActionResult> VratiCenuKarte(int idprojekcije, int red, int sediste)
{
    var projekcija = await Context.Projekcijas
        .Where(p => p.ID == idprojekcije)
        .Select(p => new
        {
            p.ID,
            p.sifra
        })
        .FirstOrDefaultAsync();

    if (projekcija == null)
        return NotFound("Projekcija ne postoji");

    // bazna cena
    double cena = 300;

    // umanjenje po redu
    for (int i = 1; i < red; i++)
    {
        cena *= 0.97;
    }

    return Ok(new
    {
        Red = red,
        Sediste = sediste,
        SifraProjekcije = projekcija.sifra,
        Cena = Math.Round(cena, 2)
    });
}



    [HttpPost("KupiKartu/{red}/{sediste}/{cena}/{sifra}")]
    public async Task<ActionResult>KupiKartu(int red, int cena, int sediste, int sifra)
    {
        var projekcija=await Context.Projekcijas
        .Where(p=>p.sifra==sifra)
        .FirstOrDefaultAsync();
        if (projekcija == null)
        {
            return NotFound("nema");
        }
        if(Context.Projekcijas
        .Where(p=>p.Karte.Any(k=>k.RedNaKarti==red && k.SedisteNaKarti==sediste && k.Projekcija.ID==projekcija.ID))
        .FirstOrDefaultAsync()!=null)
        return BadRequest("Vec ima");

        var karta= new Karta
        {
            Projekcija=projekcija,
            RedNaKarti=red,
            SedisteNaKarti=sediste,
            CenaKarte=cena
        };

        try
        {
            Context.Kartas.Add(karta);
            await Context.SaveChangesAsync();
            return Ok("Karta kupljena");
        }catch(Exception e)
        {
            return BadRequest("Greska");
        }
    }

    [HttpGet("VratiZauzetoMesto/{id}")]

    public async Task<ActionResult>VratiZauzeto(int id)
    {
        var zauzeto=await Context.Kartas
        .Where(p=>p.Projekcija.ID==id)
        .Select(p=> new{p.RedNaKarti, p.SedisteNaKarti})
        .ToListAsync();

        return Ok(zauzeto);
    }

    [HttpGet("KupiUnapred")]

    public async Task<ActionResult> KupiUnapred()
    {
        var unapred=await Context.Projekcijas
        .Where(p=>p.VremePikaza>DateTime.Now)
        .Select(p=>new{p.ID})
        .ToListAsync();

        return Ok(unapred);
    }
}
