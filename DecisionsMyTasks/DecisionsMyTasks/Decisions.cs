using System.Text;

namespace DecisionsMyTasks
{
    /// <summary>
    /// Класс решений задач
    /// </summary>
    public class Decisions
    {
        /// <summary>
        /// Возвращает зигзагообразный формат строки (задача ZigZag Conversion)
        /// </summary>
        /// <param name="line"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string ZigZagConvert(string line, int N)
        {
            /*
             * Назовём "зигзагообразным циклом" единичный проход по зигзагообразной матрице сверзу вниз и обратно.
             * Число шагов, совершаемых при зигзагообразном цикле, равняется steps = 2*N-2.
             * Обозначим i - индекс рассматриваемого символа строки и зададим массив строк матрицы rows размером N
             * 
             * Введём характеристику position = i % steps.
             * Если position < N, то происходит спуск по матрице (rows[position] += line[i]), иначе - подъём (rows[steps - position] += line[i])
             * 
            */

            if (line == null) throw new ArgumentNullException("line is null");
            if (line.Length == 0) throw new ArgumentOutOfRangeException("line is empty");
            if (N <= 0) throw new ArgumentOutOfRangeException("N <= 0");

            if (N == 1 || N >= line.Length) return line;

            int steps = 2 * N - 2; //Число шагов зигзагообразного цикла
            StringBuilder[] rows = new StringBuilder[N]; //Массив строк зигзагообразной матрицы

            for(int i = 0; i < line.Length; i++)
            {
                int position = i % steps;

                if (position < N)
                {
                    if (rows[position] == null) rows[position] = new StringBuilder();

                    rows[position].Append(line[i]);
                }
                else rows[steps - position].Append(line[i]);
            }

            return rows.Aggregate((x, y) => x.Append(y)).ToString(); //Последовательное сложение всех строк зигзагообразной матрицы
        }

        /// <summary>
        /// Переводит число из десятичной системы счисления в римскую
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string IntToRoman(int value)
        {
            /*
             * Решение основано на введение словаря, хранящего пары вида (число, римская запись), благодаря которым можно перевести любое целое положительное число в римскую запись.
             * Пары должны храниться в обратном порядке: от большего числа к меньшему.
             * Искомый словарь имеет следующий состав:
             * [1000] = "M",
             * [900] = "CM",
             * [500] = "D",
             * [400] = "CD",
             * [100] = "C",
             * [90] = "XC",
             * [50] = "L",
             * [40] = "XL",
             * [10] = "X",
             * [9] = "IX",
             * [5] = "V",
             * [4] = "IV",
             * [1] = "I"
             * Такие пары, как [900] = "CM", [400] = "CD" и так далее, были добавлены, потому что римская запись не может содержать более трёх одинаковых знаков подряд.
             */

            if (value <= 0) throw new ArgumentOutOfRangeException("value <= 0");

            Dictionary<int, string> Alphabet = new Dictionary<int, string>()
            {
                [1000] = "M",
                [900] = "CM",
                [500] = "D",
                [400] = "CD",
                [100] = "C",
                [90] = "XC",
                [50] = "L",
                [40] = "XL",
                [10] = "X",
                [9] = "IX",
                [5] = "V",
                [4] = "IV",
                [1] = "I"
            };

            StringBuilder line = new StringBuilder();

            foreach(var x in Alphabet.Keys)
                while(value >= x)
                {
                    value -= x;
                    line.Append(Alphabet[x]);
                }

            return line.ToString();
        }


