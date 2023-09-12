class Program
{
    static void Main()
    {
        Random r = new Random();
        int n = 3, line = 0, line1 = 0, column = 0, mainDioganal = 0, secondaryDioganal = 0, number = 0;
        int[,] array = new int[n, n];
        while (true)
        {
            number++;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    array[i, j] = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    while (true)
                    {
                        array[i, j] = r.Next(1, 10);
                        if (i == 0 && j == 0)
                            break;
                        int k = 0;
                        for (int q = 0; q < n; q++)
                            for (int w = 0; w < n; w++)
                                if (array[q, w] == array[i, j])
                                    k++;
                        if (k == 1)
                            break;
                    }
            int p = 0;
            line1 = 0;
            for (int j = 0; j < n; j++)
                line1 += array[0, j];
            mainDioganal = 0;
            secondaryDioganal = 0;
            for (int i = 0; i < n; i++)
            {
                line = 0;
                column = 0;
                for (int j = 0; j < n; j++)
                {
                    line += array[i, j];
                    column += array[j, i];
                }
                if (line != line1 || column != line1)
                {
                    p = 1;
                    break;
                }
                mainDioganal += array[i, i];
                secondaryDioganal += array[i, n - 1 - i];
            }
            if (mainDioganal != line1 || secondaryDioganal != line1)
                p = 1;
            if (p == 1)
                continue;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("{0,3}", array[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine("  Магический квадрат был сгенерирован на {0}-й раз", number);
            break;
        }
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\n\tПовторить?(enter - Да, др.кл. + enter - НЕТ)\t\t");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        string proverka = Convert.ToString(Console.ReadLine());
        if (proverka == "")
            Main();
    }
}