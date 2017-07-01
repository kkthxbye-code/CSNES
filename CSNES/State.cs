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

        public byte ReadByte(ushort addr, AddressingMode addressingMode)
        {
            if (addressingMode == AddressingMode.Immediate)
            {
                return cart.getMapper().ReadByte(ppu.PC);
            } else
            {
                Console.WriteLine("Unimplemented ReadByte Addressing Mode: {0}", addressingMode);
                return 0;
            }
        }

        public void WriteByte(ushort addr, byte value, AddressingMode addressingMode)
        {
            if (addressingMode == AddressingMode.Absolute)
            {
                memory.WriteByte(addr, value);
            }
            else
            {
                Console.WriteLine("Unimplemented WriteByte Addressing Mode: {0}", addressingMode);
            }
        }
    }
}