        /// <summary>
        /// Бинарный поиск элемента в отсортированном массиве
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Array"></param>
        /// <param name="Target"></param>
        /// <returns></returns>
        public static int BinarySearch<T>(T[] Array, T Target) where T : IComparable<T>
        {
            /*
             * Алгоритм основан на сравнении Target с элементом, стоящим посередине рассматриваемого промежутка отсортированного массива Array, и последовательном изменении границ этого промежутка
             * Асимптотическая сложность метода равна O(log n)
            */

            if (Array == null) throw new ArgumentNullException("Array is null");
            if (Array.Length == 0) throw new ArgumentOutOfRangeException("Array is empty");

            int left = 0; //Левая граница массива
            int right = Array.Length - 1; //Правая граница массива

            while(left <= right)
            {
                int mid = (left + right) / 2;

                if (Array[mid].CompareTo(Target) == 0) return mid;
                if (Array[mid].CompareTo(Target) < 0) left = mid + 1;
                else right = mid - 1;
            }

            return -1;
        }

        /// <summary>
        /// Задача о ханойский башнях
        /// </summary>
        /// <param name="N"></param>
        /// <param name="start"></param>
        /// <param name="work"></param>
        /// <param name="end"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Hanoi(int N, int start, int work, int end)
        {
            /*
             * Рассмотрим алгоритм переноса N дисков:
             * Пусть все диски расположены на start.
             * (1). Перенесём N-1 диски на work, используя end.
             * (2). Оставшийся диск переставим с start на end
             * (3). Переместим N-1 диски с work на end с помощью start
            */

            if (N < 0) throw new ArgumentOutOfRangeException("N < 0");

            if (N == 0) return;

            Hanoi(N - 1, start, end, work);
            Console.WriteLine($"{start} >>> {end}");
            Hanoi(N - 1, work, start, end);
        }

        /// <summary>
        /// Возвращает самую длинную строку общего префикса среди массива строк
        /// </summary>
        /// <param name="Array"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string LongestCommonPrefix(string[] Array)
        {
            /*
             * Будем сравнивать начальный элемент массива с остальными его компонентами до тех пор,
             * пока не выявится хотя бы одно несоответствие:
             * длина произвольного элемента меньше длины начального или символы одной позиции рассматриваемых строк не совпадают
            */

            if (Array == null) throw new ArgumentNullException("Array is null");
            if (Array.Length == 0) throw new ArgumentOutOfRangeException("Array is empty");

            if (Array.Length == 1) return Array[0];

            StringBuilder prefix = new StringBuilder();

            for (int i = 0; i < Array[0].Length; i++)
            {
                char symbol = Array[0][i];

                for (int j = 1; j < Array.Length; j++)
                    if (Array[j].Length == i || !Array[j][i].Equals(symbol)) return prefix.ToString();

                prefix.Append(symbol);
            }

            return prefix.ToString();
        }

        /// <summary>
        /// Задача Иосифа Флавия
        /// </summary>
        /// <param name="N"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public static int JosephusTwo(int N, int K)
        {
            /*
             * Запишем в линейный двусвязный список все N человек, указав их номера.
             * Будем постепенно переставлять элементы в начале списка в его конец, пока число компонентов ЛДС не будет равняться единице
             * Номера последнего оставшегося человека является ответом на данную задачу
            */

            if (N <= 0) throw new ArgumentOutOfRangeException("N <= 0");
            if (K <= 0) throw new ArgumentOutOfRangeException("K <= 0");

            if (N == 1) return 1;
            if (K == 1) return N;

            LinkedList<int> people = new LinkedList<int>();

            for (int i = 0; i < N; i++) people.AddLast(i + 1); //Заполнение списка людьми с указанием их номеров

            while (people.Count != 1)
            {
                int count = K - 1;
                while (count != 0)
                {
                    var human = people.First;

                    people.RemoveFirst();
                    people.AddLast(human);

                    count--;
                }

                people.RemoveFirst();
            }

            return people.First.Value;
        }

