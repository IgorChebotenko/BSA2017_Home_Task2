using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2017
{
   abstract class Animal
    {
        private Status status;

      
        public Status Status
        {
            get { return status; }
            set
            {
                status = value;
                if(status==Status.Full)
                {
                   status=Status.Hungry;
                }
                else if(status==Status.Hungry)
                    {
                    status = Status.Sick;
                    --currentHealth;
                }
                else if (status == Status.Sick)
                {
                    if (currentHealth > 0)
                    {
                        --currentHealth;
                    }
                    else
                    {
                        status = Status.Dead;

                    }
                }
                //    if (currentHealth==maxHealth)
                //    {
                //        status = ((Statuses)1).ToString();
                //    }
                //else if (currentHealth<maxHealth&&currentHealth>1)
                //    {
                //        status = ((Statuses)2).ToString();
                //    }
                //else if (currentHealth==1)
                //    {
                //        status = ((Statuses)3).ToString();
                //    }
                //else
                //    {
                //        status = ((Statuses)4).ToString();
                //    }

                //        }
            }
        }
        private string name;
        public string Name
        { get
            { return name; }
            set
            { name = value; }
        }
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
        public void SetStatus(Status status)
        {
            this.status = status;
        }

        public int MaxHealth
        {
            get { return maxHealth; }
        }
        public Animal(string name)
        {
            this.status = Status.Full;
            Name = name;
        }
        public void Introduce()
        {
            Console.WriteLine("My name is {0} ,i am a {1} and i {2} , my health is {3}", name,GetType().Name,status,currentHealth);
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
            maxHealth = 4;
            currentHealth = maxHealth;
        }
    }
    sealed class Wolf:Animal
    {
        public Wolf(string name):base(name)
        {
            maxHealth =4 ;
            currentHealth = maxHealth;
        }
    }
    sealed class Fox:Animal
    {
        public Fox(string name):base(name)
        {
            maxHealth = 3;
            currentHealth = maxHealth;
        }
    }
    sealed class Bear:Animal
    {
        public Bear(string name):base(name)
        {
            maxHealth = 6;
            currentHealth = maxHealth;
        }
    }
    sealed class Elephant:Animal
    {
        public Elephant(string name):base(name)
        {
            maxHealth = 7;
            currentHealth = maxHealth;
        }
    }
}
