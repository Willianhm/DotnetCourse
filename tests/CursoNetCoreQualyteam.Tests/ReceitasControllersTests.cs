using System;
using System.Linq;
using CursoNetCoreQualyteam.Dominio;
using CursoNetCoreQualyteam.Infraestrutura;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CursoNetCoreQualyteam.Controllers.Tests
{
    public class ReceitasControllersTests
    {

        private ReceitasContext CreateTestContext()
        {
            var options = new DbContextOptionsBuilder<ReceitasContext>()
                .UseInMemoryDatabase("database")
                .Options;
            return new ReceitasContext(options);
        }

        [Fact]
        public async void GetAll_DeveResponderComTodasAsReceitasCadastradasAsync()
        {
            var batataFrita = new Receita()
            {
                Id = 1,
                Title = "Batata frita",
                Description = "Batata frita é aquele acompanhamento do qual todo mundo gosta e também é um aperitivo delicioso.",
                Ingredients = "Batata, óleo e sal a gosto.",
                Preparation = "1) Dê preferência à batata asterix, também conhecida como rosada ou portuguesa. Ela tem menos água do que os outros tipos de batata.\n2) Lave bem as batatas em água corrente e, se eles estiverem muito sujas, use uma escovinha para limpá-las.\n3) Descasque as batatas e deixe-as de molho: isso evita que elas escureçam.\n4) Depois, é só cortá-las do jeito que você preferir: em palitos grossos ou finos, em rodelas, chips…\n5) Seque bem as batatas com papel-toalha ou pano de prato limpo: isso vai fazer com que o óleo não espirre em você durante a fritura.\n6) Coloque óleo em uma panela alta e leve ao fogo. Para ver se o óleo está quente o suficiente, coloque um palito de fósforo dentro da panela: quando ele acender, é sinal de que o óleo está bom para ser usado. Retire o palito de fósforo.\n7) Coloque um pouco das batatas no panela e mexa com cuidado para que elas não grudem. Depois, pare de mexer. Quando as batatas estiverem esbranquiçadas, retire-as do óleo e coloque-as numa travessa com papel-toalha. Você pode fazer isso bem antes de as batatas serem servidas.\n8) Um pouco antes da refeição, esquente novamente o óleo e coloque as batatas já pré-fritas. Deixe que fritem até que fiquem douradinhas, retire do óleo e leve para uma travessa forrada com papel-toalha.\n9) Depois, é só colocar sal e servir sua batata frita crocante e sequinha!",
                ImageUrl = "https://img.elo7.com.br/product/original/1DEEFB7/caixinha-embalagem-batata-frita-e-porcoes-peq-preto-500un-embalagem-food-truck.jpg"
            };
            var macarronada = new Receita()
            {
                Id = 2,
                Title = "Macarronada",
                Description = "Perfeito para servir em reuniões da família.",
                Ingredients = "1 pacote de macarrão para macarronada \n1 caixa de extrato de tomate (grande)\n1/2 kg de carne moída\nCebolinha, pimentaõ, cheiro verde, alho, tomate (para temperar carne) knnor\n2 creme de leite\n200 g de queijo mussarela\n100 g de presunto",
                Preparation = "1) Dê preferência à batata asterix, também conhecida como rosada ou portuguesa. Ela tem menos água do que os outros tipos de batata.\n2) Lave bem as batatas em água corrente e, se eles estiverem muito sujas, use uma escovinha para limpá-las.\n3) Descasque as batatas e deixe-as de molho: isso evita que elas escureçam.\n4) Depois, é só cortá-las do jeito que você preferir: em palitos grossos ou finos, em rodelas, chips…\n5) Seque bem as batatas com papel-toalha ou pano de prato limpo: isso vai fazer com que o óleo não espirre em você durante a fritura.\n6) Coloque óleo em uma panela alta e leve ao fogo. Para ver se o óleo está quente o suficiente, coloque um palito de fósforo dentro da panela: quando ele acender, é sinal de que o óleo está bom para ser usado. Retire o palito de fósforo.\n7) Coloque um pouco das batatas no panela e mexa com cuidado para que elas não grudem. Depois, pare de mexer. Quando as batatas estiverem esbranquiçadas, retire-as do óleo e coloque-as numa travessa com papel-toalha. Você pode fazer isso bem antes de as batatas serem servidas.\n8) Um pouco antes da refeição, esquente novamente o óleo e coloque as batatas já pré-fritas. Deixe que fritem até que fiquem douradinhas, retire do óleo e leve para uma travessa forrada com papel-toalha.\n9) Depois, é só colocar sal e servir sua batata frita crocante e sequinha!",
                ImageUrl = "https://images-americanas.b2w.io/produtos/01/00/sku/38259/3/38259310_1GG.jpg"
            };

            var context = CreateTestContext();
            context.AddRange(macarronada, batataFrita);
            await context.SaveChangesAsync();

            var controller = new ReceitasController(context);
            var receitas = controller.Get();

            receitas.Value.Should().HaveCount(2);

            var viewModelEsperado1 = new ReceitaViewModel(){
                Id = macarronada.Id,
                Title = macarronada.Title,
                Description =  macarronada.Description,
                Ingredients = macarronada.Ingredients,
                Preparation =  macarronada.Preparation,
                ImageUrl = macarronada.ImageUrl
            };

            var viewModelEsperado2 = new ReceitaViewModel(){
                Id = batataFrita.Id,
                Title = batataFrita.Title,
                Description =  batataFrita.Description,
                Ingredients = batataFrita.Ingredients,
                Preparation =  batataFrita.Preparation,
                ImageUrl = batataFrita.ImageUrl
            };

            //Asserts
            receitas.Value.Should().BeEquivalentTo(new ReceitaViewModel[]
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
                });
        }
    
    
        [Fact]
        public async void GetOne_DeveResponderComUmaReceitaCadastradaAsync()
        {
            var batataFrita = new Receita()
            {
                Id = 1,
                Title = "Batata frita",
                Description = "Batata frita é aquele acompanhamento do qual todo mundo gosta e também é um aperitivo delicioso.",
                Ingredients = "Batata, óleo e sal a gosto.",
                Preparation = "1) Dê preferência à batata asterix, também conhecida como rosada ou portuguesa. Ela tem menos água do que os outros tipos de batata.\n2) Lave bem as batatas em água corrente e, se eles estiverem muito sujas, use uma escovinha para limpá-las.\n3) Descasque as batatas e deixe-as de molho: isso evita que elas escureçam.\n4) Depois, é só cortá-las do jeito que você preferir: em palitos grossos ou finos, em rodelas, chips…\n5) Seque bem as batatas com papel-toalha ou pano de prato limpo: isso vai fazer com que o óleo não espirre em você durante a fritura.\n6) Coloque óleo em uma panela alta e leve ao fogo. Para ver se o óleo está quente o suficiente, coloque um palito de fósforo dentro da panela: quando ele acender, é sinal de que o óleo está bom para ser usado. Retire o palito de fósforo.\n7) Coloque um pouco das batatas no panela e mexa com cuidado para que elas não grudem. Depois, pare de mexer. Quando as batatas estiverem esbranquiçadas, retire-as do óleo e coloque-as numa travessa com papel-toalha. Você pode fazer isso bem antes de as batatas serem servidas.\n8) Um pouco antes da refeição, esquente novamente o óleo e coloque as batatas já pré-fritas. Deixe que fritem até que fiquem douradinhas, retire do óleo e leve para uma travessa forrada com papel-toalha.\n9) Depois, é só colocar sal e servir sua batata frita crocante e sequinha!",
                ImageUrl = "https://img.elo7.com.br/product/original/1DEEFB7/caixinha-embalagem-batata-frita-e-porcoes-peq-preto-500un-embalagem-food-truck.jpg"
            };

            var context = CreateTestContext();
            context.Add(batataFrita);
            await context.SaveChangesAsync();

            var controller = new ReceitasController(context);
            var receitas = controller.GetOne(batataFrita.Id);

            receitas.Value.Should().NotBeNull();

            var viewModelEsperado1 = new ReceitaViewModel(){
                Id = batataFrita.Id,
                Title = batataFrita.Title,
                Description =  batataFrita.Description,
                Ingredients = batataFrita.Ingredients,
                Preparation =  batataFrita.Preparation,
                ImageUrl = batataFrita.ImageUrl
            };

            //Asserts
            receitas.Value.Should().BeEquivalentTo(new ReceitaViewModel[]
                {
                    new ReceitaViewModel(){
                        Id = 1,
                        Title = "Batata frita",
                        Description =  "Batata frita é aquele acompanhamento do qual todo mundo gosta e também é um aperitivo delicioso.",
                        Ingredients = "Batata, óleo e sal a gosto.",
                        Preparation =  "1) Dê preferência à batata asterix, também conhecida como rosada ou portuguesa. Ela tem menos água do que os outros tipos de batata.\n2) Lave bem as batatas em água corrente e, se eles estiverem muito sujas, use uma escovinha para limpá-las.\n3) Descasque as batatas e deixe-as de molho: isso evita que elas escureçam.\n4) Depois, é só cortá-las do jeito que você preferir: em palitos grossos ou finos, em rodelas, chips…\n5) Seque bem as batatas com papel-toalha ou pano de prato limpo: isso vai fazer com que o óleo não espirre em você durante a fritura.\n6) Coloque óleo em uma panela alta e leve ao fogo. Para ver se o óleo está quente o suficiente, coloque um palito de fósforo dentro da panela: quando ele acender, é sinal de que o óleo está bom para ser usado. Retire o palito de fósforo.\n7) Coloque um pouco das batatas no panela e mexa com cuidado para que elas não grudem. Depois, pare de mexer. Quando as batatas estiverem esbranquiçadas, retire-as do óleo e coloque-as numa travessa com papel-toalha. Você pode fazer isso bem antes de as batatas serem servidas.\n8) Um pouco antes da refeição, esquente novamente o óleo e coloque as batatas já pré-fritas. Deixe que fritem até que fiquem douradinhas, retire do óleo e leve para uma travessa forrada com papel-toalha.\n9) Depois, é só colocar sal e servir sua batata frita crocante e sequinha!",
                        ImageUrl = "https://img.elo7.com.br/product/original/1DEEFB7/caixinha-embalagem-batata-frita-e-porcoes-peq-preto-500un-embalagem-food-truck.jpg"
                    }
                });
        }

        [Fact]
        public void GetOne_DeveResponderComUmaReceitaNula()
        {
            var context = CreateTestContext();

            var controller = new ReceitasController(context);
            var receitas = controller.GetOne(46);

            receitas.Value.Should().BeNull();
        }

        [Fact]
        public void Insert_DeveInserirAReceitaSolicitada()
        {
            var receitaViewModel = new ReceitaViewModel(1, "Coxinha", "è baita", "entra dinheiro no caixa", "folder", "");
            var context = CreateTestContext();
            var controller = new ReceitasController(context);

            var result = controller.Insert(receitaViewModel);
            var receitaDoBanco = context.Receitas.FirstOrDefault(receita => receita.Title == receitaViewModel.Title);

            result.Value.Should().BeEquivalentTo(receitaViewModel);
            receitaDoBanco.Should().NotBeNull("Por que ela deve ser existente no banco de dados.");
        }

        [Fact]
        public void Insert_DeveLancarUmaException()
        {
            var receitaViewModel = new ReceitaViewModel(1, "Coxinha asdasdasdasdsadsadasdsa5559598", "è baita", "entra dinheiro no caixa", "folder", "");
            var context = CreateTestContext();
            var controller = new ReceitasController(context);

            Action act = () => controller.Insert(receitaViewModel);
            act.Should().Throw<Exception>()
                .WithMessage("Passa o título direito mano.");
        }

        [Fact]
        public void Update_DentroDasRegras()
        {
            var batataFrita = new Receita()
            {
                Id = 1,
                Title = "Batata frita",
                Description = "Batata frita é aquele acompanhamento do qual todo mundo gosta e também é um aperitivo delicioso.",
                Ingredients = "Batata, óleo e sal a gosto.",
                Preparation = "1) Dê preferência à batata asterix, também conhecida como rosada ou portuguesa. Ela tem menos água do que os outros tipos de batata.\n2) Lave bem as batatas em água corrente e, se eles estiverem muito sujas, use uma escovinha para limpá-las.\n3) Descasque as batatas e deixe-as de molho: isso evita que elas escureçam.\n4) Depois, é só cortá-las do jeito que você preferir: em palitos grossos ou finos, em rodelas, chips…\n5) Seque bem as batatas com papel-toalha ou pano de prato limpo: isso vai fazer com que o óleo não espirre em você durante a fritura.\n6) Coloque óleo em uma panela alta e leve ao fogo. Para ver se o óleo está quente o suficiente, coloque um palito de fósforo dentro da panela: quando ele acender, é sinal de que o óleo está bom para ser usado. Retire o palito de fósforo.\n7) Coloque um pouco das batatas no panela e mexa com cuidado para que elas não grudem. Depois, pare de mexer. Quando as batatas estiverem esbranquiçadas, retire-as do óleo e coloque-as numa travessa com papel-toalha. Você pode fazer isso bem antes de as batatas serem servidas.\n8) Um pouco antes da refeição, esquente novamente o óleo e coloque as batatas já pré-fritas. Deixe que fritem até que fiquem douradinhas, retire do óleo e leve para uma travessa forrada com papel-toalha.\n9) Depois, é só colocar sal e servir sua batata frita crocante e sequinha!",
                ImageUrl = "https://img.elo7.com.br/product/original/1DEEFB7/caixinha-embalagem-batata-frita-e-porcoes-peq-preto-500un-embalagem-food-truck.jpg"
            };
            
            
            var context = CreateTestContext();
            context.Add(batataFrita);
            context.SaveChanges();
            var controller = new ReceitasController(context);
            var viewModel = new ReceitaViewModel(batataFrita.Id, "TESTE", batataFrita.Description, batataFrita.Ingredients, batataFrita.Preparation, batataFrita.ImageUrl);

            var receitaAtualizada = controller.Update(1, viewModel);
            
            receitaAtualizada.Value.Title.Should().Be("TESTE");
        }

        [Fact]
        public void Update_ComFalha()
        {
            var batataFrita = new Receita()
            {
                Id = 1,
                Title = "Batata frita",
                Description = "Batata frita é aquele acompanhamento do qual todo mundo gosta e também é um aperitivo delicioso.",
                Ingredients = "Batata, óleo e sal a gosto.",
                Preparation = "1) Dê preferência à batata asterix, também conhecida como rosada ou portuguesa. Ela tem menos água do que os outros tipos de batata.\n2) Lave bem as batatas em água corrente e, se eles estiverem muito sujas, use uma escovinha para limpá-las.\n3) Descasque as batatas e deixe-as de molho: isso evita que elas escureçam.\n4) Depois, é só cortá-las do jeito que você preferir: em palitos grossos ou finos, em rodelas, chips…\n5) Seque bem as batatas com papel-toalha ou pano de prato limpo: isso vai fazer com que o óleo não espirre em você durante a fritura.\n6) Coloque óleo em uma panela alta e leve ao fogo. Para ver se o óleo está quente o suficiente, coloque um palito de fósforo dentro da panela: quando ele acender, é sinal de que o óleo está bom para ser usado. Retire o palito de fósforo.\n7) Coloque um pouco das batatas no panela e mexa com cuidado para que elas não grudem. Depois, pare de mexer. Quando as batatas estiverem esbranquiçadas, retire-as do óleo e coloque-as numa travessa com papel-toalha. Você pode fazer isso bem antes de as batatas serem servidas.\n8) Um pouco antes da refeição, esquente novamente o óleo e coloque as batatas já pré-fritas. Deixe que fritem até que fiquem douradinhas, retire do óleo e leve para uma travessa forrada com papel-toalha.\n9) Depois, é só colocar sal e servir sua batata frita crocante e sequinha!",
                ImageUrl = "https://img.elo7.com.br/product/original/1DEEFB7/caixinha-embalagem-batata-frita-e-porcoes-peq-preto-500un-embalagem-food-truck.jpg"
            };
            
            var context = CreateTestContext();
            context.Add(batataFrita);
            context.SaveChanges();

            var controller = new ReceitasController(context);
            var viewModel = new ReceitaViewModel(batataFrita.Id, "TESTETESTETESTETESTE", batataFrita.Description, batataFrita.Ingredients, batataFrita.Preparation, batataFrita.ImageUrl);

            Action act = () => controller.Update(1, viewModel);
            act.Should().Throw<Exception>()
                .WithMessage("Passa o título direito mano.");

        }
    }
}