        /// <summary>
        /// Задача про контейнер с наибольшим количеством воды
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public static double MaxArea(double[] Heights)
        {

            /*
             * Одним из способов решения этой задачи является алгоритм с использованием двух циклов перебора всех элементов массива.
             * Это решение неэффективное, так как имеет асимптотическую сложность O(n^2).
             * 
             * Существует другой способ решить эту задачу:
             * Выберем контейнер с наибольшей шириной, у которого левая и правая сторона является нулевой и конечный элемент массива.
             * Будем постепенно перемещать границы одну за другой так, чтобы определить наибольшую площадь при уменьшении расстояния ширины контейнера, но при увеличения его высоты
             * Важно понимать, что перемещать сторону с самой большой высотой бессмысленно, поскольку высота хранимой воды ограничена стороной с наименьшей высотой.
             * В противном случае, площадь будет уменьшаться засчёт сужения расстояния между сторонами.
             * На каждом этапе будем вычислять текущую площадь. Когда стороны сойдутся, то алгоритм завершается.
             * Асимптотическая сложность этого решения равна O(n).
            */

            if (Heights == null) throw new ArgumentNullException("Heights is null");
            if (Heights.Length == 0) throw new ArgumentOutOfRangeException("Heights is empty");

            int left = 0; //Левая граница
            int right = Heights.Length - 1; //Правая граница
            double S = 0; //Искомый объём

            while (left < right)
            {
                S = Math.Max(S, Math.Min(Heights[left], Heights[right]) * (right - left));

                //Смешение границы с наименьшей высотой
                if (Heights[left] < Heights[right]) left++;
                else right--;
            }

            return S;
        }

        /// <summary>
        /// Меняет местами столбцы прямоугольного зубчатого массива
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="JaggedArray"></param>
        public static void SymCol<T>(T[][] JaggedArray)
        {
            if (JaggedArray == null) throw new ArgumentNullException("JaggedArray is null");
            if (JaggedArray.Length == 0) throw new ArgumentOutOfRangeException("JaggedArray is empty");

            int L = JaggedArray[0].Length;

            for (int i = 0; i < JaggedArray.Length; i++)
            {
                if (JaggedArray[i].Length != L) throw new ArgumentOutOfRangeException("JaggedArray isn't rectangular");

                for (int j = 0; j < L / 2; j++)
                    Swap(ref JaggedArray[i][j], ref JaggedArray[i][L - j - 1]);
            }
        }

        /// <summary>
        /// Поворачивает на 90 градусов квадратный зубчатый массив
        /// </summary>
        public static void Rotate<T>(T[][] JaggedArray)
        {
            //Чтобы повернуть на 90 градусов квадратный зубчатый массив, необходимо транспонировать его и поменять местами столбцы данного массива

            Transpose(JaggedArray); //Транспонирование
            SymCol(JaggedArray); //Поменять местами столбцы

        }

        /// <summary>
        /// Возвращает треугольник Паскаля
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int[][] PascalTriangle(int N)
        {
            /*
             * Для решения данной задачи представим треугольник Паскаля в виде ступенчатой матрицы,
             * у которой Matrix[i][j] = Matrix[i - 1][j] + Matrix[i - 1][j - 1], и Triangle[i][0] = 1, и Triangle[i][^1] = 1.
             * Асимптотическая сложность алгоритма равна O(n^2).
            */

            if (N <= 0) throw new ArgumentOutOfRangeException("N <= 0");

            int[][] Triangle = new int[N][];
            Triangle[0] = new int[] { 1 };

            for (int i = 1; i < N; i++)
            {
                Triangle[i] = new int[i + 1];
                Triangle[i][0] = 1;
                Triangle[i][^1] = 1;

                for (int j = 1; j < i; j++) Triangle[i][j] = Triangle[i - 1][j] + Triangle[i - 1][j - 1];
            }

            return Triangle;
        }
        /// <summary>
        /// Транспонирование квадратного зубчатого массива
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="JaggedArray"></param>
        public static void Transpose<T>(T[][] JaggedArray)
        {
            if (JaggedArray == null) throw new ArgumentNullException("JaggedArray is null");
            if (JaggedArray.Length == 0) throw new ArgumentOutOfRangeException("JaggedArray is empty");

            int N = JaggedArray.Length;

            for (int i = 0; i < N; i++)
            {
                if (JaggedArray[i].Length != N) throw new ArgumentOutOfRangeException("JaggedArray isn't square");

                for (int j = 0; j < i; j++) Swap(ref JaggedArray[i][j], ref JaggedArray[j][i]);
            }

        }
        /// <summary>
        /// Возвращает транспонированный исходный зубчатый массив
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="JaggedArray"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>

