using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace jkod
{
    public class Dumper
    {
        public enum BaseOption : int { OCTAL, HEXA, UDECIMAL };

        /* Dump function outputs data as octal shorts (by default).
         * @param - file - File to open and dump.
         * @returns - string - the string containing the line-by-line dump.
         */
        public static string dump(string file, int baseSelected = (int)BaseOption.OCTAL, int colWidth = 2)
        {
            StringBuilder strbuffer = new StringBuilder();
            //try
            //{
            //    data = File.ReadAllBytes(file);  
            //}
            //catch(IOException)
            //{
            //}
            string format = null;
            int padding = 0;
            int radix = 0;

            if (baseSelected == (int)BaseOption.OCTAL)
            {
                format = "{0,7}";
                padding = 6; // determined by the value 377377
                radix = 8;
            }
            else if (baseSelected == (int)BaseOption.HEXA)
            {
                format = "{0,5}";
                padding = 4; // determined by the value 0xFFFF
                radix = 16;
            }
            else if (baseSelected == (int)BaseOption.UDECIMAL)
            {
                format = "{0,6}";
                padding = 5; // determined by the value 65535
                radix = 10;
            }

            UInt32 address = 0;
            UInt32 bytesPerLine = 16;
            int index = 0;

            byte[] data = File.ReadAllBytes(file);
            while (index < data.Length)
            {
                if (index % bytesPerLine == 0)
                {
                    strbuffer.AppendLine();
                    strbuffer.AppendFormat("{0:X8}: ", address);
                    address += bytesPerLine;
                }

                UInt16 entry = (UInt16)(data[index] << 8);
                ++index;
                if (index < data.Length)
                {
                    entry |= data[index];
                }
                ++index;
                strbuffer.AppendFormat(format, Convert.ToString(entry, radix).PadLeft(padding, '0'));   
            }
            strbuffer.AppendLine();
            // The top line "\n" is unnecessary.
            strbuffer.Remove(0, 1);
            
            return strbuffer.ToString();
        }
    }
}
