using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using jkod;

namespace DumperTest
{
    [TestClass]
    public class DumperTest
    {
        //!! If you need to test files in different locations, use the below fields.
        //!! Big file test should exceed the file size limit of the System.IO implementation ~4.2GB
        private const string bigFileName = "C:\\Users\\Josh2\\Music\\bigfile.rar";
        private const string testFileName = "abcdefgh.bin";
        private Dumper d = new Dumper();

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void DumpMethodShouldThrowIOException()
        {
            d.dump(bigFileName);
        }

        [TestMethod]
        public void TestDumpMethodDefaultOutput()
        {
            const string content = "a b c d e f g h ";
            const string expected = "00000000:  060440 061040 061440 062040 062440 063040 063440 064040";
            File.WriteAllText(testFileName, content);
            string result = d.dump(testFileName);
            StringAssert.Contains(result, expected);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodHexOutput()
        {
            const string content = "a b c d e f g h ";
            const string expected = "00000000:  6120 6220 6320 6420 6520 6620 6720 6820";
            File.WriteAllText(testFileName, content);
            d.BaseSelected = Dumper.BaseOption.HEXA;
            string result = d.dump(testFileName);
            StringAssert.Contains(result, expected);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodDecOutput()
        {
            const string content = "a b c d e f g h ";
            const string expected = "00000000:   24864  25120  25376  25632  25888  26144  26400  26656";
            File.WriteAllText(testFileName, content);
            d.BaseSelected = Dumper.BaseOption.DECIMAL;
            string result = d.dump(testFileName);
            StringAssert.Contains(result, expected);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodOneByteColOutput()
        {
            const string content = "a b c d e f g h ";
            const string expected = "00000000:  141 040 142 040 143 040 144 040 145 040 146 040 147 040 150 040";
            File.WriteAllText(testFileName, content);
            d.BaseSelected = Dumper.BaseOption.OCTAL;
            d.ColumnWidth = 1;
            string result = d.dump(testFileName);
            StringAssert.Contains(result, expected);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodFourByteColOutput()
        {
            const string content = "a b c d e f g h ";
            const string expected = "00000000:  14110061040 14310062040 14510063040 14710064040";
            File.WriteAllText(testFileName, content);
            d.BaseSelected = Dumper.BaseOption.OCTAL;
            d.ColumnWidth = 4;
            string result = d.dump(testFileName);
            StringAssert.Contains(result, expected);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodEightByteColOutput()
        {
            const string content = "Lorem ipsum dolor sit amit. ";
            string[] expected = {
              "00000000:  0461573446255510064560 0715653322014433666157"
            , "00000010:  0710403466456410060555 0000000000015135027040" 
            };
            File.WriteAllText(testFileName, content);
            d.BaseSelected = Dumper.BaseOption.OCTAL;
            d.ColumnWidth = 8;
            string result = d.dump(testFileName);
            StringAssert.Contains(result, expected[0]);
            StringAssert.Contains(result, expected[1]);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodThirtyTwoByteRow()
        {
            const string content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit posuere.";
            string[] expected = {
              "00000000:  4c 6f 72 65 6d 20 69 70 73 75 6d 20 64 6f 6c 6f 72 20 73 69 74 20 61 6d 65 74 2c 20 63 6f 6e 73"
            , "00000020:  65 63 74 65 74 75 72 20 61 64 69 70 69 73 63 69 6e 67 20 65 6c 69 74 20 70 6f 73 75 65 72 65 2e"
            };
            File.WriteAllText(testFileName, content);
            d.BaseSelected = Dumper.BaseOption.HEXA;
            d.ColumnWidth = 1;
            d.BytesPerLine = 32;
            string result = d.dump(testFileName);
            StringAssert.Contains(result, expected[0]);
            StringAssert.Contains(result, expected[1]);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodSixtyFourByteRow()
        {
            const string content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit posuere.";
            string expected = "00000000:  4c 6f 72 65 6d 20 69 70 73 75 6d 20 64 6f 6c 6f ";
            expected +=                  "72 20 73 69 74 20 61 6d 65 74 2c 20 63 6f 6e 73 ";
            expected +=                  "65 63 74 65 74 75 72 20 61 64 69 70 69 73 63 69 ";
            expected +=                  "6e 67 20 65 6c 69 74 20 70 6f 73 75 65 72 65 2e";
            File.WriteAllText(testFileName, content);
            d.BaseSelected = Dumper.BaseOption.HEXA;
            d.ColumnWidth = 1;
            d.BytesPerLine = 64;
            string result = d.dump(testFileName);
            StringAssert.Contains(result, expected);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodMaximumSizeRow()
        {
            string content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin efficitur posuere orci, ";
            content += "quis lacinia nisl gravida quis. Etiam vulputate lacus nec amet. ";
            string[] expected = { 
                "00000000:  4c 6f 72 65 6d 20 69 70 73 75 6d 20 64 6f 6c 6f 72 20 73 69 74 20 61 6d "
                + "65 74 2c 20 63 6f 6e 73 65 63 74 65 74 75 72 20 61 64 69 70 69 73 63 69 "
                + "6e 67 20 65 6c 69 74 2e 20 50 72 6f 69 6e 20 65 66 66 69 63 69 74 75 72 "
                + "20 70 6f 73 75 65 72 65 20 6f 72 63 69 2c 20 71 75 69 73 20 6c 61 63 69 "
                + "6e 69 61 20 6e 69 73 6c 20 67 72 61 76 69 64 61 20 71 75 69 73 2e 20 45 "
                + "74 69 61 6d 20 76 75 6c"
              , "00000080:  70 75 74 61 74 65 20 6c 61 63 75 73 20 6e 65 63 20 61 6d 65 74 2e"
            };
            File.WriteAllText(testFileName, content);
            d.BaseSelected = Dumper.BaseOption.HEXA;
            d.ColumnWidth = 1;
            d.BytesPerLine = 128;
            string result = d.dump(testFileName);
            StringAssert.Contains(result, expected[0]);
            StringAssert.Contains(result, expected[1]);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodDuplicateLines()
        {
            string content = "Lorem ipsum do";
            string[] expected = { 
                "00000000:  4c6f 7265 6d20 6970 7375 6d20 646f 0d0a"
              , "* line duplicated 2 times"
            };
            using (StreamWriter swTest = new StreamWriter(testFileName))
            {
                for (int i = 0; i < 3; ++i)
                {
                    swTest.WriteLine(content);
                }
            }
            d.BaseSelected = Dumper.BaseOption.HEXA;
            string result = d.dump(testFileName);
            StringAssert.Contains(result, expected[0]);
            StringAssert.Contains(result, expected[1]);
        }
    }
}
