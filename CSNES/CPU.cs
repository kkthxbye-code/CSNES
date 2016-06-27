using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNES
{
    public class CPU
    {
        public byte A;
        public byte X;
        public byte Y;
        public ushort PC;
        public byte P;

        public State state;
        public Dictionary<byte, Action> instructions;

        public CPU(State state)
        {
            this.state = state;
            instructions = new Dictionary<byte, Action>()
            {
                { 0x78, sei },
                { 0xD8, cld }
            };
        }

        public void Tick()
        {
            byte instruction = state.cart.PRGData[state.ppu.PC];
            state.ppu.PC++;

            try
            {
                instructions[instruction]();
            } catch(KeyNotFoundException)
            {
                Console.WriteLine("Instruction not implemented: 0x{0:X}", instruction);
                Console.ReadLine();
            }
        }

        public void SetFlags(byte mask, bool value)
        {
            if((mask & (byte)Flag.INTERRUPT) != 0 && value)
            {
                P |= (byte)Flag.INTERRUPT;
            } else
            {
                P &= unchecked((byte)~Flag.INTERRUPT);
            }

            if ((mask & (byte)Flag.DECIMAL) != 0 && value)
            {
                P |= (byte)Flag.DECIMAL;
            } else
            {
                P &= unchecked((byte)~Flag.DECIMAL);
            }
        }

        public void nop()
        {

        }

        public void sei()
        {
            state.cycleCount += 2;
            SetFlags((byte)Flag.INTERRUPT, true);
        }

        public void cld()
        {
            state.cycleCount += 2;
            SetFlags((byte)Flag.DECIMAL, false);
        }

    }
}
