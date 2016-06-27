using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNES.Mappers
{
    public abstract class Mapper
    {
        public abstract byte read(ushort addr);

        public abstract void write(ushort addr, byte val);
    }
}
