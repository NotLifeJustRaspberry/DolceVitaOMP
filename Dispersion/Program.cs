// Дисперсия
// Вам даётся файл с 3 миллионами строк и 10 столбцами. Написать программу, которая находит математическое ожидание и дисперсию величины в каждой строке.
// Протестировать на файле с не менее 4 строками, для которых известны значения математического ожидания и дисперсии в строках.
// Для распараллеливания использовать OpenMP, использовать весь ресурс параллелизма (параллелить, где можно) и оптимизации компилятора.
// Построить график зависимости ускорения по сравнению с 1 потоком и сравнить с линейным ускорением.

class Dispersion
{
    const int STRINGS = 100;
    const int COLS = 10;
    static void FillingCSV(int str, int cols)
    {
        Random r = new();
        StreamWriter sw = new StreamWriter("Input.csv");
        for (int i = 0; i < str; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sw.Write(r.Next(65536) - 32768 + ";");
            }
            sw.WriteLine();
        }
        sw.Close();
        Console.WriteLine("CSV Filled");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        FillingCSV(STRINGS, COLS);
    }
}
