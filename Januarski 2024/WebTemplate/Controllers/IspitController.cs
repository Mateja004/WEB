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
    
    [Route("VratiSobu/{nazivSobe}")]
    [HttpGet]
    public async Task<ActionResult<ChatSoba>>vratiSobu(string nazivsobe)
    {
        var soba=await Context.ChatSobas
        .Where(p=>p.imeSobe==nazivsobe)
        .Select(p => new
        {
            p.ID,
            p.imeSobe,
            p.maksBrojClanova
        }).FirstOrDefaultAsync();

        if (soba == null)
        {
            return BadRequest("nema");
        }
        return Ok(soba);
    }
    [Route("VratiKorisnike")]
    [HttpGet]
    public async Task<ActionResult<Korisnik>> VratiKorisnika()
    {
        
            var korisnik=await Context.Korisniks
            .Select(p=> new
            {
                p.ID,
                p.korisnickoime
            }).ToListAsync();
            return Ok(korisnik);
    }
    [Route("VratiSobe")]
    [HttpGet]
    public async Task<ActionResult<ChatSoba>> VratiSobe()
    {
        var sobe=await Context.ChatSobas
        .Select(p => new
        {
            p.ID,
            p.imeSobe,
        }).ToListAsync();

        return Ok(sobe);
    }
    [HttpPost("UbaciKorisnikaUSobu/{sobanaziv}/{idkorisnika}/{nadimak}/{boja}")]
    public async Task<ActionResult>Chatuj(string sobanaziv, int idkorisnika, string boja, string nadimak)
    {
        var soba=await Context.ChatSobas.Where(p=>p.imeSobe==sobanaziv).FirstOrDefaultAsync();
        var korisnik=await Context.Korisniks.Where(p=>p.ID==idkorisnika).FirstOrDefaultAsync();
        if( korisnik==null)
        {
            return BadRequest("Nesto ne valja");
        }
        if(soba==null)
        {
            soba=new ChatSoba{imeSobe=sobanaziv, maksBrojClanova=5};
            Context.ChatSobas.Add(soba);
            await Context.SaveChangesAsync();
        }

        int brojclanova= Context.Chats
        .Where(p=>p.A_ChatSoba.ID==soba.ID)
        .Count();

        if (brojclanova >= soba.maksBrojClanova)
        {
            return BadRequest("nema mesta");
        }

        try
        {
            Context.Chats.Add(new Chat{A_ChatSoba=soba,A_Korisnik=korisnik,Nadimak=nadimak,Boja=boja});
            await Context.SaveChangesAsync();
            return Ok("bravo");
        }catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("PrikaziJedinstvene/{sobaId}")]
    public async Task<ActionResult>VratiJedinstvene(int sobaId)
    {
        var korisnici=await Context.Chats
        .Where(p=>p.A_ChatSoba.ID==sobaId)
        .Include(p=>p.A_Korisnik)
        .Select(p=>p.A_Korisnik.ID)
        .ToListAsync();

        int brojjedinstvenih=0;
        foreach(var korinik in korisnici)
        {
            if (Context.Chats.Where(p => p.A_Korisnik.ID == korinik).Count() == 1)
            {
                brojjedinstvenih++;
            }
        }
        return Ok(brojjedinstvenih);
    }
}
