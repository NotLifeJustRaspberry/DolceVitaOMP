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

    }
}