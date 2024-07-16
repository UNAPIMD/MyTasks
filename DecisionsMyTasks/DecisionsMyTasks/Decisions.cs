namespace DecisionsMyTasks
{
    /// <summary>
    /// Класс решений задач
    /// </summary>
    public class Decisions
    {
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
                //Переменная rev проверяется непосредственно перед переполнением программного стека, так как после всякие арифметические операции и сравнения бессмысленные
                if (rev > Int32.MaxValue / 10 || rev < Int32.MinValue / 10) return 0;

                rev = rev * 10 + num % 10;
                num = num / 10;
            }

            return rev;
        }
    }
}
