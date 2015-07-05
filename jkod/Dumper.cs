using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace jkod
{
    class Dumper
    {
        /* Dump function outputs data as octal shorts (by default).
         * @param - file - File to open and dump.
         * @returns - string - the string containing the line-by-line dump.
         */
        public static string dump(string file)
        {
            StringBuilder strbuffer = new StringBuilder();
            byte[] data = null;
            try
            {
                data = File.ReadAllBytes(file);  
            }
            catch(IOException)
            {
            }

            UInt32 address = 0;
            UInt32 bytesPerLine = 16;
            int index = 0;

            while (index < data.Length)
            {
                if (index % bytesPerLine == 0)
                {
                    strbuffer.AppendLine();
                    strbuffer.AppendFormat("{0:X8}: ", address);
                    address += bytesPerLine;
                }

                string entry = Convert.ToString((short)(data[index] << 8 | data[index + 1]), 8);
                strbuffer.AppendFormat("{0,7:}", entry);
                index += 2;
            }
            strbuffer.AppendLine();
            
            return strbuffer.ToString();
        }
    }
}
