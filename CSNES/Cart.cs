using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNES
{
    public class Cart
    {
        public int PRGROM16K;
        public int CHRROM8K;
        public int PRGROM8K;

        public bool Trainer;
        public bool NTSC;

        public int Mapper;
        public MirroringMode mirroringMode;

        public byte[] PRGData;
        public byte[] CHRData;

        public Cart(string path)
        {
            LoadRom(path);
        }

        private void LoadRom(string path)
        {
            byte[] rawROM = File.ReadAllBytes(path);
            byte[] header = new ArraySegment<byte>(rawROM, 0, 16).ToArray();

            byte[] signature = new ArraySegment<byte>(header, 0, 3).ToArray();

            if (Encoding.ASCII.GetString(signature) != "NES")
            {
                throw new NotImplementedException("Only ROMS with iNES headers supported.");
            }

            PRGROM16K = header[4];
            CHRROM8K = header[5];
            PRGROM8K = header[8];

            int flag6 = header[6];
            int flag7 = header[7];
            int flag9 = header[9];
            int flag10 = header[10];

            mirroringMode = (flag6 & 1) == 1 ? MirroringMode.Vertical : MirroringMode.Horizontal;
            Trainer = (flag6 & 4) != 0;
            NTSC = (flag10 & 1) == 0;

            Mapper = flag6 >> 4 | (flag7 & 0xf0); //Lower nibble of flag6 | upper nibble of flag7

            int prgFrom = 16;
            if(Trainer)
            {
                prgFrom += 512;
            }
            int prgLength = 0x4000 * PRGROM16K;

            PRGData = new ArraySegment<Byte>(rawROM, prgFrom, prgLength).ToArray();

            int chrFrom = prgFrom + prgLength;
            int chrLength = 0x2000 * CHRROM8K;

            CHRData = new ArraySegment<Byte>(rawROM, chrFrom, chrLength).ToArray();
        }

        public Mappers.Mapper getMapper()
        {
            return new Mappers.Mapper0(this);
        }
    }
}
