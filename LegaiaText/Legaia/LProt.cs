using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegaiaText.Legaia
{
    class LProt
    {
        public byte[][] Files;

        public static LProt FromFile(string FileName)
        {
            LProt Output = new LProt();

            using (FileStream Input = new FileStream(FileName, FileMode.Open))
            {
                BinaryReader Reader = new BinaryReader(Input);

                uint FileVersion = Reader.ReadUInt32(); //I guess?
                uint FilesCount = Reader.ReadUInt32();

                Output.Files = new byte[FilesCount][];

                for (int i = 0; i < FilesCount; i++)
                {
                    Input.Seek(8 + i * 4, SeekOrigin.Begin);

                    long SAddress = (long)Reader.ReadUInt32() << 11;
                    long EAddress = (long)Reader.ReadUInt32() << 11;

                    int Length = (int)(EAddress - SAddress);

                    Input.Seek(SAddress, SeekOrigin.Begin);

                    Output.Files[i] = Reader.ReadBytes(Length);
                }
            }

            return Output;
        }

        public static void ToFile(LProt Prot, string FileName)
        {
            using (FileStream Output = new FileStream(FileName, FileMode.Open))
            {
                BinaryWriter Writer = new BinaryWriter(Output);

                Writer.Write(0u);
                Writer.Write(Prot.Files.Length);

                uint DataAddress = (uint)(8 + Prot.Files.Length * 4 + 4);
                
                //Align to 8K boundary
                DataAddress = (DataAddress + 0x800) & ~0x7ffu;

                for (int i = 0; i < Prot.Files.Length; i++)
                {
                    Output.Seek(8 + i * 4, SeekOrigin.Begin);
                    Writer.Write(DataAddress >> 11);

                    Output.Seek(DataAddress, SeekOrigin.Begin);
                    Writer.Write(Prot.Files[i]);

                    while ((Output.Position & 0x7ff) != 0) Output.WriteByte(0);

                    DataAddress = (uint)Output.Position;
                }

                Output.Seek(8 + Prot.Files.Length * 4, SeekOrigin.Begin);

                Writer.Write(DataAddress >> 11);
            }
        }
    }
}
