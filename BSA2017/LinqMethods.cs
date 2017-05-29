using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2017
{
    class LinqMethods
    {
        int temp;
        //        Показать всех животных, сгруппированных по виду животного
        public void OrderAllAnimals(List<Animal> animal)
        {
            var result = from a in animal
                         orderby a.GetType().Name
                         select a;
            foreach (var i in result)
            {
                Console.WriteLine("Animal {0} {1}",i.GetType().Name,i.Name);
            }

        }
        //Показать животных по состоянию - в параметрах передать Состояние
        public void AllByStatus(List<Animal> animal,Status st)
        {
            var result = from a in animal
                         where a.Status==st
                         select a;
            foreach (var i in result)
            {
                Console.WriteLine("Animals by {0} is {1}",st,i.Name);
            }

        }
                //Показать самых здоровых животных каждого вида(по одному на каждый вид)
        public void SortByHealth(List<Animal> animal)
        {
            
            var result = from a in animal
                                  group a by a.GetType() into g
                                  select g;


            foreach (var i in result)
            {
                var animalWithMaxHelth = i.Where(a => a.CurrentHealth == i.Max(a1 => a1.CurrentHealth)).First();
                Console.WriteLine("Animal of type: {0}; Name: {1}; Helth: {2};", i.Key.Name, animalWithMaxHelth.Name, animalWithMaxHelth.CurrentHealth);
            }
        }
        //Показать количество мертвых животных каждого вида
        public void DeathCount(List<Animal> animal)
        {
            var result = from a in animal
                                  group a by a.GetType() into g
                                  select g;

            foreach (var i in result)
            {
                Console.WriteLine("Type: {0}; Count Of Death: {1}", i.Key.Name, i.Count(a => a.Status == Status.Dead));
            }
        }
                //Показать средней количество здоровья у животных в зоопарке
        public void MiddleHealth(List<Animal> animal)
        {
          
            var result = from a in animal
                        
                         select a;
            foreach (var i in result)
            {
                temp += i.CurrentHealth;
               
            }
            Console.WriteLine("Avarage healtj of animals is-{0}",temp/result.Count());

        }
                //Показать животное с максимальным здоровьем и животное с минимальным здоровьем(описать одним выражением)
        public void MaxAndMin(List<Animal> animal)
        {
            var result = from a in animal
                         where a.MaxHealth==int.MaxValue ||a.MaxHealth==int.MinValue
                         select a;
            foreach (var i in result)
            {
                Console.WriteLine("Resault {0}",i.GetType().Name);
            }

        }
        //Показать всех волков и медведей, у которых здоровье выше 3
        public void BearsAndWolfs(List<Animal> animal)
        {
            var result = from a in animal
                         where (a.GetType().Name=="Bear"|| a.GetType().Name=="Wolf")&&a.CurrentHealth>3
                         select a;
            foreach (var i in result)
            {
                Console.WriteLine("{0} with health {1}",i.GetType(),i.CurrentHealth);
            }

        }
        //Показать список всех кличек животных, которые голодны
        public void AllHungry(List<Animal> animal)
        {
            var result = from a in animal
                         where a.Status==Status.Hungry
                         select a;
            foreach (var i in result)
            {
                Console.WriteLine("I {0} and i hungry",i.Name);
            }

        }
        //Показать слона с определенной кличкой, которая задается в параметре
        public void ElephantName(List<Animal> animal,string name)
        {
            
             
                var result = from a in animal
                             where a.Name == name && a.GetType().Name=="Elephant"
                             select a;
                foreach (var i in result)
                {
                    Console.WriteLine("Elephant with name {0} have {1} health and Status {2}",name,i.CurrentHealth,i.Status);
                }
        
           

        }
        //Показать всех тигров, которые больны
        public void SickTigers(List<Animal> animal)
        {
            
           
           
            var result = from a in animal
                         where a.Status == Status.Sick && a.GetType().Name=="Tiger"
                         select a;
            foreach (var i in result)
            {
                Console.WriteLine("I {0} {1} and i Sick",i.GetType().Name,i.Name);
            }
                
        }
    }
}
