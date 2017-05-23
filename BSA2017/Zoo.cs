using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2017
{
    class Zoo:IInteractiv
    {
        List<Animal> zoo = new List<Animal>();
        public void Add(string name,string type)
        {
            switch (type)
            {
                case "Lion":
                    zoo.Add(new Lion(name));
                    break;
                case "Elephant":
                    zoo.Add(new Elephant(name));
                    break;
                case "Wolf":
                    zoo.Add(new Wolf(name));
                    break;
                case "Fox":
                    zoo.Add(new Fox(name));
                    break;
                case "Tiger":
                    zoo.Add(new Tiger(name));
                    break;
                case "Bear":
                    zoo.Add(new Bear(name));
                    break;
                default:
                    Console.WriteLine("Error:No one added");
                    break;

            }
        }
        public void Feed(string name)
        {
            var myAnimal=zoo.Find(st=>st.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            myAnimal.CurrentHealth = ++myAnimal.CurrentHealth;
            
        }
        public void Remove(string name)
        {
            //var myAnimal = zoo.Find(st => st.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            //if(myAnimal.Status=="Dead")
            //    zoo.Remove(st=> st.Status)
        }
        public void Cure(string name)
        {
            var myAnimal = zoo.Find(st => st.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            myAnimal.CurrentHealth = myAnimal.MaxHealth;
        }
        public void IntroduceAll()
        {
            foreach (Animal pet in zoo)
            {
                pet.Introduce();
            }
        }
    }
}
