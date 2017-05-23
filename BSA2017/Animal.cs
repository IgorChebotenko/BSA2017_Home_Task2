using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2017
{
   abstract class Animal
    {
        enum Statuses { Full=1, Hungry, Sick , Dead}
        private string status;
        public string Status { get { return status; }
            set {if(currentHealth==maxHealth)
                {
                    status = ((Statuses)1).ToString();
                }
            else if (currentHealth<maxHealth&&currentHealth>1)
                {
                    status = ((Statuses)2).ToString();
                }
            else if (currentHealth==1)
                {
                    status = ((Statuses)3).ToString();
                }
            else
                {
                    status = ((Statuses)4).ToString();
                }

                    } }
        private string name;
        public string Name { get { return name; } set { name = value; } }
        protected int currentHealth;
        public int CurrentHealth
        {
            get { return currentHealth; }
            set { if(value>maxHealth)
                {
                    currentHealth = maxHealth;
                }else
                {
                    currentHealth = value;
                }
            }
        }
        protected int maxHealth;
        public int MaxHealth
        {
            get { return maxHealth; }
        }
        public Animal(string name)
        {
            status = ((Statuses)1).ToString();
            Name = name;
        }
        public void Introduce()
        {
            Console.WriteLine("I'm {0} of {1}", name,currentHealth);
        }
    }
    sealed class Lion:Animal
    {
        
       public Lion(string name):base(name)
        {
            maxHealth = 5;
            currentHealth = maxHealth;
        }
        
    }
    sealed class Tiger:Animal
    {
        public Tiger(string name):base(name)
        {
            maxHealth = 5;
            currentHealth = maxHealth;
        }
    }
    sealed class Wolf:Animal
    {
        public Wolf(string name):base(name)
        {
            maxHealth = 5;
            currentHealth = maxHealth;
        }
    }
    sealed class Fox:Animal
    {
        public Fox(string name):base(name)
        {
            maxHealth = 5;
            currentHealth = maxHealth;
        }
    }
    sealed class Bear:Animal
    {
        public Bear(string name):base(name)
        {
            maxHealth = 5;
            currentHealth = maxHealth;
        }
    }
    sealed class Elephant:Animal
    {
        public Elephant(string name):base(name)
        {
            maxHealth = 5;
            currentHealth = maxHealth;
        }
    }
}
