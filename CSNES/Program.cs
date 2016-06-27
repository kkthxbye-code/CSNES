using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNES
{
    class Program
    {
        static void Main(string[] args)
        {
            State state = new State(@"C:/Super Mario Bros.nes");

            while(true)
            {
                state.ppu.Tick();
            }
            Console.ReadLine();
        }
    }
}
