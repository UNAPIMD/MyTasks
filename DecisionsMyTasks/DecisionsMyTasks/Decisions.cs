namespace DecisionsMyTasks
{
    /// <summary>
    /// Класс решений задач
    /// </summary>
    public class Decisions
    {
        /// <summary>
        /// Возводит вещественное число в целочисленную степень
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double MyPow(double x, double n)
        {

            return -1;
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
            if (line.Length == 0) throw new ArgumentOutOfRangeException("Length of line is 0");

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

            foreach(var x in line) result += Roman[x];

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

            while(num != 0)
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
