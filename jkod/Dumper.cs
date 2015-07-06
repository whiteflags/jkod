using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace jkod
{
    public class Dumper
    {
        /* Dump function outputs data as octal shorts (by default).
         * @param - file - File to open and dump.
         * @returns - string - the string containing the line-by-line dump.
         */
        public static string dump(string file)
        {
            StringBuilder strbuffer = new StringBuilder();
            byte[] data = null;
            //try
            //{
            //    data = File.ReadAllBytes(file);  
            //}
            //catch(IOException)
            //{
            //}

            UInt32 address = 0;
            UInt32 bytesPerLine = 16;
            int index = 0;

            data = File.ReadAllBytes(file);
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
                strbuffer.AppendFormat("{0,7}", Convert.ToString(entry, 8).PadLeft(6, '0'));
                ++index;
            }
            strbuffer.AppendLine();
            // The top line "\n" is unnecessary.
            strbuffer.Remove(0, 1);
            
            return strbuffer.ToString();
        }
    }
}
