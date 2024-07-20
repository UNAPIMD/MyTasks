using static DecisionsMyTasks.Decisions;
using System.Text.RegularExpressions;

namespace DecisionsMyTasks
{
    class Program
    {
        /// <summary>
        /// Интерактивная часть проекта
        /// </summary>
        public static void Main()
        {
            Transpose(new int[][] {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }});
        }
    }
}