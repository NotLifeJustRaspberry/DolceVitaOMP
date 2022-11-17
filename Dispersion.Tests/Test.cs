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
                new Data(),
                new Data()
            };
            expected[0].M = 57;
            expected[0].D = 1504;
            expected[1].M = 389;
            expected[1].D = 123924;
            ulong[][] data = new ulong[2][]
            {
                new ulong[] { 105, 10, 56 },
                new ulong[] { 56, 235, 876 }
            };
            List<Data> actual = Dispersion.Solve(data);

            for (int j = 0; j < expected.Count; j++)
            {
                Assert.AreEqual(expected[j].M, actual[j].M);
                Assert.AreEqual(expected[j].D, actual[j].D);
            }
        }

        [TestMethod]
        public void TestPrintFile()
        {
            string[] expected = new string[] { "57 1504", "389 123924" };
            string path = "test.cvc";
            List<Data> datas = new()
            {
                new Data(),
                new Data()
            };
            datas[0].M = 57;
            datas[0].D = 1504;
            datas[1].M = 389;
            datas[1].D = 123924;

            Dispersion.PrintFile(datas, path, " ");
            var actual = File.ReadAllLines(path);

            for (int j = 0; j < datas.Count; j++)
                Assert.AreEqual(expected[j], actual[j]);
        }
    }
}