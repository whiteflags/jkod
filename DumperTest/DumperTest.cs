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
            const string expected = "00000000:  060440 061040 061440 062040 062440 063040 063440 064040\n";
            File.WriteAllText(testFileName, content);
            string result = Dumper.dump(testFileName);
            StringAssert.Equals(result, expected);
            File.Delete(testFileName);
        }
    }
}
