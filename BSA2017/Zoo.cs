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
            Status st;
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
                case 'l':
                    char newAnser;
                    LinqMethods linqMethods = new LinqMethods();
                    Console.WriteLine("What you want to call?");
                   
                    Console.WriteLine("Show all animals grouped by animal type(1)");
                    Console.WriteLine("Show animals by status(2)");
                    Console.WriteLine("Show all tigers who are sick(3)");
                    Console.WriteLine("Show an elephant with a specific name, which is specified in the parameter(4)");
                    Console.WriteLine("Show a list of all animal names that are hungry(5)");
                  
                    Console.WriteLine("Show the healthiest animals of each species(6)");
                    Console.WriteLine("Show the number of dead animals of each species(7)");
                    Console.WriteLine("Show all wolves and bears who have health above 3(8)");
                    Console.WriteLine("Show the animal with maximum health and the animal with minimal health (9)");
                    Console.WriteLine("Show the average health of animals in the zoo(0)");
                    newAnser = char.Parse(Console.ReadLine());
                    switch (newAnser)
                    {
                        
                        case '1':
                            linqMethods.OrderAllAnimals(zoo);
                            break;
                        case '2':
                            Console.WriteLine("Select status:Full(f),Sick(s),Hungry(h),Dead(d)");
                            newAnser = char.Parse(Console.ReadLine());
                           
                            switch(newAnser)
                            {
                                case 'f':
                                    st = Status.Full;
                                    linqMethods.AllByStatus(zoo, st);
                                    break;
                                case 'h':
                                    st = Status.Hungry;
                                    linqMethods.AllByStatus(zoo, st);
                                    break;
                                case 's':
                                    st = Status.Sick;
                                    linqMethods.AllByStatus(zoo, st);
                                    break;
                                case 'd':
                                    st = Status.Dead;
                                    linqMethods.AllByStatus(zoo, st);
                                    break;
                            }
                            
                            break;
                        case '3':
                            linqMethods.SickTigers(zoo);
                            break;

                        case '4':
                            try
                            {
                                string param = Console.ReadLine();
                                linqMethods.ElephantName(zoo,param);
                            }
                           catch(Exception ex)
                            {
                                Console.WriteLine("Wrong name!");
                            }
                            break;
                        case '5':
                            linqMethods.AllHungry(zoo);
                            break;

                        case '6':
                            linqMethods.SortByHealth(zoo);
                            break;
                        case '7':
                            linqMethods.DeathCount(zoo);
                            break;
                            
                        case '8':
                            linqMethods.BearsAndWolfs(zoo);
                            break;
                        case '9':
                            linqMethods.MaxAndMin(zoo);
                            break;
                        case 'a':
                            linqMethods.MiddleHealth(zoo); ;
                            break;
                        default:
                            Console.WriteLine("Wrong answer!!!");
                            break;


                    }
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
            var  testforend = from z in zoo
                             where z.Status != Status.Dead
                             select z;
            //Console.WriteLine(zoo.Count);
            if (testforend.Count()==0)
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
                //var element = zoo.ElementAt(random.Next(zoo.Count()));

                var element2=
                    from z in zoo
                    where z.Status != Status.Dead 
                    select z;
               var element = element2.ElementAt(random.Next(element2.Count()));

                element.Status = element.Status;

                //if(element.Status==Status.Dead)
                //{
                //    Remove(element.Name);
                //}
                if (element.CurrentHealth != 0)
                {
                    Console.WriteLine("\t{0}: I {1} and i have {2} health", element.Name, element.Status, element.CurrentHealth);
                }
                else
                if (element.Status == Status.Dead && element.CurrentHealth == 0)
                {
                    Console.WriteLine("\t{0}:Bye i`m dead", element.Name);
                }
            }
           
        }
       



    }
    
}
