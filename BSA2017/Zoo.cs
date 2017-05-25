using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace BSA2017
{
    class Zoo:IInteractiv
    {
        List<Animal> zoo = new List<Animal>();
        public void InterfaceMethod(char simbol)
        {
            string types;
            string names;
            switch (simbol)
            {
                case 'a':
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Write type and name for animal");
                    Console.WriteLine("--------------------");
                    types = Console.ReadLine();
                    names = Console.ReadLine();
                   Add(names, types);
                    break;
                case 'c':
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Write name for animal");
                    Console.WriteLine("--------------------");

                    names = Console.ReadLine();
                    Cure(names);
                    break;
                case 'f':
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Write name for animal");
                    Console.WriteLine("--------------------");

                    names = Console.ReadLine();
                    Feed(names);
                    break;
                case 'r':
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Write name for animal");
                    Console.WriteLine("--------------------");

                    names = Console.ReadLine();
                   Remove(names);
                    break;
                case 'i':

                    IntroduceAll();
                    break;
              
                default:
                    Console.WriteLine("Wrong type!!!");
                    break;


            }
        }

       // Method for adding
        public void Add(string name,string type)
        {
            switch (type)
            {
                case "Lion":
                    zoo.Add(new Lion(name));
                    Console.WriteLine("Added animal {0} with name {1}", type, name);
                    break;
                case "Elephant":
                    zoo.Add(new Elephant(name));
                    Console.WriteLine("Added animal {0} with name {1}", type, name);
                    break;
                case "Wolf":
                    zoo.Add(new Wolf(name));
                    Console.WriteLine("Added animal {0} with name {1}", type, name);
                    break;
                case "Fox":
                    zoo.Add(new Fox(name));
                    Console.WriteLine("Added animal {0} with name {1}", type, name);
                    break;
                case "Tiger":
                    zoo.Add(new Tiger(name));
                    Console.WriteLine("Added animal {0} with name {1}", type, name);
                    break;
                case "Bear":
                    zoo.Add(new Bear(name));
                    Console.WriteLine("Added animal {0} with name {1}", type, name);
                    break;
                default:
                    Console.WriteLine("Error:No one added(Wrong type {0})!!!",type);
                    break;
                    IntroduceAll();
            }
        }

        //Method for feeding
        public void Feed(string name)
        {
            try
            {
               var myAnimal = zoo.Find(st => st.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (myAnimal.Status == Status.Hungry||myAnimal.Status==Status.Full)
                {
                    myAnimal.Status = Status.Full;
                    Console.WriteLine(" The {0} is fed", myAnimal.Name);
                }
                else
                {
                    Console.WriteLine("Need to cure the animal {0}", myAnimal.Name);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Sorry, no Animal with this name '{0}'",name);
            }
            
        }
     
     // Method for removing
        public void Remove(string name)
        {
            try
            {
                var myAnimal = zoo.Find(st => st.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (myAnimal.Status == Status.Dead)
                {
                    zoo.Remove(myAnimal);
                }
                else
                    Console.WriteLine("This animal is good");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Sorry, no Animal with this name '{0}'", name);
            }
           
        }

        //Method for treatment
        public void Cure(string name)
        {
            try
            {
                var myAnimal = zoo.Find(st => st.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                myAnimal.CurrentHealth = myAnimal.CurrentHealth+1;
                if (myAnimal.CurrentHealth == myAnimal.MaxHealth)
                {
                    myAnimal.Status = Status.Hungry;
                }
                Console.WriteLine("The {0} is cured fo 1 point and have {1} health", myAnimal.Name,myAnimal.CurrentHealth);
                }
           
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, no Animal with this name '{0}'", name);
            }
        }
        public void IntroduceAll()
        {
            foreach (Animal pet in zoo)
            {
                pet.Introduce();
            }
        }
        //Returns the collection

        public bool ListCount()
        {
            //Console.WriteLine(zoo.Count);
            if (zoo.Count == 0)
            {
                //Console.WriteLine(zoo.Count);
                return true;
            }
            else
                return false;
        }

        //Selects a random object and if the object is dead it deletes it
        public  void TakeRandomAnimal(Object source, ElapsedEventArgs e)
        {
            if (zoo.Count != 0)
            {
                Random random = new Random();
                var element = zoo.ElementAt(random.Next(zoo.Count()));
                element.Status = element.Status;
                if(element.Status==Status.Dead)
                {
                    Remove(element.Name);
                }
                if (element.CurrentHealth != 0)
                {
                    Console.WriteLine("\t{0}: I {1} and i have {2} health", element.Name, element.Status, element.CurrentHealth);
                }
                else
                if (element.Status == Status.Dead && element.CurrentHealth == 0) 
                {
                    Console.WriteLine("\t{0}:Bye i`m dead",element.Name);
                }
            }
           
        }
       



    }
    
}
