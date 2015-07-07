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
         * @param - baseSelected - the base the user has indicated the dump should be in.
         * @param - colWidth - the width of each entry in the table.
         * @param - bytesPerLine - determines the width of the whole table.
         * @returns - string - the string containing the line-by-line dump.
         */
        public static string dump(string file, int baseSelected = (int)BaseOption.OCTAL, 
            uint colWidth = 2, uint bytesPerLine = 16)
        {
            StringBuilder strbuffer = new StringBuilder();         
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
            // The top line "\r\n" is unnecessary.
            strbuffer.Remove(0, 2);
            
            return strbuffer.ToString();
        }

        /*
         * AddToDump function takes a table entry and inserts it in the output.
         * @param - strbuffer - the output container object.
         * @param - baseSelected - the number system used in the output.
         * @param - colWidth - the number of bytes of file covered by an entry.
         * @param - entry - the actual bytes written to the output.
         */
        private static void AddToDump(ref StringBuilder strbuffer, int baseSelected, uint colWidth, Int64 entry)
        {
            string format = null;
            int radix = 0;
            UInt64 columnMaximum = (UInt64)Math.Pow(2, colWidth * 8) - 1;
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

        /* DigitsUsedInBaseFunction calculates the number of digits required to show a value in a 
         * given number system. Used to format the rows of the output table.
         * @param - num - the value to determine place value count for.
         * @param - radix - the number system we are interested in, e.g. 16 (hexadecimal).
         * @returns - int - the number of digits.
         */
        private static int DigitsUsedInBase(UInt64 num, int radix)
        {
            return (int)Math.Ceiling(Math.Log10(num) / Math.Log10(radix));
        }
    }
}
