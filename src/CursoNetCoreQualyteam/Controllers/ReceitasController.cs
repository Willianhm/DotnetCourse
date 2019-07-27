using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CursoNetCoreQualyteam.Infraestrutura;
using CursoNetCoreQualyteam.Dominio;

namespace CursoNetCoreQualyteam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly ReceitasContext _context;

        public ReceitasController(ReceitasContext context){
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ReceitaViewModel>> Get()
        {
            return _context.Receitas.Select(receita => 
                new ReceitaViewModel()
                {
                    Id = receita.Id,
                    Title = receita.Title,
                    Description =  receita.Description,
                    Ingredients = receita.Ingredients,
                    Preparation =  receita.Preparation,
                    ImageUrl = receita.ImageUrl

                }
            ).ToArray();
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ReceitaViewModel> Insert([FromBody] ReceitaViewModel receitaPayload)
        {
            var receita = new Receita(receitaPayload.Title, receitaPayload.Description, receitaPayload.Ingredients, receitaPayload.Preparation, receitaPayload.ImageUrl);
            _context.Receitas.Add(receita);
            _context.SaveChanges();

            var newViewModel = new ReceitaViewModel(receita.Id, receita.Title, receita.Description, receita.Ingredients, receita.Preparation, receita.ImageUrl);
            return newViewModel;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<ReceitaViewModel> Update(int id, [FromBody] ReceitaViewModel receitaViewModel)
        {
            var receitaBanco = _context.Receitas
                .Where(receita => receita.Id == id)
                .FirstOrDefault();

            if(receitaBanco == null){
                return null;
            }

            receitaBanco.Update(receitaViewModel.Title, receitaViewModel.Description);

            _context.Receitas.Update(receitaBanco);
            _context.SaveChanges();

            var newViewModel = new ReceitaViewModel(receitaBanco.Id, receitaBanco.Title, receitaBanco.Description, receitaBanco.Ingredients, receitaBanco.Preparation, receitaBanco.ImageUrl);
            return newViewModel;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ReceitaViewModel> GetOne(int id)
        {
            return _context.Receitas
                .Where(receita => receita.Id == id)
                .Select(receita => 
                    new ReceitaViewModel()
                    {
                        Id = receita.Id,
                        Title = receita.Title,
                        Description =  receita.Description,
                        Ingredients = receita.Ingredients,
                        Preparation =  receita.Preparation,
                        ImageUrl = receita.ImageUrl

                    }
            ).FirstOrDefault();
        }
    }


    public class ReceitaViewModel{
        public ReceitaViewModel()
        {
        }

        public ReceitaViewModel(int id, string title, string description, string ingredients, string preparation, string imageUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            Ingredients = ingredients;
            Preparation = preparation;
            ImageUrl = imageUrl;
        }

        public int Id { get;  set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public string Ingredients { get;  set; }
        public string Preparation { get;  set; }
        public string ImageUrl { get;  set; }
    }

}
