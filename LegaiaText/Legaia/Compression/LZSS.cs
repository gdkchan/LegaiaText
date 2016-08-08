using System;
using System.IO;

namespace LegaiaText.Legaia.Compression
{
    class LZSS
    {
        public static byte[] Compress(byte[] Data)
        {
            using (MemoryStream Output = new MemoryStream())
            {
                ulong[] LookUp = new ulong[0x10000];

                byte[] Dict = new byte[0x1000];

                int DictAddr = 4078;
                int SrcAddr = 0;
                int BitsAddr = 0;

                ushort Mask = 0x80;

                byte Header = 0;

                while (SrcAddr < Data.Length)
                {
                    if ((Mask <<= 1) == 0x100)
                    {
                        int OldAddr = BitsAddr;

                        BitsAddr = (int)Output.Position;

                        Output.Seek(OldAddr, SeekOrigin.Begin);
                        Output.WriteByte(Header);

                        Output.Seek(BitsAddr, SeekOrigin.Begin);
                        Output.WriteByte(0);

                        Header = 0;
                        Mask = 1;
                    }

                    int Length = 2;
                    int DictPos = 0;

                    if (SrcAddr + 2 < Data.Length)
                    {
                        int Value;

                        Value  = Data[SrcAddr + 0] << 8;
                        Value |= Data[SrcAddr + 1] << 0;

                        for (int i = 0; i < 5; i++)
                        {
                            int Index = (int)((LookUp[Value] >> (i * 12)) & 0xfff);

                            //First byte doesn't match, so the others won't match too
                            if (Data[SrcAddr] != Dict[Index]) break;

                            //Temporary dictionary used on comparisons
                            byte[] CmpDict = new byte[0x1000];
                            Array.Copy(Dict, CmpDict, Dict.Length);
                            int CmpAddr = DictAddr;

                            int MatchLen = 0;

                            for (int j = 0; j < 18 && SrcAddr + j < Data.Length; j++)
                            {
                                if (CmpDict[(Index + j) & 0xfff] == Data[SrcAddr + j])
                                    MatchLen++;
                                else
                                    break;

                                CmpDict[CmpAddr] = Data[SrcAddr + j];
                                CmpAddr = (CmpAddr + 1) & 0xfff;
                            }

                            if (MatchLen > Length && MatchLen < Output.Length)
                            {
                                Length = MatchLen;
                                DictPos = Index;
                            }
                        }
                    }

                    if (Length > 2)
                    {
                        Output.WriteByte((byte)DictPos);

                        int NibLo = (Length - 3) & 0xf;
                        int NibHi = (DictPos >> 4) & 0xf0;

                        Output.WriteByte((byte)(NibLo | NibHi));
                    }
                    else
                    {
                        Header |= (byte)Mask;

                        Output.WriteByte(Data[SrcAddr]);

                        Length = 1;
                    }

                    for (int i = 0; i < Length; i++)
                    {
                        if (SrcAddr + 1 < Data.Length)
                        {
                            int Value;

                            Value = Data[SrcAddr + 0] << 8;
                            Value |= Data[SrcAddr + 1] << 0;

                            LookUp[Value] <<= 12;
                            LookUp[Value] |= (uint)DictAddr;
                        }

                        Dict[DictAddr] = Data[SrcAddr++];
                        DictAddr = (DictAddr + 1) & 0xfff;
                    }
                }

                Output.Seek(BitsAddr, SeekOrigin.Begin);
                Output.WriteByte(Header);

                return Output.ToArray();
            }
        }

        public static byte[] Decompress(byte[] Data, uint InputAddr, uint DecLength)
        {
            byte[] Output = new byte[DecLength];
            byte[] Dict = new byte[0x1000];

            long OutputAddr = 0;
            long DictAddr = 4078;

            ushort Mask = 0x80;
            byte Header = 0;

            while (OutputAddr < DecLength)
            {
                if ((Mask <<= 1) == 0x100)
                {
                    Header = Data[InputAddr++];
                    Mask = 1;
                }

                if ((Header & Mask) != 0)
                {
                    Dict[DictAddr] = Data[InputAddr];
                    Output[OutputAddr++] = Data[InputAddr++];

                    DictAddr = (DictAddr + 1) & 0xfff;
                }
                else
                {
                    int Value;

                    Value = Data[InputAddr++] << 0;
                    Value |= Data[InputAddr++] << 8;

                    int Length = ((Value >> 8) & 0xf) + 3;
                    int DictPos = ((Value & 0xf000) >> 4) | (Value & 0xff);

                    while (Length-- > 0)
                    {
                        Dict[DictAddr] = Dict[DictPos];
                        Output[OutputAddr++] = Dict[DictPos];

                        DictAddr = (DictAddr + 1) & 0xfff;
                        DictPos = (DictPos + 1) & 0xfff;
                    }
                }
            }

            return Output;
        }
    }
}
