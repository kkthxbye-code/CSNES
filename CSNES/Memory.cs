using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNES
{
    public class Memory
    {
        public byte[] memory;
        public State state;


        public Memory(int size, State state)
        {
            this.memory = new byte[size];
            this.state = state;
        }

        public byte ReadByte(ushort addr)
        {
            if(addr < 0x2000)
            {
                return memory[addr & 0x7FF];
            }

            return 0;
        }

        public void WriteByte(ushort addr, byte value)
        {
            if(addr < 0x2000)
            {
                memory[addr & 0x7FF] = value;
            }

        }

        public ushort ReadWord()
        {
            return 0;
        }

        public void WriteWord()
        {

        }
    }
}
