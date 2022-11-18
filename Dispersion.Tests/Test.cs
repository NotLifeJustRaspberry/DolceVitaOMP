using System;
using System.IO;
using System.Text;

namespace Dispersion.Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestReadFile()
        {
            string path = "test.txt";
            string[] expected = new string[]
            {
                "Hello world hello hello hello world.",
                "Я автоматизирую, как завещал нам Генри Форд.",
                "Я знаю, как собрать эксплойт и как обжать патчкорд.",
                "Hello world hello hello motherfuckin' world."
            };
            File.WriteAllLines(path, expected);
            string[] actual = Dispersion.ReadFile(path);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }
        [TestMethod]
        public void TestReadFileWithVoid()
        {
            string path = "test.txt";
            string[] expected = new string[]
            {
                "Я трек-конструктор, коллектив и человек.",
                "Моя задача - это переполнять людям стек.",
                "",
                "Моя задача - это слать в головы реквесты,",
                ""
            };
            File.WriteAllLines(path, expected);
            string[] actual = Dispersion.ReadFile(path);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }
        [TestMethod]
        public void TestReadVoidFile()
        {
            string path = "test2.txt";
            string[] expected = Array.Empty<string>();
            string[] actual = Dispersion.ReadFile(path);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void TestSplitText()
        {
            ulong[][] expected = new ulong[4][]
            {
                new ulong[] { 105, 10, 56 },
                new ulong[] { 56, 235, 876 },
                new ulong[] { 234, 675, 234 },
                new ulong[] { 345 ,11, 554 }
            };

            List<string> input = new();
            foreach (var line in expected)
            {
                StringBuilder temp = new ();
                foreach (var element in line)
                    temp.Append(element + " ");
                input.Add(temp.ToString());
            }

            ulong[][] actual = Dispersion.SplitText(input.ToArray());

            for (int i = 0; i < expected.Length; i++)
                for (int j = 0; j < expected[0].Length; j++)
                    Assert.AreEqual(expected[i][j], actual[i][j]);
        }

        [TestMethod]
        public void TestSolve()
        {
            List<Data> expected = new()
            {
                new Data(57, 1504),
                new Data(389, 123924),
                new Data(315964, 236788857302),
                new Data(216, 46656)

            };
            ulong[][] data = new ulong[4][]
            {
                new ulong[] { 105, 10, 56 },
                new ulong[] { 56, 235, 876 },
                new ulong[] { 10543, 34562, 6256, 45345, 1345627, 453453 },
                new ulong[] { 432, 1 }

            };

            List<Data> actual = Dispersion.Solve(data);

            for (int j = 0; j < expected.Count; j++)
            {
                Assert.AreEqual(expected[j].M, actual[j].M);
                Assert.AreEqual(expected[j].D, actual[j].D);
            }
        }

        [TestMethod]
        public void TestPrintFileSpace()
        {
            string[] expected = new string[] { "57 1504", "389 123924", "315964 236788857302", "216 46656" };
            string path = "test.cvc";
            List<Data> datas = new()
            {
                new Data(57, 1504),
                new Data(389, 123924),
                new Data(315964, 236788857302),
                new Data(216, 46656)
            };

            Dispersion.PrintFile(datas, path, " ");
            var actual = File.ReadAllLines(path);

            for (int j = 0; j < datas.Count; j++)
                Assert.AreEqual(expected[j], actual[j]);
        }

        [TestMethod]
        public void TestPrintFileSemicolon()
        {
            string[] expected = new string[] { "57;1504", "389;123924", "315964;236788857302", "216;46656" };
            string path = "test.cvc";
            List<Data> datas = new()
            {
                new Data(57, 1504),
                new Data(389, 123924),
                new Data(315964, 236788857302),
                new Data(216, 46656)
            };

            Dispersion.PrintFile(datas, path, ";");
            var actual = File.ReadAllLines(path);

            for (int j = 0; j < datas.Count; j++)
                Assert.AreEqual(expected[j], actual[j]);
        }
    }
}