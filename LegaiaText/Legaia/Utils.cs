using LegaiaText.Properties;

using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LegaiaText.Legaia
{
    class Utils
    {
        public static uint ReadUInt24(BinaryReader Reader)
        {
            uint Output;

            Output  = (uint)Reader.ReadByte() << 0;
            Output |= (uint)Reader.ReadByte() << 8;
            Output |= (uint)Reader.ReadByte() << 16;

            return Output;
        }

        public static void WriteUInt24(BinaryWriter Writer, uint Value)
        {
            Writer.Write((byte)(Value >>  0));
            Writer.Write((byte)(Value >>  8));
            Writer.Write((byte)(Value >> 16));
        }

        public static string Data2Text(byte[] Data)
        {
            StringBuilder Output = new StringBuilder();

            string[] Table = GetTable();

            for (int i = 0; i < Data.Length; i++)
            {
                int Value = Data[i];
                bool High = false;

                if ((Value >> 4) == 0xc && i < Data.Length - 1)
                {
                    Value = (Value << 8) | Data[i + 1];
                    High = true;
                }

                if (Table[Value] != null)
                {
                    Output.Append(Table[Value]);
                    if (High) i++;
                }
                else
                {
                    if (High) Value >>= 8;
                    Output.Append(string.Format("\\x{0:X2}", Value));
                }
            }

            return Output.ToString();
        }

        public static byte[] Text2Data(string Text)
        {
            string[] Table = GetTable();

            using (MemoryStream Output = new MemoryStream())
            {
                for (int Index = 0; Index < Text.Length; Index++)
                {
                    if (Index + 4 <= Text.Length && Regex.IsMatch(Text.Substring(Index, 4), "\\\\x[0-9A-Fa-f]{2}"))
                    {
                        //Unknown data = Hex code
                        string Hex = Text.Substring(Index + 2, 2);
                        int Value = int.Parse(Hex, NumberStyles.HexNumber);

                        Output.WriteByte((byte)Value);

                        Index += 3;
                    }
                    else
                    {
                        //Character
                        int Value = -1;

                        string Character = Text.Substring(Index, 1);

                        if (Character == "{")
                        {
                            int MaxLen = 0;

                            //Slow search method for table elements with more than 1 character
                            for (int TblIndex = 0; TblIndex < Table.Length; TblIndex++)
                            {
                                string TblValue = Table[TblIndex];

                                if (TblValue == null || Index + TblValue.Length > Text.Length) continue;

                                int Length = TblValue.Length;

                                if (Text.Substring(Index, Length) == TblValue && Length > MaxLen)
                                {
                                    Value = TblIndex;
                                    MaxLen = Length;
                                }
                            }

                            if (Value > -1) Index += MaxLen - 1;
                        }
                        else
                        {
                            Value = Array.IndexOf(Table, Character);
                        }

                        if (Value == -1) Value = 0x20; //Unknown, add space

                        if (Value > 0xff) Output.WriteByte((byte)(Value >> 8));
                        Output.WriteByte((byte)Value);
                    }
                }

                return Output.ToArray();
            }
        }

        private static string[] GetTable()
        {
            string[] Table = new string[0x10000];
            string[] LineBreaks = new string[] { "\n", "\r\n" };
            string[] TableElements = Resources.Table.Split(LineBreaks, StringSplitOptions.RemoveEmptyEntries);

            foreach (string Element in TableElements)
            {
                string[] Parameters = Element.Split('=');
                int Value = Convert.ToInt32(Parameters[0], 16);
                string Character = Parameters[1];

                //Replace some codes that needs to be "escaped" on the tbl due to the way how it is parsed
                Character = Character.Replace("\\n", "\r\n");
                Character = Character.Replace("\\equal", "=");

                Table[Value] = Character;
            }

            return Table;
        }

        const int KiB = 1024;
        const int MiB = KiB * 1024;
        const int GiB = MiB * 1024;

        public static string SizeString(int Bytes)
        {
            if (Bytes >= GiB)
                return string.Format("{0} GiB", Bytes / GiB);
            else if (Bytes >= MiB)
                return string.Format("{0} MiB", Bytes / MiB);
            else if (Bytes >= KiB)
                return string.Format("{0} KiB", Bytes / KiB);
            else
                return string.Format("{0} B", Bytes);
        }
    }
}
