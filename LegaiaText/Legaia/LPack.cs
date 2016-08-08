using LegaiaText.Legaia.Compression;

using System.IO;

namespace LegaiaText.Legaia
{
    struct PackFile
    {
        public byte FileId;
        public byte[] Data;
    }

    class LPack
    {
        public PackFile[] Files;

        public static LPack FromData(byte[] Data)
        {
            if (Data.Length < 0x10) return null;

            LPack Output = new LPack();

            using (MemoryStream Input = new MemoryStream(Data))
            {
                BinaryReader Reader = new BinaryReader(Input);

                uint FilesCount = Reader.ReadUInt32();
                uint FileDecLength = Reader.ReadUInt32();

                //Simple validity check
                uint FirstAddr = 8 + FilesCount * 8;
                Input.Seek(4, SeekOrigin.Current);
                if (Reader.ReadUInt32() != FirstAddr) return null;

                Output.Files = new PackFile[FilesCount];

                for (int i = 0; i < FilesCount; i++)
                {
                    Input.Seek(8 + i * 8, SeekOrigin.Begin);

                    uint DecLength = Utils.ReadUInt24(Reader);
                    byte FileId = Reader.ReadByte();
                    uint Address = Reader.ReadUInt32();

                    Output.Files[i].FileId = FileId;
                    Output.Files[i].Data = LZSS.Decompress(Data, Address, DecLength);
                }
            }

            return Output;
        }

        public static byte[] ToData(LPack Pack)
        {
            using (MemoryStream Output = new MemoryStream())
            {
                BinaryWriter Writer = new BinaryWriter(Output);

                Writer.Write(Pack.Files.Length);
                Writer.Write(0u); //Total decompressed length Place Holder

                uint DataAddress = (uint)(8 + Pack.Files.Length * 8);
                uint FileDecLength = 0;

                for (int i = 0; i < Pack.Files.Length; i++)
                {
                    Output.Seek(8 + i * 8, SeekOrigin.Begin);

                    Utils.WriteUInt24(Writer, (uint)Pack.Files[i].Data.Length);
                    Writer.Write(Pack.Files[i].FileId);
                    Writer.Write(DataAddress);

                    Output.Seek(DataAddress, SeekOrigin.Begin);

                    byte[] Comp = LZSS.Compress(Pack.Files[i].Data);

                    Writer.Write(Comp);

                    DataAddress += (uint)Comp.Length;
                    FileDecLength += (uint)Pack.Files[i].Data.Length;
                }

                Output.Seek(4, SeekOrigin.Begin);
                Writer.Write(FileDecLength);

                return Output.ToArray();
            }
        }
    }
}
