using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNES
{
    public class Opcode
    {
        public Action action;
        public AddressingMode addressingMode;

        public Opcode(Action action, AddressingMode addressingMode)
        {
            this.action = action;
            this.addressingMode = addressingMode;
        }

        public Opcode(Action action) : this(action, AddressingMode.Implicit)
        {
        }
    }
}
