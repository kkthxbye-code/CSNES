using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNES
{
    public class State
    {
        public Memory memory;
        public CPU ppu;
        public Cart cart;

        public int cycleCount;

        public State(string romPath)
        {
            memory = new Memory(0x800, this);
            ppu = new CPU(this);
            cart = new Cart(romPath);
            cycleCount = 0;

        }
    }
}
