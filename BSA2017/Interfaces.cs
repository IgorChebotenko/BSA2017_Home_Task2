using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2017
{
    interface IInteractiv
    {
        void Add(string name, string type);
        void Feed(string name);
        void Cure(string name);
        void Remove(string name);
    }
   
}