        public static T[][] TransposeJaggedArray<T>(T[][] JaggedArray)
        {
            if (JaggedArray == null) throw new ArgumentNullException("JaggedArray is null");
            if (JaggedArray.Length == 0) throw new ArgumentOutOfRangeException("JaggedArray is empty");

            (int N, int M) = (JaggedArray.Length, JaggedArray[0].Length);
            T[][] NewJaggedArray = new T[M][];

            for (int i = 0; i < M; i++)
            {
                NewJaggedArray[i] = new T[N];

                for (int j = 0; j < N; j++)
                    NewJaggedArray[i][j] = JaggedArray[j][i];
            }

            return NewJaggedArray;
        }

        /// <summary>
        /// Возвращает транспонированную исходную матрицу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Matrix"></param>
        /// <returns></returns>
        public static T[,] TransposeMatrix<T>(T[,] Matrix)
        {
            if (Matrix == null) throw new ArgumentNullException("Matrix is null");
            if (Matrix.Length == 0) throw new ArgumentOutOfRangeException("Matrix is empty");

            (int N, int M) = (Matrix.GetLength(0), Matrix.GetLength(1));
            T[,] NewMatrix = new T[M, N];

            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                    NewMatrix[i, j] = Matrix[j, i];

            return NewMatrix;
        }

        /// <summary>
        /// Транспонирование квадратной матрицы
        /// </summary>
        /// <param name="Matrix"></param>
        public static void Transpose<T>(T[,] Matrix)
        {
            if (Matrix == null) throw new ArgumentNullException("Matrix is null");
            if (Matrix.Length == 0) throw new ArgumentOutOfRangeException("Matrix is empty");
            if (Matrix.GetLength(0) != Matrix.GetLength(1)) throw new ArgumentOutOfRangeException("Matrix isn't square");


            for (int i = 0; i < Matrix.GetLength(0); i++)
                for (int j = 0; j < i; j++) //Матрица транспонируется относительно главной диагонали, поэтому j < i
                    Swap(ref Matrix[i, j], ref Matrix[j, i]);
        }

        /// <summary>
        /// Выводит в консоль матрицу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Matrix"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Print<T>(T[,] Matrix)
        {
            if (Matrix == null) throw new ArgumentNullException("Matrix is null");
            if (Matrix.Length == 0) throw new ArgumentOutOfRangeException("Matrix is empty");

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++) Console.Write($"{Matrix[i, j]} ");
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Выводит в консоль последовательность
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Array"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Print<T>(IEnumerable<T> Sequence)
        {
            if (Sequence == null) throw new ArgumentNullException("Array is null");
            if (Sequence.Count() == 0) throw new ArgumentOutOfRangeException("Length of Array is empty");

            foreach (var x in Sequence) Console.Write($"{x} ");
            Console.WriteLine();
        }

