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

        public override byte ReadByte(ushort address)
        {
            return cart.PRGData[address - 0x8000];
        }

        public override void WriteByte(ushort address, byte val)
        {
            
        }

        public override ushort ReadWord(ushort address)
        {
            byte lower = cart.PRGData[address - 0x8000];
            byte upper = cart.PRGData[(address - 0x8000) + 1];

            return (ushort)(lower | upper << 8);
        }

        public override void WriteWord(ushort address, ushort val)
        {

        }
    }
}