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

    static List<Data> Solve(long[][] dataAll)
    {
        List<Data> datas = new();
        for (int i = 0; i < dataAll.Length; i++)
            datas.Add(new Data());

        for (int i = 0; i < dataAll.Length; i++)
        {
            foreach (long item in dataAll[i])
            {
                datas[i].M += item;
                datas[i].D += item * item;
            }
            datas[i].M /= dataAll[i].Length;
            datas[i].D = datas[i].D / dataAll[i].Length - datas[i].M * datas[i].M;
        }
        return datas;
    }

    static void Main(string[] args)
    {

    }
}
