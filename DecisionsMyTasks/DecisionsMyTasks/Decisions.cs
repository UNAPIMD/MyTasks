namespace DecisionsMyTasks
{
    /// <summary>
    /// Класс решений задач
    /// </summary>
    public class Decisions
    {
        /// <summary>
        /// Переводит число из римской системы счисления в десятичную
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
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
