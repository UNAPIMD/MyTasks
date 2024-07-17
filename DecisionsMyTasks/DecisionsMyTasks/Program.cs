using static DecisionsMyTasks.Decisions;

namespace DecisionsMyTasks
{
    class Program
    {
        /// <summary>
        /// Интерактивная часть проекта
        /// </summary>
        public static void Main()
        {
            var res = TwoSum(new int[] { 3, 2, 4 }, 6);
            Console.Write($"{res.Item1} || {res.Item2}");
        }
    }
}