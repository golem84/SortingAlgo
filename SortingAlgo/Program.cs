using System.Diagnostics;


internal class Program
{
    private static void Main(string[] args)
    {

        //Random rnd = new Random();
        // основной код 
        Console.WriteLine("Создаем и заполняем массивы...");

        int[] a = CreateArr(500);
        FillArray(ref a);

        int[] b = CreateArr(5000);
        FillArray(ref b);

        int[] c = CreateArr(50000);
        FillArray(ref c);

        Console.WriteLine("Массивы созданы и заполнены случайными числами. Нажмите любую клавишу для старта сортировок...");
        Console.ReadLine();


        MeasuringTime(ref a);
        MeasuringTime(ref b);
        MeasuringTime(ref c);
        Console.WriteLine("Нажмите любую клавишу...");
        Console.ReadKey();
    }


    public static void MeasuringTime(ref int[] m)
    {
        int[] copy1 = new int[m.Length];

        m.CopyTo(copy1, 0);


        Stopwatch timer = new Stopwatch();
        timer.Start();
        BubbleSort(ref m);
        timer.Stop();
        Console.WriteLine($"Время на сортировку массива из {m.Length} чисел методом пузырька составило {timer.ElapsedMilliseconds:#,##0} мс");

        timer.Reset();
        timer.Start();
        DivideSort(ref copy1, 0, copy1.Length - 1);
        timer.Stop();
        Console.WriteLine($"Время на сортировку массива из {copy1.Length} чисел быстрой сортировкой составило {timer.ElapsedMilliseconds:#,##0} мс");

    }

    // Метод для вывода чисел массива
    private static void PrintArr(ref int[] mas)
    {
        foreach (int a in mas)
        {
            Console.Write($"{a} ");
        }
        Console.WriteLine();
    }

    // Метод для создания массива заданной размерности
    private static int[] CreateArr(int n)
    {
        int[] mas = new int[n];
        return mas;
    }

    // метод заполнения массива случайными числами
    private static void FillArray(ref int[] mas)
    {
        Random rnd = new Random();
        int len = mas.Length;
        int a;
        for (int i = 0; i <= len - 1; i++)
        {
            a = rnd.Next(10000);
            mas[i] = a;
        }
    }

    private static void BubbleSort(ref int[] mas) // пузырьковая сортировка
    {
        int n = mas.Length;
        int t; //временная переменная для обмена
        //bool need = true;
        int s = 0;
        int k;
        do
        {
            k = 0;
            for (int i = 1; i <= n - 1; i++)
            {
                if (mas[i - 1] > mas[i])
                {
                    t = mas[i];
                    mas[i] = mas[i - 1];
                    mas[i - 1] = t;
                }
                else k++;

            }
            //PrintArr(ref mas);
            s++;
        }
        while (k < n - 1);
        //Console.WriteLine($"По массиву размерности {n} выполнено {s} проходов поиска и перестановки.");   


    }

    private static void DivideSort(ref int[] m, int nach, int kon)     // быстрая сортировка разделением массива на части
    {
        if (nach >= kon) return;
        int i = nach;
        int j = kon;
        int ser = (nach + kon) / 2;
        int tmp;
        while (i < j)
        {
            while (m[i] < m[ser]) i++;
            while (m[j] > m[ser]) j--;
            if (i <= j)
            {
                tmp = m[i];
                m[i] = m[j];
                m[j] = tmp;
                i++;
                j--;
            }
            DivideSort(ref m, ser, j);
            DivideSort(ref m, i, ser);

        }


    }
}