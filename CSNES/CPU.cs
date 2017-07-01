using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNES
{
    public class CPU
    {
        public byte A; // Accumulator
        public byte X; // Index
        public byte Y; // Index
        public ushort PC; // Program Counter
        public byte S; // Stack Pointer
        public byte P; // Status Register

        public State state;
        public Dictionary<byte, Opcode> instructions;

        private Opcode currentOpcode;

        public CPU(State state)
        {
            this.state = state;

            this.PC = 0x8000;

            instructions = new Dictionary<byte, Opcode>()
            {
                { 0x78, new Opcode(sei) },
                { 0xD8, new Opcode(cld) },
                { 0xA9, new Opcode(lda, AddressingMode.Immediate ) },
                { 0x8D, new Opcode(sta, AddressingMode.Absolute) }
            };
        }

        public void Tick()
        {
            byte instruction = state.cart.getMapper().ReadByte(PC);
            Console.WriteLine("Read instruction: 0x{0:X} from 0x{1:X}", instruction, PC);

            PC++;


            try
            {
                Opcode opcode = instructions[instruction];
                currentOpcode = opcode;
                opcode.action();
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

        public void lda()
        {
            state.cycleCount += 2;
            A = state.ReadByte(PC, currentOpcode.addressingMode);
            PC++;
        }

        public void sta()
        {
            byte val = A;
            ushort addr = state.cart.getMapper().ReadWord(PC);

            state.WriteByte()
            Console.WriteLine("A: 0x{0:X}", A);
            Console.WriteLine("Addr: 0x{0:X}", addr);
            Console.WriteLine("Val: 0x{0:X}", val);
        }
    }
}
