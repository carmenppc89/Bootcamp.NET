using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebApp_MVC_Animales.Models;

namespace WebApp_MVC_Animales.DAL
{
    public class AnimalDAL
    {
        private AnimalsContext _AnimalDataContext;
        public AnimalDAL()
        {
            _AnimalDataContext = new AnimalsContext();
        }

        public List<Animal> GetAll()
        {
            using (_AnimalDataContext)
            {
                IQueryable<Animal> AnimalsLinq = from Animal in _AnimalDataContext.Animals
                                                 select Animal;

                return AnimalsLinq.ToList();
            }
        }

        public Animal GetById(int id)
        {
            using (_AnimalDataContext)
            {
                Animal? selected = (from Animal in _AnimalDataContext.Animals
                                    where Animal.IdAnimal == id
                                    select Animal).Include(t => t.RidTipoAnimalNavigation).FirstOrDefault();

                return selected;
            }
        }

        public void SetTypeObj(Animal animal)
        {
            TipoAnimalDAL tipoAnimalDAL = new TipoAnimalDAL();
            animal.RidTipoAnimalNavigation = tipoAnimalDAL.GetById(animal.RidTipoAnimal);
        }

        public Animal UpdateByAnimal(Animal animalToUpdate)
        {
            Animal? oldAnimal = null;
            try
            {
                oldAnimal = _AnimalDataContext.Animals.Where(a => a.IdAnimal == animalToUpdate.IdAnimal).FirstOrDefault();
                if (oldAnimal != null)
                {
                    _AnimalDataContext.Entry(oldAnimal).CurrentValues.SetValues(animalToUpdate);
                }

                _AnimalDataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!  UPDATE ANIMAL ->" + ex.ToString());
            }

            return oldAnimal;

        }
    }
}