        /// <summary>
        /// Выводит в консоль зубчатый массив
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="JaggedArray"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Print<T>(T[][] JaggedArray)
        {
            if (JaggedArray == null) throw new ArgumentNullException("JaggedArray is null");
            if (JaggedArray.Length == 0) throw new ArgumentOutOfRangeException("Length of JaggedArray is empty");

            foreach (var x in JaggedArray) Print(x);
        }
        /// <summary>
        /// Задача Иосифа Флавия 
        /// </summary>
        /// <param name="N"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public static int JosephusOne(int N, int K)
        {
            /*
             * Решение основано на переборе и цикличном проходе по массиву длины N, 
             * где каждый элемент является живым (false) или мёртвым (true) человеком
             * Будем проходить по массиву до тех пор, пока количество живых людей не станет равным единице!
            */

            if (N <= 0) throw new ArgumentOutOfRangeException("N <= 0");
            if (K <= 0) throw new ArgumentOutOfRangeException("K <= 0");

            if (N == 1) return 1;
            if (K == 1) return N;

            bool[] people = new bool[N];
            int index = 0; //Индекс человека, с которого будет начинаться каждый проход по массиву

            while (N != 0)
            {
                int count = K - 1; //Число людей, которых необходимо оставить в живых на текущем проходе

                while (count > 0 || people[index])
                {
                    if (!people[index]) count--;

                    index = (index + 1) % people.Length; //Цикличный проход по массиву
                }

                people[index] = true; //Убиваем человека, на котором остановились в результате данного прохода по массиву
                N--;
            }

            return index + 1;
        }

        /// <summary>
        /// Проверяет, является ли число нечётным
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsOdd(int num) => num % 2 != 0;
        /// <summary>
        /// Проверяет, является ли число чётным
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEven(int num) => num % 2 == 0;

        /// <summary>
        /// Обменивает значения двух переменных
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap<T>(ref T a, ref T b)
        {
            var step = a;
            a = b;
            b = step;
        }
        /// <summary>
        /// Группирует все возможные анаграммы массива
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static List<List<string>> GroupAnagrams(string[] arr)
        {

            /* 
             * Для решения воспользуемся словарём, в котором ключом выступает шаблон (слово в отсортированном порядке), а ключом - слова, удовлетворяющие данному паттерну.
             * Отметим, что метод ContainsKey() имеет асимптотическую сложность O(1)
            */

            if (arr == null) throw new ArgumentNullException("arr is null");
            if (arr.Length == 0) throw new ArgumentOutOfRangeException("arr is empty");

            Dictionary<string, List<string>> kv = new Dictionary<string, List<string>>();

            foreach (var x in arr)
            {
                string line = string.Concat(x.OrderBy(c => c)); //Сортировка слова

                if (!kv.ContainsKey(line)) kv[line] = new List<string>();
                kv[line].Add(x);
            }

            return kv.Values.ToList();
        }
        /// <summary>
        /// Возвращает N-ое число последовательности Фибоначчи
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int Fibonachi(int N)
        {
            /*
             * Существует два способа решения этой задачи:
             * (1). Использовать формулу: F(n) = F(n-1) + F(n-2);
             * (2). Применить цикл;
             * (3). Использовать рекурсию с одним рекурсивным вызовом.
             * 
             * Первое способ крайне неэффективен из-за быстрого переполнения программного стека и лишних повторных рекурсивных вызовов
             * 
             * И второе, и третье решение хороши - воспользуемся последним.
            */

            if (N <= 0) throw new ArgumentOutOfRangeException("N <= 0");

            //Вспомогательный метод
            int FibonachiHelp(int N, int curr = 1, int prev = 1)
            {
                if (N == 1) return prev;
                return FibonachiHelp(N - 1, curr + prev, curr);

            }

            return FibonachiHelp(N);
        }
        /// <summary>
        /// Возводит вещественное число в целочисленную степень
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double MyPow(double x, double n)
        {
            /*
             * Рассмотрим два решения этой задачи:
             * (1). Использование цикла или рекурсии с постепенным уменьшением n на единицу;
             * (2). Использование рекурсии с проверкой чётности n.
             * 
             * В первом случае выполнение метода может занять слишком много времени, так как его асимптотическая сложность O(n)
             * У второго решения асимптотическая сложность O(log n), лучше его использовать
            */

            if (x == 0) return 0;
            if (x == 1 || n == 0) return 1;
            if (n < 0) return 1 / (x * MyPow(x, -n - 1)); //Запись 1/MyPow(x,n) не подходит при n = -2^31, так как будет переполнение программного стека из-за значения -n, превышающего Int32.MaxValue
            if (n % 2 != 0) return x * MyPow(x, n - 1);

            double step = MyPow(x, n / 2);

            return step * step;
        }

