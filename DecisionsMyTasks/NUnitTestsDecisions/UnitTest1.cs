using static DecisionsMyTasks.Decisions;

namespace NUnitTestsDecisions
{
    /// <summary>
    /// Класс тестов решений задач
    /// </summary>
    public class TestsMyTasks
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// Тестирование Reverse()
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(123, ExpectedResult = 321)]
        [TestCase(1234, ExpectedResult = 4321)]
        [TestCase(-1, ExpectedResult = -1)]
        [TestCase(-12, ExpectedResult = -21)]
        [TestCase(-123, ExpectedResult = -321)]
        [TestCase(-1234, ExpectedResult = -4321)]
        [TestCase(10, ExpectedResult = 1)]
        [TestCase(120, ExpectedResult = 21)]
        [TestCase(1230, ExpectedResult = 321)]
        [TestCase(-10, ExpectedResult = -1)]
        [TestCase(-120, ExpectedResult = -21)]
        [TestCase(-1230, ExpectedResult = -321)]
        [TestCase(102, ExpectedResult = 201)]
        [TestCase(-102, ExpectedResult = -201)]
        [TestCase(1020, ExpectedResult = 201)]
        [TestCase(-1020, ExpectedResult = -201)]
        [TestCase(10203, ExpectedResult = 30201)]
        [TestCase(-10203, ExpectedResult = -30201)]
        [TestCase(Int32.MaxValue, ExpectedResult = 0)]
        [TestCase(Int32.MinValue, ExpectedResult = 0)]
        public int TestReverse(int num)
        {
            return Reverse(num);
        }
        [TestCase(0, ExpectedResult = true)]
        [TestCase(12, ExpectedResult = false)]
        [TestCase(123, ExpectedResult = false)]
        [TestCase(121, ExpectedResult = true)]
        [TestCase(323, ExpectedResult = true)]
        [TestCase(320, ExpectedResult = false)]
        [TestCase(102, ExpectedResult = false)]
        [TestCase(101, ExpectedResult = true)]
        [TestCase(100, ExpectedResult = false)]
        [TestCase(-2, ExpectedResult = false)]
        [TestCase(-28, ExpectedResult = false)]
        [TestCase(-9, ExpectedResult = false)]
        [TestCase(-95, ExpectedResult = false)]
        [TestCase(-808, ExpectedResult = false)]
        [TestCase(-801, ExpectedResult = false)]
        [TestCase(-900, ExpectedResult = false)]
        [TestCase(-330, ExpectedResult = false)]
        [TestCase(int.MaxValue, ExpectedResult = false)]
        [TestCase(int.MinValue, ExpectedResult = false)]
        public bool TestIsPalindrome(int num)
        {
            return IsPalindrome(num);
        }

        /// <summary>
        /// Тестирование RomanToInt()
        /// </summary>
        [Test]
        public void TestRomanToInt()
        {
            Assert.That(RomanToInt("I"), Is.EqualTo(1));
            Assert.That(RomanToInt("II"), Is.EqualTo(2));
            Assert.That(RomanToInt("III"), Is.EqualTo(3));
            Assert.That(RomanToInt("IV"), Is.EqualTo(4));
            Assert.That(RomanToInt("V"), Is.EqualTo(5));
            Assert.That(RomanToInt("VI"), Is.EqualTo(6));
            Assert.That(RomanToInt("VII"), Is.EqualTo(7));
            Assert.That(RomanToInt("VIII"), Is.EqualTo(8));
            Assert.That(RomanToInt("IX"), Is.EqualTo(9));
            Assert.That(RomanToInt("X"), Is.EqualTo(10));
            Assert.That(RomanToInt("XI"), Is.EqualTo(11));
            Assert.That(RomanToInt("XII"), Is.EqualTo(12));

            Assert.That(RomanToInt("XXXV"), Is.EqualTo(35));
            Assert.That(RomanToInt("XLIX"), Is.EqualTo(49));
            Assert.That(RomanToInt("LVIII"), Is.EqualTo(58));
            Assert.That(RomanToInt("LXXXI"), Is.EqualTo(81));
            Assert.That(RomanToInt("XCIX"), Is.EqualTo(99));
            Assert.That(RomanToInt("CXXIII"), Is.EqualTo(123));
            Assert.That(RomanToInt("CCC"), Is.EqualTo(300));
            Assert.That(RomanToInt("DLL"), Is.EqualTo(600)); //DLL
            Assert.That(RomanToInt("MCD"), Is.EqualTo(1400));
            Assert.That(RomanToInt("MCDVII"), Is.EqualTo(1407));
            Assert.That(RomanToInt("MDV"), Is.EqualTo(1505));
            Assert.That(RomanToInt("MDCCCXII"), Is.EqualTo(1812));
            Assert.That(RomanToInt("MCMV"), Is.EqualTo(1905));
            Assert.That(RomanToInt("MCMLXII"), Is.EqualTo(1962));
            Assert.That(RomanToInt("MCMXCIV"), Is.EqualTo(1994));
            Assert.That(RomanToInt("MMVII"), Is.EqualTo(2007));
            Assert.That(RomanToInt("MMXVII"), Is.EqualTo(2017));
            Assert.That(RomanToInt("MMXVII"), Is.EqualTo(2017));
            Assert.That(RomanToInt("MMMI"), Is.EqualTo(3001));
            Assert.That(RomanToInt("MMMLXXXII"), Is.EqualTo(3082));
            Assert.That(RomanToInt("MMMCDIX"), Is.EqualTo(3409));

            Assert.That(() => RomanToInt(""), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => RomanToInt(null), Throws.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Тестирование TwoSum()
        /// </summary>
        [Test]
        public void TestTwoSum()
        {
            int[] arr = new int[] { 1, 2, 3, 4 };
            Assert.That(TwoSum(arr, 3), Is.EqualTo((0, 1)));
            Assert.That(TwoSum(arr, 4), Is.EqualTo((0, 2)));
            Assert.That(TwoSum(arr, 6), Is.EqualTo((1, 3)));
            Assert.That(TwoSum(arr, 7), Is.EqualTo((2, 3)));

            Assert.That(TwoSum(arr, 0), Is.EqualTo((-1, -1)));
            Assert.That(TwoSum(arr, 8), Is.EqualTo((-1, -1)));

            arr = new int[] { 3, 2, 4 };
            Assert.That(TwoSum(arr, 6), Is.EqualTo((1, 2)));
            Assert.That(TwoSum(arr, 7), Is.EqualTo((0, 2)));

            Assert.That(TwoSum(arr, -1), Is.EqualTo((-1, -1)));
            Assert.That(TwoSum(arr, 10), Is.EqualTo((-1, -1)));

            arr = new int[] { 2, 7, 11, 15 };
            Assert.That(TwoSum(arr, 9), Is.EqualTo((0, 1)));
            Assert.That(TwoSum(arr, 18), Is.EqualTo((1, 2)));
            Assert.That(TwoSum(arr, 6), Is.EqualTo((-1, -1)));
            Assert.That(TwoSum(arr, 26), Is.EqualTo((2, 3)));

            Assert.That(TwoSum(arr, -3), Is.EqualTo((-1, -1)));
            Assert.That(TwoSum(arr, 3), Is.EqualTo((-1, -1)));

            arr = new int[] { 1 };
            Assert.That(() => TwoSum(arr, 1), Throws.TypeOf<ArgumentOutOfRangeException>());

            arr = new int[] { };
            Assert.That(() => TwoSum(arr, 0), Throws.TypeOf<ArgumentOutOfRangeException>());

            arr = null;
            Assert.That(() => TwoSum(arr, 4), Throws.TypeOf<ArgumentNullException>());

        }
        /// <summary>
        /// Тестирование MyPow()
        /// </summary>
        [Test]
        public void TestMyPow()
        {
            double eps = 1e-8; //Погрешность

            Assert.AreEqual(MyPow(2, 0), 1, eps);
            Assert.AreEqual(MyPow(2, 1), 2, eps);
            Assert.AreEqual(MyPow(2, 2), 4, eps);
            Assert.AreEqual(MyPow(2, 3), 8, eps);
            Assert.AreEqual(MyPow(2, 4), 16, eps);
            Assert.AreEqual(MyPow(2, 5), 32, eps);
            Assert.AreEqual(MyPow(2, 6), 64, eps);
            Assert.AreEqual(MyPow(2, 7), 128, eps);
            Assert.AreEqual(MyPow(2, 8), 256, eps);
            Assert.AreEqual(MyPow(2, 9), 512, eps);
            Assert.AreEqual(MyPow(2, 10), 1024, eps);

            Assert.AreEqual(MyPow(4, 3), 64, eps);
            Assert.AreEqual(MyPow(4, 4), 256, eps);

            Assert.AreEqual(MyPow(3, -1), 0.33333333, eps);
            Assert.AreEqual(MyPow(4, -1), 0.25, eps);
            Assert.AreEqual(MyPow(2, -1), 0.5, eps);
            Assert.AreEqual(MyPow(5, -1), 0.2, eps);
            Assert.AreEqual(MyPow(6, -1), 0.16666666, eps);
            Assert.AreEqual(MyPow(7, -1), 0.142857142857, eps);
            Assert.AreEqual(MyPow(8, -1), 0.125, eps);
            Assert.AreEqual(MyPow(9, -1), 0.11111111, eps);
            Assert.AreEqual(MyPow(10, -1), 0.1, eps);

            Assert.AreEqual(MyPow(0, 1), 0, eps);
            Assert.AreEqual(MyPow(0, 2), 0, eps);
            Assert.AreEqual(MyPow(0, 3), 0, eps);
            Assert.AreEqual(MyPow(0, 4), 0, eps);
            Assert.AreEqual(MyPow(0, 5), 0, eps);

            Assert.AreEqual(MyPow(1, 0), 1, eps);
            Assert.AreEqual(MyPow(1, 1), 1, eps);
            Assert.AreEqual(MyPow(1, 2), 1, eps);
            Assert.AreEqual(MyPow(1, 3), 1, eps);
            Assert.AreEqual(MyPow(1, 4), 1, eps);
            Assert.AreEqual(MyPow(1, 5), 1, eps);

            Assert.AreEqual(MyPow(10, 1), 10, eps);
            Assert.AreEqual(MyPow(10, 2), 100, eps);
            Assert.AreEqual(MyPow(10, 3), 1000, eps);
            Assert.AreEqual(MyPow(10, 4), 10000, eps);
            Assert.AreEqual(MyPow(10, 5), 100000, eps);

            Assert.AreEqual(MyPow(0.1, 1), 0.1, eps);
            Assert.AreEqual(MyPow(0.1, 2), 0.01, eps);
            Assert.AreEqual(MyPow(0.1, 3), 0.001, eps);
            Assert.AreEqual(MyPow(0.1, 4), 0.0001, eps);

            Assert.AreEqual(MyPow(0.5, 1), 0.5, eps);
            Assert.AreEqual(MyPow(0.5, 2), 0.25, eps);
            Assert.AreEqual(MyPow(0.5, 3), 0.125, eps);
            Assert.AreEqual(MyPow(0.5, 4), 0.0625, eps);

            Assert.AreEqual(MyPow(3.14, 1), 3.14, eps);
            Assert.AreEqual(MyPow(3.14, 2), 9.8596, eps);
            Assert.AreEqual(MyPow(3.14, 3), 30.959144, eps);
            Assert.AreEqual(MyPow(3.14, 4), 97.21171216, eps);

            Assert.AreEqual(MyPow(3.14, -1), 0.318471337579, eps);
            Assert.AreEqual(MyPow(3.14, -2), 0.101423992859, eps);
            Assert.AreEqual(MyPow(3.14, -3), 0.032300634668, eps);
            Assert.AreEqual(MyPow(3.14, -4), 0.010286826327, eps);

            Assert.AreEqual(MyPow(2.72, 1), 2.72, eps);
            Assert.AreEqual(MyPow(2.72, 2), 7.3984, eps);
            Assert.AreEqual(MyPow(2.72, 3), 20.123648, eps);
            Assert.AreEqual(MyPow(2.72, 4), 54.73632256, eps);

            Assert.AreEqual(MyPow(2.72, -1), 0.367647058823, eps);
            Assert.AreEqual(MyPow(2.72, -2), 0.135164359861, eps);
            Assert.AreEqual(MyPow(2.72, -3), 0.049692779360, eps);
            Assert.AreEqual(MyPow(2.72, -4), 0.018269404176, eps);
        }
        /// <summary>
        /// Тестирование Fibonachi()
        /// </summary>
        [Test]
        public void TestFibonachi()
        {
            Assert.That(Fibonachi(1), Is.EqualTo(1));
            Assert.That(Fibonachi(2), Is.EqualTo(1));
            Assert.That(Fibonachi(3), Is.EqualTo(2));
            Assert.That(Fibonachi(4), Is.EqualTo(3));
            Assert.That(Fibonachi(5), Is.EqualTo(5));
            Assert.That(Fibonachi(6), Is.EqualTo(8));
            Assert.That(Fibonachi(7), Is.EqualTo(13));
            Assert.That(Fibonachi(8), Is.EqualTo(21));
            Assert.That(Fibonachi(9), Is.EqualTo(34));
            Assert.That(Fibonachi(10), Is.EqualTo(55));
            Assert.That(Fibonachi(11), Is.EqualTo(89));
            Assert.That(Fibonachi(12), Is.EqualTo(144));
            Assert.That(Fibonachi(13), Is.EqualTo(233));
            Assert.That(Fibonachi(14), Is.EqualTo(377));
            Assert.That(Fibonachi(15), Is.EqualTo(610));
            Assert.That(Fibonachi(16), Is.EqualTo(987));
            Assert.That(Fibonachi(17), Is.EqualTo(1597));
            Assert.That(Fibonachi(18), Is.EqualTo(2584));
            Assert.That(Fibonachi(19), Is.EqualTo(4181));
            Assert.That(Fibonachi(20), Is.EqualTo(6765));

            Assert.That(() => Fibonachi(0), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => Fibonachi(-1), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => Fibonachi(-2), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => Fibonachi(-3), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => Fibonachi(-4), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => Fibonachi(-5), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        /// Тестирование GroupAnagram()
        /// </summary>
        [Test]
        public void TestGroupAnagrams()
        {
            Assert.That(() => GroupAnagrams(null), Throws.TypeOf<ArgumentNullException>());

            string[] arr = new string[]{""};
            List<List<string>> expected = new List<List<string>>() { new List<string>(){""} };
            List<List<string>> result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for(int  i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);

            arr = new string[]{ " " };
            expected = new List<List<string>>() { new List<string>() { " " } };
            result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for (int i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);

            arr = new string[] { "a" };
            expected = new List<List<string>>() { new List<string>() { "a" } };
            result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for (int i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);

            arr = new string[] { "ab" };
            expected = new List<List<string>>() { new List<string>() { "ab" } };
            result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for (int i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);

            arr = new string[] { "ab", "cd" };
            expected = new List<List<string>>() { new List<string>() { "ab" }, new List<string>() { "cd" } };
            result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for (int i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);

            arr = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            expected = new List<List<string>>() { new List<string>() { "ate", "eat", "tea" }, new List<string>() { "nat", "tan" }, new List<string>() { "bat" }};
            result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for (int i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);

            arr = new string[] { "cat", "bat", "atb"};
            expected = new List<List<string>>() { new List<string>() { "cat" }, new List<string>() { "bat", "atb" } };
            result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for (int i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);

            arr = new string[] { "stars", "rats", "arts", "start" };
            expected = new List<List<string>>() { new List<string>() { "stars" }, new List<string>() {"rats", "arts"  }, new List<string>() { "start" } };
            result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for (int i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);

            arr = new string[] { "rats", "arts" };
            expected = new List<List<string>>() { new List<string>() { "rats", "arts" }};
            result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for (int i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);
        }
    }
}