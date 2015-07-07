using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace jkod
{
    public class Dumper
    {
        public enum BaseOption : int { OCTAL, HEXA, DECIMAL };

        /* Dump function outputs data as octal shorts (by default).
         * @param - file - File to open and dump.
         * @returns - string - the string containing the line-by-line dump.
         */
        public static string dump(string file, int baseSelected = (int)BaseOption.OCTAL, 
            uint colWidth = 2, uint bytesPerLine = 16)
        {
            StringBuilder strbuffer = new StringBuilder();
            //try
            //{
            //    data = File.ReadAllBytes(file);  
            //}
            //catch(IOException)
            //{
            //}
           
            uint address = 0;
            uint index = 0;

            byte[] data = File.ReadAllBytes(file);
            while (index < data.Length)
            {
                if (index % bytesPerLine == 0)
                {
                    strbuffer.AppendLine();
                    strbuffer.AppendFormat("{0:X8}: ", address);
                    address += bytesPerLine;
                }

                Int64 entry = (Int64)data[index];
                for (uint i = 1; index + i < data.Length && i < colWidth; ++i)
                {
                    entry = entry << 8 | data[index + i];    
                }
                index += colWidth;
                AddToDump(ref strbuffer, baseSelected, colWidth, entry);
            }
            strbuffer.AppendLine();
            // The top line "\n" is unnecessary.
            strbuffer.Remove(0, 1);
            
            return strbuffer.ToString();
        }

        private static void AddToDump(ref StringBuilder strbuffer, int baseSelected, uint colWidth, Int64 entry)
        {
            string format = null;
            int radix = 0;
            Int64 columnMaximum = (Int64)Math.Pow(2, colWidth * 8) - 1;
            int maxDigitsInColumn = 0;

            if (baseSelected == (int)BaseOption.OCTAL)
            {
                maxDigitsInColumn = DigitsUsedInBase(columnMaximum, 8);
                format = String.Format("{0}0,{1:D}{2}", '{', maxDigitsInColumn + 1, '}');
                radix = 8;
            }
            else if (baseSelected == (int)BaseOption.HEXA)
            {
                maxDigitsInColumn = DigitsUsedInBase(columnMaximum, 16);
                format = String.Format("{0}0,{1:D}{2}", '{', maxDigitsInColumn + 1, '}');
                radix = 16;
            }
            else if (baseSelected == (int)BaseOption.DECIMAL)
            {
                maxDigitsInColumn = DigitsUsedInBase(columnMaximum, 10);
                format = String.Format("{0}0,{1:D}{2}", '{', maxDigitsInColumn + 2, '}');
                radix = 10;
            }

            strbuffer.AppendFormat(format, Convert.ToString(entry, radix).PadLeft(maxDigitsInColumn, '0'));
        }

        private static int DigitsUsedInBase(Int64 num, int radix)
        {
            return (int)Math.Ceiling(Math.Log10(num) / Math.Log10(radix));
        }
    }
}