        /// <summary>
        /// Возвращает индексы двух элементов массива, сумма которых даёт значение target
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static (int, int) TwoSum(int[] nums, int target)
        {

            /*
             * Рассмотрим несколько способов решить задачу:
             * (1). Использование двух циклов для перебора всего массива;
             * (2). Применение "быстрой сортировки" массива и "бинарного поиска";
             * (3). Использование словаря, в котором хранится пара (элемент массива, его индекс в данном массиве) и метод ContainsKey() имеет асимптотическую сложность O(1)
             * 
             * Первый способ имеет асимптотическую сложность O(n ^ 2), что неэффективно.
             * Второй вариант работает с асимптотической сложность O(n*log n), а третий - O(n)
             * 
             * Лучше использовать последний способ.
            */

            if (nums == null) throw new ArgumentNullException("nums is null");
            if (nums.Length <= 1) throw new ArgumentOutOfRangeException("Length of nums <= 1");

            Dictionary<int, int> ValueIndex = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (ValueIndex.ContainsKey(target - nums[i]))
                {
                    if (i < ValueIndex[target - nums[i]]) return (i, ValueIndex[target - nums[i]]);
                    return (ValueIndex[target - nums[i]], i);
                }
                else ValueIndex[nums[i]] = i;
            }

            return (-1, -1);
        }

        /// <summary>
        /// Переводит число из римской системы счисления в десятичную
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int RomanToInt(string line)
        {
            /*
             * Для выполнения задачи необходимо в исходной строке выполнить следующие замены:
             * IV >>> IIII;
             * IX >>> VIIII;
             * XL >>> XXXX;
             * XC >>> LXXXX;
             * CD >>> CCCC;
             * CM >>> DCCCC;
             * 
             * Эти замены необходимы, чтобы избежать операции вычитания.
            */

            if (line == null) throw new ArgumentNullException("line is null");
            if (line.Length == 0) throw new ArgumentOutOfRangeException("line is empty");

            Dictionary<char, int> Alpabet = new Dictionary<char, int>()
            {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000,
            };

            line = line.Replace("IV", "IIII").Replace("IX", "VIIII").
                Replace("XL", "XXXX").Replace("XC", "LXXXX").
                Replace("CD", "CCCC").Replace("CM", "DCCCC");

            int result = 0;

            foreach (var x in line) result += Alpabet[x];

            return result;
        }

        /// <summary>
        /// Возвращает инвертированное исходное число
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int Reverse(int num)
        {
            int rev = 0;

            while (num != 0)
            {
                //Переменная rev проверяется непосредственно перед целочисленным переполнением, так как после всякие арифметические операции и сравнения бессмысленные
                if (rev > Int32.MaxValue / 10 || rev < Int32.MinValue / 10) return 0;

                rev = rev * 10 + num % 10;
                num = num / 10;
            }

            return rev;
        }
        /// <summary>
        /// Проверяет, является ли число палиндромом
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsPalindrome(int num)
        {
            /* Заметим, что всякое отрицательное число не является палиндромом.
             * 
             * Рассмотрим два способа решить данную задачу:
             * (1). Преобразовать число в строку и использовать или метод Reverse(), или срезы;
             * (2). Преобразовать число в строку и использовать рекурсию;
             * (3). Инвертировать данное число и сравнить его с исходным числом.
             * 
             * Первый и второй способы неэффективны ввиду преобразования числа в строку. Также метод имеет асимптотическую сложность O(n), где n - размер числа, и срезы требуют дополнительную память.
             * Таким образом, стоит использовать третий вариант.
            */

            return num >= 0 && Reverse(num) == num;
        }
    }
}
