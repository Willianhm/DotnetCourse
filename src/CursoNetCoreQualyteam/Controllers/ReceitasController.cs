using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CursoNetCoreQualyteam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ReceitaViewModel>> Get()
        {
            return new ReceitaViewModel[]
                {
                    new ReceitaViewModel(){
                        Id = 1,
                        Title = "Batata frita",
                        Description =  "Batata frita é aquele acompanhamento do qual todo mundo gosta e também é um aperitivo delicioso.",
                        Ingredients = "Batata, óleo e sal a gosto.",
                        Preparation =  "1) Dê preferência à batata asterix, também conhecida como rosada ou portuguesa. Ela tem menos água do que os outros tipos de batata.\n2) Lave bem as batatas em água corrente e, se eles estiverem muito sujas, use uma escovinha para limpá-las.\n3) Descasque as batatas e deixe-as de molho: isso evita que elas escureçam.\n4) Depois, é só cortá-las do jeito que você preferir: em palitos grossos ou finos, em rodelas, chips…\n5) Seque bem as batatas com papel-toalha ou pano de prato limpo: isso vai fazer com que o óleo não espirre em você durante a fritura.\n6) Coloque óleo em uma panela alta e leve ao fogo. Para ver se o óleo está quente o suficiente, coloque um palito de fósforo dentro da panela: quando ele acender, é sinal de que o óleo está bom para ser usado. Retire o palito de fósforo.\n7) Coloque um pouco das batatas no panela e mexa com cuidado para que elas não grudem. Depois, pare de mexer. Quando as batatas estiverem esbranquiçadas, retire-as do óleo e coloque-as numa travessa com papel-toalha. Você pode fazer isso bem antes de as batatas serem servidas.\n8) Um pouco antes da refeição, esquente novamente o óleo e coloque as batatas já pré-fritas. Deixe que fritem até que fiquem douradinhas, retire do óleo e leve para uma travessa forrada com papel-toalha.\n9) Depois, é só colocar sal e servir sua batata frita crocante e sequinha!",
                        ImageUrl = "https://img.elo7.com.br/product/original/1DEEFB7/caixinha-embalagem-batata-frita-e-porcoes-peq-preto-500un-embalagem-food-truck.jpg"
                    },
                    new ReceitaViewModel(){
                        Id = 2,
                        Title = "Macarronada",
                        Description =  "Perfeito para servir em reuniões da família.",
                        Ingredients = "1 pacote de macarrão para macarronada \n1 caixa de extrato de tomate (grande)\n1/2 kg de carne moída\nCebolinha, pimentaõ, cheiro verde, alho, tomate (para temperar carne) knnor\n2 creme de leite\n200 g de queijo mussarela\n100 g de presunto",
                        Preparation =  "1) Dê preferência à batata asterix, também conhecida como rosada ou portuguesa. Ela tem menos água do que os outros tipos de batata.\n2) Lave bem as batatas em água corrente e, se eles estiverem muito sujas, use uma escovinha para limpá-las.\n3) Descasque as batatas e deixe-as de molho: isso evita que elas escureçam.\n4) Depois, é só cortá-las do jeito que você preferir: em palitos grossos ou finos, em rodelas, chips…\n5) Seque bem as batatas com papel-toalha ou pano de prato limpo: isso vai fazer com que o óleo não espirre em você durante a fritura.\n6) Coloque óleo em uma panela alta e leve ao fogo. Para ver se o óleo está quente o suficiente, coloque um palito de fósforo dentro da panela: quando ele acender, é sinal de que o óleo está bom para ser usado. Retire o palito de fósforo.\n7) Coloque um pouco das batatas no panela e mexa com cuidado para que elas não grudem. Depois, pare de mexer. Quando as batatas estiverem esbranquiçadas, retire-as do óleo e coloque-as numa travessa com papel-toalha. Você pode fazer isso bem antes de as batatas serem servidas.\n8) Um pouco antes da refeição, esquente novamente o óleo e coloque as batatas já pré-fritas. Deixe que fritem até que fiquem douradinhas, retire do óleo e leve para uma travessa forrada com papel-toalha.\n9) Depois, é só colocar sal e servir sua batata frita crocante e sequinha!",
                        ImageUrl = "https://images-americanas.b2w.io/produtos/01/00/sku/38259/3/38259310_1GG.jpg"
                    }
                };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


    public class ReceitaViewModel{
        public int Id { get;  set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public string Ingredients { get;  set; }
        public string Preparation { get;  set; }
        public string ImageUrl { get;  set; }
    }

}
