using WebApp_MVC_Animales.Models;

namespace WebApp_MVC_Animales.DAL
{
    public class TipoAnimalDAL
    {
        private AnimalsContext _AnimalDataContext;
        public TipoAnimalDAL()
        {
            _AnimalDataContext = new AnimalsContext();
        }

        public List<TipoAnimal> GetAll()
        {
            using (_AnimalDataContext)
            {
                IQueryable<TipoAnimal> TipoAnimalsLinq = from Tipo in _AnimalDataContext.TipoAnimals
                                                         select Tipo;

                return TipoAnimalsLinq.ToList();
            }
        }

        public TipoAnimal GetById(int id)
        {
            using (_AnimalDataContext)
            {
                TipoAnimal? ty = (from Tipo in _AnimalDataContext.TipoAnimals
                                  where Tipo.IdTipoAnimal == id
                                  select Tipo).FirstOrDefault();

                return ty;
            }
        }
    }
}
