namespace CursoNetCoreQualyteam.Dominio
{
    public class Receita
    {
        public const int LimiteDeCaracteresDoTitulo = 10;
        public Receita(){}
        public Receita(string title, string description, string ingredients, string preparation, string imageUrl)
        {
            if(!CaracteresDoTituloEhValido(title)){
                throw new System.Exception("Passa o título direito mano.");
            }

            Title = title;
            Description = description;
            Ingredients = ingredients;
            Preparation = preparation;
            ImageUrl = imageUrl;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Preparation { get; set; }
        public string ImageUrl { get; set; }

        public bool CaracteresDoTituloEhValido(string titulo){
            return titulo.Length >= 0 && titulo.Length <= LimiteDeCaracteresDoTitulo;
        }

        public void Update(string title, string description){
            if(!CaracteresDoTituloEhValido(title)){
                throw new System.Exception("Passa o título direito mano.");
            }

            Title = title;
            Description = description;
        }
    }
}
