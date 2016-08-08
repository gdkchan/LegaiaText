using System.IO;

namespace LegaiaText.Legaia
{
    class LScript
    {
        public byte[] Header;

        public ushort Count0;
        public ushort Count1;
        public ushort Count2;

        public byte[][] Scripts;

        public byte[] Footer;

        public static LScript FromData(byte[] Data)
        {
            if (Data.Length < 0x2e) return null;

            LScript Output = new LScript();

            using (MemoryStream Input = new MemoryStream(Data))
            {
                BinaryReader Reader = new BinaryReader(Input);

                Output.Header = Reader.ReadBytes(0x22);

                int Count = 0;

                Count += (Output.Count0 = Reader.ReadUInt16());
                Count += (Output.Count1 = Reader.ReadUInt16());
                Count += (Output.Count2 = Reader.ReadUInt16());

                Output.Scripts = new byte[Count][];

                uint BaseAddress = (uint)(0x2b + Count * 3);
                uint FooterAddress = Utils.ReadUInt24(Reader) + BaseAddress;

                if (FooterAddress >= Data.Length || Count == 0) return null;

                for (int i = 0; i < Count; i++)
                {
                    Input.Seek(0x2b + i * 3, SeekOrigin.Begin);

                    uint Address = Utils.ReadUInt24(Reader);

                    if (i == 0 && Address != 0) return null;

                    uint Length;

                    if (i < Count - 1)
                        Length = Utils.ReadUInt24(Reader) - Address;
                    else
                        Length = FooterAddress - (Address + BaseAddress);

                    if (Length >= Data.Length) return null;

                    Input.Seek(Address + BaseAddress, SeekOrigin.Begin);
                    Output.Scripts[i] = Reader.ReadBytes((int)Length);
                }

                Input.Seek(FooterAddress, SeekOrigin.Begin);
                Output.Footer = Reader.ReadBytes((int)(Data.Length - FooterAddress));
            }

            return Output;
        }

        public static byte[] ToData(LScript Script)
        {
            using (MemoryStream Output = new MemoryStream())
            {
                BinaryWriter Writer = new BinaryWriter(Output);

                Writer.Write(Script.Header);

                Writer.Write(Script.Count0);
                Writer.Write(Script.Count1);
                Writer.Write(Script.Count2);

                int Count = Script.Count0 + Script.Count1 + Script.Count2;
                uint BaseAddress = (uint)(0x2b + Count * 3);

                Utils.WriteUInt24(Writer, 0);

                uint DataOffset = 0;

                for (int i = 0; i < Count; i++)
                {
                    Output.Seek(0x2b + i * 3, SeekOrigin.Begin);

                    Utils.WriteUInt24(Writer, DataOffset);

                    Output.Seek(BaseAddress + DataOffset, SeekOrigin.Begin);
                    Writer.Write(Script.Scripts[i]);

                    DataOffset += (uint)Script.Scripts[i].Length;
                }

                uint FooterAddress = DataOffset;

                Writer.Write(Script.Footer);

                Output.Seek(0x28, SeekOrigin.Begin);
                Utils.WriteUInt24(Writer, FooterAddress);

                return Output.ToArray();
            }
        }
    }
}
