using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Threading;
using System.Timers;

namespace BSA2017
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        private static void SetTimer(Zoo onj)
        {

            //Set the time to the timer
            aTimer = new System.Timers.Timer(10000);

           // Adding a method
            aTimer.Elapsed +=onj.TakeRandomAnimal;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        static void Main(string[] args)
        {
            
           // Creating an object
                        Zoo myZoo = new Zoo();

            //TimerCallback myCallTimer = new TimerCallback(myZoo.TakeRandomAnimal);
            //Timer myTimer = new Timer(myCallTimer, 0, 0, 5000);


            //Start timer
            SetTimer(myZoo);
           
            char answer;
            char anserForRepeat;
            Console.WriteLine("BINARY STUDIO ACADEMY 2017 - HOME TASK 2");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Welcome to my zoo");
            Console.WriteLine("You can add new animal like:Lion, Wolf, Fox, Tiger, Bear and Elephant");
            Console.WriteLine("What you want to do?");
            Console.WriteLine("-----------------------------------------");
            do
            {

                Console.WriteLine("Add animal?(a)");
                Console.WriteLine("Feed animal?(f)");
                Console.WriteLine("Cure animal(c)");
                Console.WriteLine("Remove animal?(r)");
                Console.WriteLine("Show all?(i)");
                Console.WriteLine("Call linq methods(l)");
                Console.WriteLine("-----------------------------------------");

                try
                {
                    Console.WriteLine("Your answer:{0}",answer = char.Parse(Console.ReadLine()));
                    myZoo.InterfaceMethod(answer);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Sorry wrong command");
                    Console.WriteLine("-----------------------------------------");
                }
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Repeat?(y/n)");
                Console.WriteLine("-----------------------------------------");
                try
                    {


                        anserForRepeat = char.Parse(Console.ReadLine());
                    }
                    catch(Exception ex)
                    {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Wrong format!!!");
                    Console.WriteLine("-----------------------------------------");
                    anserForRepeat = ' ';
                    }
                
            } while (anserForRepeat =='y');
            //Show
            myZoo.IntroduceAll();
            do

                //When the collection is empty, the timer stops
            { if (myZoo.ListCount() == true)
                    aTimer.Stop();
            }
            while (myZoo.ListCount()!=true);

        }
    }
}
