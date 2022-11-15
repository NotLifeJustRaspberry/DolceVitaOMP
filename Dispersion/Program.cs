// Дисперсия
// Вам даётся файл с 3 миллионами строк и 10 столбцами. Написать программу, которая находит математическое ожидание и дисперсию величины в каждой строке.
// Протестировать на файле с не менее 4 строками, для которых известны значения математического ожидания и дисперсии в строках.
// Для распараллеливания использовать OpenMP, использовать весь ресурс параллелизма (параллелить, где можно) и оптимизации компилятора.
// Построить график зависимости ускорения по сравнению с 1 потоком и сравнить с линейным ускорением.

class Data
{
    public long M { get; set; } = 0;
    public long D { get; set; } = 0;
}

class Dispersion
{
    static string[] ReadFile(string path)
    {
        return File.ReadAllLines(path);
    }
    static long[][] SplitText(string[] text)
    {
        return text
                .Select(str => str.Split(' ')
                    .Where(str => str.Length > 0)
                        .Select(str => long.Parse(str))
                    .ToArray())
                .ToArray();
    }
    static void Main(string[] args)
    {

    }
}
