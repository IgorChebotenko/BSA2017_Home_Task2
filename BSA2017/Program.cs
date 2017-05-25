using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BSA2017
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Zoo myZoo = new Zoo();
            myZoo.Add("lion", "Lion");
            myZoo.Add("wolf", "Wolf");
            myZoo.Add("tiger", "Tiger");
            myZoo.Add("aaa", "Wolf");
            TimerCallback myCallTimer = new TimerCallback(myZoo.TakeRandomAnimal);
            Timer myTimer = new Timer(myCallTimer, 0, 0, 5000);

            string types;
            string names;
            char answer;
            char anserForRepeat;
            Console.WriteLine("--------------------");
            Console.WriteLine("Welcome to my zoo");
            Console.WriteLine("What you want to to?");

            do
            {

                Console.WriteLine("Add animal?(a)");
                Console.WriteLine("Feed animal?(f)");
                Console.WriteLine("Cure animal(c)");
                Console.WriteLine("Remove animal?(r)");
                answer = char.Parse(Console.ReadLine());
                try
                {
                    switch (answer)
                    {
                        case 'a':
                            Console.WriteLine("write type an name for animal");
                            types = Console.ReadLine();
                            names = Console.ReadLine();
                            myZoo.Add(names, types);
                            break;
                        case 'c':
                            Console.WriteLine("write name for animal");

                            names = Console.ReadLine();
                            myZoo.Cure(names);
                            break;
                        case 'f':
                            Console.WriteLine("write name for animal");

                            names = Console.ReadLine();
                            myZoo.Feed(names);
                            break;
                        case 'r':
                            Console.WriteLine("write name for animal");

                            names = Console.ReadLine();
                            myZoo.Remove(names);
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Sorry wrong comand");
                }
                do
                {
                    Console.WriteLine("repeat?(y/n)");

                    anserForRepeat = char.Parse(Console.ReadLine());


                }
                    } while (anserForRepeat ==;
            } while (anserForRepeat =='y');
            myZoo.IntroduceAll();

        }
    }
}
