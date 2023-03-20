using Microsoft.AspNetCore.Mvc;

namespace RpgApi.Controllers

{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonagensController(DataContext context)
        {
            //inicializacao do atributo a partir de uma parametro
            _context = context;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                PersonagensExemploController p = await _context.Personagens
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                List<Personagens> lista = await _context.Personagens.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Personagem novoPersonagem)
        {
            try
            {
                if (novoPersonagem.PontosVida > 100)
                {
                    throw new Exception("Pontos de Vida não pode ser maior que 100");
                }
                await _context.Personagens.AddAsync(novoPersonagem);
                await _context.SaveChangesAsync();

                return Ok(novoPersonagem.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Personagem novoPersonagem)
        {
            try
            {
                if (novoPersonagem.PontosVida > 100)
                {
                    throw new Exception("Pontos de Vida não pode ser maior que 100");
                }
                _context.Personagens.Update(novoPersonagem);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(novoPersonagem.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    [HttpDelete("{id}")]

    public async Task<IActionREsult> Delete(int id)
    {
        try
        {
            Personagem pRemover = await _context.Personagens
            .FirstOrDefaultAsync(pRemover => pRemover.Id == id);

            _context.Personagens.Remove(pRemover);
            int linhasAfetadas = await _context.SaveChangesAsync();

            return Ok(linhasAfetadas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("GetUser")]
    public async Task<IActionResult> Get(Usuario u)
    {
        try
        {
            Usuario uRetornado = await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Username == u.Username && x.Email == u.Email);

            if (uRetornado == null)
                throw new Exception("Usuario não encontrado");

            return Ok(uRetornado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}