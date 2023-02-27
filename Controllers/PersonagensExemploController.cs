using Microsoft.AspNetCore.Mvc;
using RpgApi.Models.Enuns;
using RpgApi.Models;
namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensExemploController : ControllerBase
    {
        
        
        /*Personagem p1 = new Personagem();
        p1.Nome = "Gerald";
        personagens.Add(p1);

        Personagem p2 = new Personagem();
        p1.Nome = "Frodo";
        personagens.Add(p2);*/
        private static List<Personagem> personagens = new List<Personagem>()
        {
            //Colar os objetos da lista do chat aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
             return Ok(personagens);
        }

        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            Personagem p = personagens[0];
             return Ok(p);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
             return Ok(personagens.FirstOrDefault(personagens => personagens.Id == id));
        }

        public IActionResult AddPersonagem(Personagem novoPersonagem)
        {  
            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

    [HttpPut]

    public IAtctionResult UpdatePersonagem(Personagem p)

    {
        PersonagensExemploController personagemAlterado = personagemAlterado.Find(pers => pers.Id == p.Id);
        personagemAlterado.Nome = p.Nome;
        personagemAlterado.PontosVida = p.PontosVida;
        personagemAlterado.Forca = p.Forca;
        personagemAlterado.Defesa = p.Defesa;
        personagemAlterado.Inteligencia = p.Inteligencia;
        personagemAlterado.Classe = p.Classe;

        return Ok(personagens);

    }
}       
        
}