using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace jkod
{
    public class Dumper
    {
        public enum BaseOption : int { OCTAL, HEXA, DECIMAL };

        private BaseOption _baseSelected;
        private int _colWidth;
        private uint _bytesPerLine;
        private bool _isVerbose;

        public bool IsVerbose
        {
            get { return _isVerbose; }
            set { _isVerbose = value; }
        }
        
        public uint BytesPerLine
        {
            get { return _bytesPerLine; }
            set { _bytesPerLine = value; }
        }
        
        public int ColumnWidth
        {
            get { return _colWidth; }
            set { _colWidth = value; }
        }

        public BaseOption BaseSelected
        {
            get { return _baseSelected; }
            set { _baseSelected = value; }
        }
        
        public Dumper()
        {
            BaseSelected = BaseOption.OCTAL;
            ColumnWidth = 2;
            BytesPerLine = 16;
            IsVerbose = true;
        }

        /* Dump function outputs data as octal shorts (by default).
         * @param - file - File to open and dump.
         * @returns - string - the string containing the line-by-line dump.
         */
        public string dump(string file)
        {
            StringBuilder strbuffer = new StringBuilder();
            uint address = 0;
            int index = 0;
            uint dupeCount = 0;
            string format = null;
            string prevline = null;
            string line = "";
            int radix = 0;
            UInt64 columnMaximum = (UInt64)Math.Pow(2, _colWidth * 8) - 1;
            int maxDigitsInColumn = 0;

            if (_baseSelected == BaseOption.OCTAL)
            {
                maxDigitsInColumn = DigitsUsedInBase(columnMaximum, 8);
                format = String.Format("{0}0,{1:D}{2}", '{', maxDigitsInColumn + 1, '}');
                radix = 8;
            }
            else if (_baseSelected == BaseOption.HEXA)
            {
                maxDigitsInColumn = DigitsUsedInBase(columnMaximum, 16);
                format = String.Format("{0}0,{1:D}{2}", '{', maxDigitsInColumn + 1, '}');
                radix = 16;
            }
            else if (_baseSelected == BaseOption.DECIMAL)
            {
                maxDigitsInColumn = DigitsUsedInBase(columnMaximum, 10);
                format = String.Format("{0}0,{1:D}{2}", '{', maxDigitsInColumn + 2, '}');
                radix = 10;
            }

            byte[] data = File.ReadAllBytes(file);
            while (index < data.Length)
            {
                Int64 entry = (Int64)data[index];
                for (int i = 1; index + i < data.Length && i < _colWidth; ++i)
                {
                    entry = entry << 8 | data[index + i];
                }
                index += _colWidth;
                line += String.Format(format, Convert.ToString(entry, radix).PadLeft(maxDigitsInColumn, '0'));

                // Line contains enough content!
                // Figure out wether to dump or suppress:
                if (index % _bytesPerLine == 0)
                {
                    if (!_isVerbose)
                    {
                        if ((line != prevline && dupeCount > 0))
                        {
                            ShowDuplicates(strbuffer, ref dupeCount);
                        }

                        if (prevline == line)
                        {
                            ++dupeCount;
                        }
                        else
                        {
                            AddToDump(strbuffer, address, line);
                        }
                    }
                    else
                    {
                        AddToDump(strbuffer, address, line);
                    }
                    prevline = line;
                    line = "";
                    address += _bytesPerLine;
                }
            }
            
            // Handle the last line:
            if (!_isVerbose && dupeCount > 0)
            {
                ShowDuplicates(strbuffer, ref dupeCount);
                if (line.Length != 0)
                {
                    AddToDump(strbuffer, address, line);
                }
            }
            else
            {
                AddToDump(strbuffer, address, line);
            }
            return strbuffer.ToString();
        }
        /* ShowDuplicate function will print the number of duplicates found when called.
         * @param - strbuffer - the contents of the dump so far.
         * @param - dupeCount - the number of duplicate lines so far.
         */
        private static void ShowDuplicates(StringBuilder strbuffer, ref uint dupeCount)
        {
            strbuffer.AppendFormat("* line duplicated {0:D} times", dupeCount);
            strbuffer.AppendLine();
            dupeCount = 0;
        }

        /* AddToDump will add a line to the dump so far when called.
         * @param - strbuffer - the contents of the dump so far.
         * @param - address - the current address of the line to be dumped.
         * @param - line - the line to be dumped.
         */
        private static void AddToDump(StringBuilder strbuffer, uint address, string line)
        {
            strbuffer.AppendFormat("{0:X8}: ", address);
            strbuffer.AppendLine(line);
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
