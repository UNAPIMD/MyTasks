using static DecisionsMyTasks.Decisions;
using System.Text.RegularExpressions;
using System.Text;

namespace DecisionsMyTasks
{
    class Program
    {
        /// <summary>
        /// Интерактивная часть проекта
        /// </summary>
        public static void Main()
        {
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
                [1] = "I",
            };
        }
    }
}