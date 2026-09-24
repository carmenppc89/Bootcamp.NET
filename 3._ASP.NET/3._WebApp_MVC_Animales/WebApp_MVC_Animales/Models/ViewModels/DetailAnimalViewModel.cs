namespace WebApp_MVC_Animales.Models.ViewModels
{
    public class DetailAnimalViewModel
    {
        public Animal AnimalDetail { get; set; } = new Animal();
        public List<TipoAnimal> TipoAnimales { get; set; } = new List<TipoAnimal>();
    }
}
