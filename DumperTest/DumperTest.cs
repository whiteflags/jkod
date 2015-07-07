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

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void DumpMethodShouldThrowIOException()
        {
            Dumper.dump(bigFileName);
        }

        [TestMethod]
        public void TestDumpMethodDefaultOutput()
        {
            const string content = "a b c d e f g h ";
            const string expected = "00000000:  060440 061040 061440 062040 062440 063040 063440 064040";
            File.WriteAllText(testFileName, content);
            string result = Dumper.dump(testFileName);
            StringAssert.Contains(result, expected);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodHexOutput()
        {
            const string content = "a b c d e f g h ";
            const string expected = "00000000:  6120 6220 6320 6420 6520 6620 6720 6820";
            File.WriteAllText(testFileName, content);
            string result = Dumper.dump(testFileName, (int)Dumper.BaseOption.HEXA);
            StringAssert.Contains(result, expected);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodUDecOutput()
        {
            const string content = "a b c d e f g h ";
            const string expected = "00000000:  24864 25120 25376 25632 25888 26144 26400 26656";
            File.WriteAllText(testFileName, content);
            string result = Dumper.dump(testFileName, (int)Dumper.BaseOption.DECIMAL);
            StringAssert.Contains(result, expected);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodOneByteColOutput()
        {
            const string content = "a b c d e f g h ";
            const string expected = "00000000:  141 040 142 040 143 040 144 040 145 040 146 040 147 040 150 040";
            File.WriteAllText(testFileName, content);
            string result = Dumper.dump(testFileName, (int)Dumper.BaseOption.OCTAL, 1);
            StringAssert.Contains(result, expected);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodFourByteColOutput()
        {
            const string content = "a b c d e f g h ";
            const string expected = "00000000:  14110061040 14310062040 14510063040 14710064040";
            File.WriteAllText(testFileName, content);
            string result = Dumper.dump(testFileName, (int)Dumper.BaseOption.OCTAL, 4);
            StringAssert.Contains(result, expected);
            File.Delete(testFileName);
        }

        [TestMethod]
        public void TestDumpMethodEightByteColOutput()
        {
            const string content = "Lorem ipsum dolor sit amit. ";
            string[] expected = {
              "00000000:  461573446255510064560 715653322014433666157"
            , "00000010:  710403466456410060555 000000000015135027040" };
            File.WriteAllText(testFileName, content);
            string result = Dumper.dump(testFileName, (int)Dumper.BaseOption.OCTAL, 8);
            StringAssert.Contains(result, expected[0]);
            StringAssert.Contains(result, expected[1]);
            File.Delete(testFileName);
        }
    }
}
