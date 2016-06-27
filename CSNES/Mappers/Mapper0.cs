using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNES.Mappers
{
    class Mapper0 : Mapper
    {
        Cart cart;

        public Mapper0(Cart cart)
        {
            this.cart = cart;
        }

        public override byte read(ushort address)
        {
            return cart.PRGData[address - 0x8000];
        }

        public override void write(ushort address, byte val)
        {
            
        }
    }
}