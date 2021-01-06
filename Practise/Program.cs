using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Practise
{
    public class Program
    {
        static void Main(string[] args)
        {
            var f = new List<bool>();
            Toy.OrderBy(o => o, f).ThenBy(t=>t);
        }
    }
}
