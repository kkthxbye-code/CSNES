using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNES.Mappers
{
    public abstract class Mapper
    {
        public abstract byte ReadByte(ushort addr);

        public abstract void WriteByte(ushort addr, byte val);

        public abstract ushort ReadWord(ushort addr);

        public abstract void WriteWord(ushort addr, ushort val);
    }
}
