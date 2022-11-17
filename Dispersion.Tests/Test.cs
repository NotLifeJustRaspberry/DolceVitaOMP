using System;
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
                "� �������������, ��� ������� ��� ����� ����.",
                "� ����, ��� ������� �������� � ��� ������ ��������.",
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
                "� ����-�����������, ��������� � �������.",
                "��� ������ - ��� ����������� ����� ����.",
                "",
                "��� ������ - ��� ����� � ������ ��������,",
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
    }
}