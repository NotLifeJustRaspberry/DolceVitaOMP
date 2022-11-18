// Дисперсия
// Вам даётся файл с 3 миллионами строк и 10 столбцами. Написать программу, которая находит математическое ожидание и дисперсию величины в каждой строке.
// Протестировать на файле с не менее 4 строками, для которых известны значения математического ожидания и дисперсии в строках.
// Для распараллеливания использовать OpenMP, использовать весь ресурс параллелизма (параллелить, где можно) и оптимизации компилятора.
// Построить график зависимости ускорения по сравнению с 1 потоком и сравнить с линейным ускорением.

using System.Diagnostics;

namespace Dispersion;

public class Data
{
    public ulong M { get; set; } = 0;
    public ulong D { get; set; } = 0;
    public Data() { }
    public Data(ulong m, ulong d)
    {
        M = m;
        D = d;
    }
}

public class Dispersion
{
    public static string[] ReadFile(string path)
    {
        return File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>();
    }
    public static void PrintFile(List<Data> datas, string path, string separator = ";")
    {
        File.WriteAllLines(path, datas.Select(data => data.M + separator + data.D));
    }
    public static ulong[][] SplitText(string[] text)
    {
        return text
                .AsParallel()
                .Select(str => str.Split(' ')
                    .Where(str => str.Length > 0)
                        .Select(str => { ulong.TryParse(str, out ulong num); return num; })
                    .ToArray())
                .ToArray();
    }   

    public static List<Data> Solve(ulong[][] dataAll)
    {
        List<Data> datas = new();
        for (int i = 0; i < dataAll.Length; i++)
            datas.Add(new Data());

        Parallel.For(0, dataAll.Length, i =>
        {
            foreach (ulong item in dataAll[i])
            {
                datas[i].M += item;
                datas[i].D += item * item;
            }
            datas[i].M /= (ulong)dataAll[i].Length;
            datas[i].D = datas[i].D / (ulong)dataAll[i].Length - datas[i].M * datas[i].M;
        });
        return datas;
    }

    static void Main(string[] args)
    {
        string path = Directory.GetCurrentDirectory();

        Stopwatch stopwatch = new();
        stopwatch.Start();

        string[] datas = ReadFile(path + "\\minmax.txt");
        ulong[][] splitDatas = SplitText(datas);
        List<Data> solution = Solve(splitDatas);
        PrintFile(solution, path + "\\out.csv");

        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
    }
}
