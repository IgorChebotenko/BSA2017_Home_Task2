using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2017
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo myZoo = new Zoo();
            string types;
            string names;
            char answer;
            char anserForRepeat;
            Console.WriteLine("--------------------");
            Console.WriteLine("What you want to to?");
            Console.WriteLine("Add animal?(a)");
            Console.WriteLine("Cure animal(c)");
            do
            {
                answer = char.Parse(Console.ReadLine());
                switch (answer)
                {
                    case 'a':
                        Console.WriteLine("write type an name for animal");
                        types = Console.ReadLine();
                        names = Console.ReadLine();
                        myZoo.Add(names, types);
                        break;
                    case 'c':
                        Console.WriteLine("write type an name for animal");
                        types = Console.ReadLine();
                        names = Console.ReadLine();
                        myZoo.Add(names, types);
                        break;
                }
                Console.WriteLine("repeat?(y/n)");
                anserForRepeat = char.Parse(Console.ReadLine());
            } while (anserForRepeat =='y');
            myZoo.IntroduceAll();

        }
    }
}
