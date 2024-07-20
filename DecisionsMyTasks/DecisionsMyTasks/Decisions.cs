namespace DecisionsMyTasks
{
    /// <summary>
    /// Класс решений задач
    /// </summary>
    public class Decisions
    {
        public static T[][] TransposeJaggedArray<T>(T[][] JaggedArray)
        {

            return null;
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

            foreach (var x in JaggedArray)
            {
                foreach (var y in x) Console.Write($"{y} ");
                Console.WriteLine();
            }
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

            Dictionary<char, int> Roman = new Dictionary<char, int>()
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

            foreach (var x in line) result += Roman[x];

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
