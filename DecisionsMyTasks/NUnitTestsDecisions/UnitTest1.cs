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

            string[] arr = new string[] { "" };
            List<List<string>> expected = new List<List<string>>() { new List<string>() { "" } };
            List<List<string>> result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for (int i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);

            arr = new string[] { " " };
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
            expected = new List<List<string>>() { new List<string>() { "ate", "eat", "tea" }, new List<string>() { "nat", "tan" }, new List<string>() { "bat" } };
            result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for (int i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);

            arr = new string[] { "cat", "bat", "atb" };
            expected = new List<List<string>>() { new List<string>() { "cat" }, new List<string>() { "bat", "atb" } };
            result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for (int i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);

            arr = new string[] { "stars", "rats", "arts", "start" };
            expected = new List<List<string>>() { new List<string>() { "stars" }, new List<string>() { "rats", "arts" }, new List<string>() { "start" } };
            result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for (int i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);

            arr = new string[] { "rats", "arts" };
            expected = new List<List<string>>() { new List<string>() { "rats", "arts" } };
            result = GroupAnagrams(arr);

            Assert.That(expected.Count == result.Count);
            for (int i = 0; i < expected.Count; i++) CollectionAssert.AreEquivalent(expected[i], result[i]);
        }

        /// <summary>
        /// Тестирование IsEven() 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [TestCase(0, ExpectedResult = true)]
        [TestCase(2, ExpectedResult = true)]
        [TestCase(4, ExpectedResult = true)]
        [TestCase(6, ExpectedResult = true)]
        [TestCase(8, ExpectedResult = true)]
        [TestCase(10, ExpectedResult = true)]
        [TestCase(20, ExpectedResult = true)]
        [TestCase(22, ExpectedResult = true)]
        [TestCase(24, ExpectedResult = true)]
        [TestCase(40, ExpectedResult = true)]
        [TestCase(48, ExpectedResult = true)]
        [TestCase(50, ExpectedResult = true)]
        [TestCase(90, ExpectedResult = true)]
        [TestCase(96, ExpectedResult = true)]
        [TestCase(100, ExpectedResult = true)]
        [TestCase(1, ExpectedResult = false)]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(7, ExpectedResult = false)]
        [TestCase(9, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = false)]
        [TestCase(21, ExpectedResult = false)]
        [TestCase(23, ExpectedResult = false)]
        [TestCase(25, ExpectedResult = false)]
        [TestCase(39, ExpectedResult = false)]
        [TestCase(49, ExpectedResult = false)]
        [TestCase(51, ExpectedResult = false)]
        [TestCase(93, ExpectedResult = false)]
        [TestCase(99, ExpectedResult = false)]
        [TestCase(111, ExpectedResult = false)]
        [TestCase(-2, ExpectedResult = true)]
        [TestCase(-4, ExpectedResult = true)]
        [TestCase(-6, ExpectedResult = true)]
        [TestCase(-8, ExpectedResult = true)]
        [TestCase(-10, ExpectedResult = true)]
        [TestCase(-20, ExpectedResult = true)]
        [TestCase(-22, ExpectedResult = true)]
        [TestCase(-24, ExpectedResult = true)]
        [TestCase(-40, ExpectedResult = true)]
        [TestCase(-48, ExpectedResult = true)]
        [TestCase(-50, ExpectedResult = true)]
        [TestCase(-90, ExpectedResult = true)]
        [TestCase(-96, ExpectedResult = true)]
        [TestCase(-100, ExpectedResult = true)]
        [TestCase(-1, ExpectedResult = false)]
        [TestCase(-3, ExpectedResult = false)]
        [TestCase(-5, ExpectedResult = false)]
        [TestCase(-7, ExpectedResult = false)]
        [TestCase(-9, ExpectedResult = false)]
        [TestCase(-11, ExpectedResult = false)]
        [TestCase(-21, ExpectedResult = false)]
        [TestCase(-23, ExpectedResult = false)]
        [TestCase(-25, ExpectedResult = false)]
        [TestCase(-39, ExpectedResult = false)]
        [TestCase(-49, ExpectedResult = false)]
        [TestCase(-51, ExpectedResult = false)]
        [TestCase(-93, ExpectedResult = false)]
        [TestCase(-99, ExpectedResult = false)]
        [TestCase(-111, ExpectedResult = false)]
        public bool TestIsEven(int num) => IsEven(num);

        /// <summary>
        /// Тестирование IsOdd()
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [TestCase(0, ExpectedResult = false)]
        [TestCase(2, ExpectedResult = false)]
        [TestCase(4, ExpectedResult = false)]
        [TestCase(6, ExpectedResult = false)]
        [TestCase(8, ExpectedResult = false)]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(20, ExpectedResult = false)]
        [TestCase(22, ExpectedResult = false)]
        [TestCase(24, ExpectedResult = false)]
        [TestCase(40, ExpectedResult = false)]
        [TestCase(48, ExpectedResult = false)]
        [TestCase(50, ExpectedResult = false)]
        [TestCase(90, ExpectedResult = false)]
        [TestCase(96, ExpectedResult = false)]
        [TestCase(100, ExpectedResult = false)]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(3, ExpectedResult = true)]
        [TestCase(5, ExpectedResult = true)]
        [TestCase(7, ExpectedResult = true)]
        [TestCase(9, ExpectedResult = true)]
        [TestCase(11, ExpectedResult = true)]
        [TestCase(21, ExpectedResult = true)]
        [TestCase(23, ExpectedResult = true)]
        [TestCase(25, ExpectedResult = true)]
        [TestCase(39, ExpectedResult = true)]
        [TestCase(49, ExpectedResult = true)]
        [TestCase(51, ExpectedResult = true)]
        [TestCase(93, ExpectedResult = true)]
        [TestCase(99, ExpectedResult = true)]
        [TestCase(111, ExpectedResult = true)]
        [TestCase(-2, ExpectedResult = false)]
        [TestCase(-4, ExpectedResult = false)]
        [TestCase(-6, ExpectedResult = false)]
        [TestCase(-8, ExpectedResult = false)]
        [TestCase(-10, ExpectedResult = false)]
        [TestCase(-20, ExpectedResult = false)]
        [TestCase(-22, ExpectedResult = false)]
        [TestCase(-24, ExpectedResult = false)]
        [TestCase(-40, ExpectedResult = false)]
        [TestCase(-48, ExpectedResult = false)]
        [TestCase(-50, ExpectedResult = false)]
        [TestCase(-90, ExpectedResult = false)]
        [TestCase(-96, ExpectedResult = false)]
        [TestCase(-100, ExpectedResult = false)]
        [TestCase(-1, ExpectedResult = true)]
        [TestCase(-3, ExpectedResult = true)]
        [TestCase(-5, ExpectedResult = true)]
        [TestCase(-7, ExpectedResult = true)]
        [TestCase(-9, ExpectedResult = true)]
        [TestCase(-11, ExpectedResult = true)]
        [TestCase(-21, ExpectedResult = true)]
        [TestCase(-23, ExpectedResult = true)]
        [TestCase(-25, ExpectedResult = true)]
        [TestCase(-39, ExpectedResult = true)]
        [TestCase(-49, ExpectedResult = true)]
        [TestCase(-51, ExpectedResult = true)]
        [TestCase(-93, ExpectedResult = true)]
        [TestCase(-99, ExpectedResult = true)]
        [TestCase(-111, ExpectedResult = true)]
        public bool TestIsOdd(int num) => IsOdd(num);

        /// <summary>
        /// Тестирование JosephusOne()
        /// </summary>
        [Test]
        public void TestJosephusOne()
        {
            for (int i = 1; i <= 10; i++) Assert.That(JosephusOne(1, i), Is.EqualTo(1));

            for (int i = 1; i <= 10; i++) Assert.That(JosephusOne(i, 1), Is.EqualTo(i));

            for (int i = 2; i <= 10; i++) Assert.That(JosephusOne(2, i), Is.EqualTo(i % 2 + 1));

            Assert.That(JosephusOne(3, 2), Is.EqualTo(3));
            Assert.That(JosephusOne(3, 3), Is.EqualTo(2));
            Assert.That(JosephusOne(3, 4), Is.EqualTo(2));
            Assert.That(JosephusOne(3, 5), Is.EqualTo(1));
            Assert.That(JosephusOne(3, 6), Is.EqualTo(1));
            Assert.That(JosephusOne(3, 7), Is.EqualTo(3));
            Assert.That(JosephusOne(3, 8), Is.EqualTo(3));
            Assert.That(JosephusOne(3, 9), Is.EqualTo(2));
            Assert.That(JosephusOne(3, 10), Is.EqualTo(2));

            Assert.That(JosephusOne(4, 2), Is.EqualTo(1));
            Assert.That(JosephusOne(4, 3), Is.EqualTo(1));
            Assert.That(JosephusOne(4, 4), Is.EqualTo(2));
            Assert.That(JosephusOne(4, 5), Is.EqualTo(2));
            Assert.That(JosephusOne(4, 6), Is.EqualTo(3));
            Assert.That(JosephusOne(4, 7), Is.EqualTo(2));
            Assert.That(JosephusOne(4, 8), Is.EqualTo(3));
            Assert.That(JosephusOne(4, 9), Is.EqualTo(3));
            Assert.That(JosephusOne(4, 10), Is.EqualTo(4));

            Assert.That(JosephusOne(5, 2), Is.EqualTo(3));
            Assert.That(JosephusOne(5, 3), Is.EqualTo(4));
            Assert.That(JosephusOne(5, 4), Is.EqualTo(1));
            Assert.That(JosephusOne(5, 5), Is.EqualTo(2));
            Assert.That(JosephusOne(5, 6), Is.EqualTo(4));
            Assert.That(JosephusOne(5, 7), Is.EqualTo(4));
            Assert.That(JosephusOne(5, 8), Is.EqualTo(1));
            Assert.That(JosephusOne(5, 9), Is.EqualTo(2));
            Assert.That(JosephusOne(5, 10), Is.EqualTo(4));

            Assert.That(JosephusOne(6, 2), Is.EqualTo(5));
            Assert.That(JosephusOne(6, 3), Is.EqualTo(1));
            Assert.That(JosephusOne(6, 4), Is.EqualTo(5));
            Assert.That(JosephusOne(6, 5), Is.EqualTo(1));
            Assert.That(JosephusOne(6, 6), Is.EqualTo(4));
            Assert.That(JosephusOne(6, 7), Is.EqualTo(5));
            Assert.That(JosephusOne(6, 8), Is.EqualTo(3));
            Assert.That(JosephusOne(6, 9), Is.EqualTo(5));
            Assert.That(JosephusOne(6, 10), Is.EqualTo(2));

            Assert.That(JosephusOne(7, 2), Is.EqualTo(7));
            Assert.That(JosephusOne(7, 3), Is.EqualTo(4));
            Assert.That(JosephusOne(7, 4), Is.EqualTo(2));
            Assert.That(JosephusOne(7, 5), Is.EqualTo(6));
            Assert.That(JosephusOne(7, 6), Is.EqualTo(3));
            Assert.That(JosephusOne(7, 7), Is.EqualTo(5));
            Assert.That(JosephusOne(7, 8), Is.EqualTo(4));
            Assert.That(JosephusOne(7, 9), Is.EqualTo(7));
            Assert.That(JosephusOne(7, 10), Is.EqualTo(5));

            Assert.That(JosephusOne(8, 2), Is.EqualTo(1));
            Assert.That(JosephusOne(8, 3), Is.EqualTo(7));
            Assert.That(JosephusOne(8, 4), Is.EqualTo(6));
            Assert.That(JosephusOne(8, 5), Is.EqualTo(3));
            Assert.That(JosephusOne(8, 6), Is.EqualTo(1));
            Assert.That(JosephusOne(8, 7), Is.EqualTo(4));
            Assert.That(JosephusOne(8, 8), Is.EqualTo(4));
            Assert.That(JosephusOne(8, 9), Is.EqualTo(8));
            Assert.That(JosephusOne(8, 10), Is.EqualTo(7));

            Assert.That(JosephusOne(9, 2), Is.EqualTo(3));
            Assert.That(JosephusOne(9, 3), Is.EqualTo(1));
            Assert.That(JosephusOne(9, 4), Is.EqualTo(1));
            Assert.That(JosephusOne(9, 5), Is.EqualTo(8));
            Assert.That(JosephusOne(9, 6), Is.EqualTo(7));
            Assert.That(JosephusOne(9, 7), Is.EqualTo(2));
            Assert.That(JosephusOne(9, 8), Is.EqualTo(3));
            Assert.That(JosephusOne(9, 9), Is.EqualTo(8));
            Assert.That(JosephusOne(9, 10), Is.EqualTo(8));

            Assert.That(JosephusOne(10, 2), Is.EqualTo(5));
            Assert.That(JosephusOne(10, 3), Is.EqualTo(4));
            Assert.That(JosephusOne(10, 4), Is.EqualTo(5));
            Assert.That(JosephusOne(10, 5), Is.EqualTo(3));
            Assert.That(JosephusOne(10, 6), Is.EqualTo(3));
            Assert.That(JosephusOne(10, 7), Is.EqualTo(9));
            Assert.That(JosephusOne(10, 8), Is.EqualTo(1));
            Assert.That(JosephusOne(10, 9), Is.EqualTo(7));
            Assert.That(JosephusOne(10, 10), Is.EqualTo(8));

            for (int i = 0; i >= -10; i--) Assert.That(() => JosephusOne(1, i), Throws.TypeOf<ArgumentOutOfRangeException>());
            for (int i = 0; i >= -10; i--) Assert.That(() => JosephusOne(i, 1), Throws.TypeOf<ArgumentOutOfRangeException>());

        }

        /// <summary>
        /// Тестирование Transpose() для матриц
        /// </summary>
        [Test]
        public void TestTransposeForMatrix()
        {

            //Размер 1x1
            int[,] Matrix = new int[,] {
                {1 }
            };

            Transpose(Matrix);

            Assert.That(Matrix, Is.EqualTo(new int[,] {
                { 1 }}));

            //Размер 2x2
            Matrix = new int[,] {
                {1, 2 },
                {3, 4}
            };

            Transpose(Matrix);

            Assert.That(Matrix, Is.EqualTo(new int[,] {
                { 1, 3 },
                {2, 4 }}));

            //Размер 3x3
            Matrix = new int[,] {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }};

            Transpose(Matrix);

            Assert.That(Matrix, Is.EqualTo(new int[,] {
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 3, 6, 9 }}));

            //Размер 4x4
            Matrix = new int[,] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                {13, 14, 15, 16 }};

            Transpose(Matrix);

            Assert.That(Matrix, Is.EqualTo(new int[,] {
                { 1, 5, 9, 13 },
                { 2, 6, 10, 14 },
                { 3, 7, 11, 15 },
                {4, 8, 12, 16 }}));

            //Размер 5x5
            Matrix = new int[,] {
                {1, 2, 3, 4, 5 },
                {6, 7, 8, 9, 10 },
                {11, 12, 13, 14, 15 },
                {16, 17, 18, 19, 20 },
                {21, 22, 23, 24, 25 }};

            Transpose(Matrix);

            Assert.That(Matrix, Is.EqualTo(new int[,] {
                {1, 6, 11, 16, 21 },
                {2, 7, 12, 17, 22 },
                {3, 8, 13, 18, 23 },
                {4, 9, 14, 19, 24 },
                {5, 10, 15, 20, 25 }
            }));

            //Размер 0x0
            Assert.That(() => Transpose(new int[,] { }), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Матрица не квадратная
            Matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };

            Assert.That(() => Transpose(Matrix), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Матрица не квадратная
            Matrix = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };

            Assert.That(() => Transpose(Matrix), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Null
            Matrix = null;

            Assert.That(() => Transpose(Matrix), Throws.TypeOf<ArgumentNullException>());
        }
        /// <summary>
        /// Тестирование TransposeMatrix()
        /// </summary>
        [Test]
        public void TestTransposeMatrix()
        {
            //Размер 1x1
            Assert.That(TransposeMatrix(new int[,] { { 1 } }), Is.EqualTo(new int[,] { { 1 } }));
            //Размер 2x2
            Assert.That(TransposeMatrix(new int[,] { { 1, 2 }, { 3, 4 } }), Is.EqualTo(new int[,] { { 1, 3 }, { 2, 4 } }));
            //Размер 3x3
            Assert.That(TransposeMatrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }), Is.EqualTo(new int[,] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 } }));
            //Размер 4x4
            Assert.That(TransposeMatrix(new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } }), Is.EqualTo(new int[,] { { 1, 5, 9, 13 }, { 2, 6, 10, 14 }, { 3, 7, 11, 15 }, { 4, 8, 12, 16 } }));
            //Размер 5x5
            Assert.That(TransposeMatrix(new int[,] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } }), Is.EqualTo(new int[,] { { 1, 6, 11, 16, 21 }, { 2, 7, 12, 17, 22 }, { 3, 8, 13, 18, 23 }, { 4, 9, 14, 19, 24 }, { 5, 10, 15, 20, 25 } }));

            //Размер 1x2
            Assert.That(TransposeMatrix(new int[,] { { 1, 2 } }), Is.EqualTo(new int[,] { { 1 }, { 2 } }));
            //Размер 2x1
            Assert.That(TransposeMatrix(new int[,] { { 1 }, { 2 } }), Is.EqualTo(new int[,] { { 1, 2 } }));
            //Размер 1x3
            Assert.That(TransposeMatrix(new int[,] { { 1, 2, 3 } }), Is.EqualTo(new int[,] { { 1 }, { 2 }, { 3 } }));
            //Размер 3x1
            Assert.That(TransposeMatrix(new int[,] { { 1 }, { 2 }, { 3 } }), Is.EqualTo(new int[,] { { 1, 2, 3 } }));
            //Размер 2x3
            Assert.That(TransposeMatrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } }), Is.EqualTo(new int[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } }));
            //Размер 3x2
            Assert.That(TransposeMatrix(new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } }), Is.EqualTo(new int[,] { { 1, 3, 5 }, { 2, 4, 6 } }));

            //Размер 0x0
            Assert.That(() => TransposeMatrix(new int[,] { }), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Null
            int[,] Matrix = null;

            Assert.That(() => TransposeMatrix(Matrix), Throws.TypeOf<ArgumentNullException>());
        }
        /// <summary>
        /// Тестирование Transpose() для зубчатых массивов
        /// </summary>
        [Test]
        public void TestTransposeJaggedArray()
        {
            //Размер 1x1
            int[][] JaggedArray = new int[][] {
                new int[]{1}};

            Assert.That(TransposeJaggedArray(JaggedArray), Is.EqualTo(new int[][] {
                new int[]{1}}));

            //Размер 2x2
            JaggedArray = new int[][] {
                new int[]{1, 2}, 
                new int[]{3, 4 } };

            Assert.That(TransposeJaggedArray(JaggedArray), Is.EqualTo(new int[][] {
                new int[]{1, 3},
                new int[]{2, 4 } }));

            //Размер 3x3
            JaggedArray = new int[][] {
                new int[]{1, 2, 3},
                new int[]{4, 5, 6},
                new int[]{7, 8, 9}};

            Assert.That(TransposeJaggedArray(JaggedArray), Is.EqualTo(new int[][] {
                new int[]{1, 4, 7},
                new int[]{2, 5, 8},
                new int[]{3, 6, 9}}));

            //Размер 4x4
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4},
                new int[]{5, 6, 7, 8},
                new int[]{9, 10, 11, 12},
                new int[]{13, 14, 15, 16}};

            Assert.That(TransposeJaggedArray(JaggedArray), Is.EqualTo(new int[][] {
                new int[]{1, 5, 9, 13},
                new int[]{2, 6, 10, 14},
                new int[]{3, 7, 11, 15},
                new int[]{4, 8, 12, 16}}));

            //Размер 5x5
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4, 5},
                new int[]{6, 7, 8, 9, 10},
                new int[]{11, 12, 13, 14, 15},
                new int[]{16, 17, 18, 19, 20},
                new int[]{21, 22, 23, 24, 25 }};

            Assert.That(TransposeJaggedArray(JaggedArray), Is.EqualTo(new int[][] {
                new int[]{ 1, 6, 11, 16, 21 }, 
                new int[]{ 2, 7, 12, 17, 22 }, 
                new int[]{ 3, 8, 13, 18, 23 }, 
                new int[]{ 4, 9, 14, 19, 24 }, 
                new int[]{ 5, 10, 15, 20, 25 }}));

            //Размер 1x2
            JaggedArray = new int[][] {
                new int[]{1, 2}};

            Assert.That(TransposeJaggedArray(JaggedArray), Is.EqualTo(new int[][] {
                new int[]{1}, 
                new int[]{2 }}));

            //Размер 2x1
            JaggedArray = new int[][] {
                new int[]{1},
                new int[]{2 }};

            Assert.That(TransposeJaggedArray(JaggedArray), Is.EqualTo(new int[][] {
                new int[]{1, 2 }}));

            //Размер 1x3
            JaggedArray = new int[][] {
                new int[]{1, 2, 3 }};

            Assert.That(TransposeJaggedArray(JaggedArray), Is.EqualTo(new int[][] {
                new int[]{1},
                new int[]{2},
                new int[]{3}}));

            //Размер 3x1
            JaggedArray = new int[][] {
                new int[]{1},
                new int[]{2},
                new int[]{3}};

            Assert.That(TransposeJaggedArray(JaggedArray), Is.EqualTo(new int[][] {
                new int[]{1, 2, 3}}));

            //Размер 2x3
            JaggedArray = new int[][] {
                new int[]{1, 2, 3},
                new int[]{4, 5, 6}};

            Assert.That(TransposeJaggedArray(JaggedArray), Is.EqualTo(new int[][] {
                new int[]{1, 4},
                new int[]{2, 5},
                new int[]{3, 6}}));

            //Размер 3x2
            JaggedArray = new int[][] {
                new int[]{1, 2},
                new int[]{3, 4},
                new int[]{5, 6}};

            Assert.That(TransposeJaggedArray(JaggedArray), Is.EqualTo(new int[][] {
                new int[]{1, 3, 5},
                new int[]{2, 4, 6}}));

            //Размер 0x0
            Assert.That(() => TransposeJaggedArray(new int[][] { }), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Null
            JaggedArray = null;

            Assert.That(() => TransposeJaggedArray(JaggedArray), Throws.TypeOf<ArgumentNullException>());

        }

        /// <summary>
        /// Тестирование PascalTriangle()
        /// </summary>
        [Test]
        public void TestPascalTriangle()
        {
            Assert.That(PascalTriangle(1), Is.EqualTo(new int[][] {
                new int[] { 1 } }));
            Assert.That(PascalTriangle(2), Is.EqualTo(new int[][] { 
                new int[] { 1 },
                new int[]{1, 1}}));
            Assert.That(PascalTriangle(3), Is.EqualTo(new int[][] {
                new int[] { 1 },
                new int[]{1, 1},
                new int[]{1, 2, 1}}));
            Assert.That(PascalTriangle(4), Is.EqualTo(new int[][] {
                new int[] { 1 },
                new int[]{1, 1},
                new int[]{1, 2, 1},
                new int[]{1, 3, 3, 1}}));
            Assert.That(PascalTriangle(5), Is.EqualTo(new int[][] {
                new int[] { 1 },
                new int[]{1, 1},
                new int[]{1, 2, 1},
                new int[]{1, 3, 3, 1},
                new int[]{1, 4, 6, 4, 1}}));
            Assert.That(PascalTriangle(6), Is.EqualTo(new int[][] {
                new int[] { 1 },
                new int[]{1, 1},
                new int[]{1, 2, 1},
                new int[]{1, 3, 3, 1},
                new int[]{1, 4, 6, 4, 1},
                new int[]{1, 5, 10, 10, 5, 1}}));
            Assert.That(PascalTriangle(7), Is.EqualTo(new int[][] {
                new int[] { 1 },
                new int[]{1, 1},
                new int[]{1, 2, 1},
                new int[]{1, 3, 3, 1},
                new int[]{1, 4, 6, 4, 1},
                new int[]{1, 5, 10, 10, 5, 1},
                new int[]{1, 6, 15, 20, 15, 6, 1}}));
            Assert.That(PascalTriangle(8), Is.EqualTo(new int[][] {
                new int[] { 1 },
                new int[]{1, 1},
                new int[]{1, 2, 1},
                new int[]{1, 3, 3, 1},
                new int[]{1, 4, 6, 4, 1},
                new int[]{1, 5, 10, 10, 5, 1},
                new int[]{1, 6, 15, 20, 15, 6, 1},
                new int[]{1, 7, 21, 35, 35, 21, 7, 1}}));
            Assert.That(PascalTriangle(9), Is.EqualTo(new int[][] {
                new int[] { 1 },
                new int[]{1, 1},
                new int[]{1, 2, 1},
                new int[]{1, 3, 3, 1},
                new int[]{1, 4, 6, 4, 1},
                new int[]{1, 5, 10, 10, 5, 1},
                new int[]{1, 6, 15, 20, 15, 6, 1},
                new int[]{1, 7, 21, 35, 35, 21, 7, 1},
                new int[]{1, 8, 28, 56, 70, 56, 28, 8, 1}}));
            Assert.That(PascalTriangle(10), Is.EqualTo(new int[][] {
                new int[] { 1 },
                new int[]{1, 1},
                new int[]{1, 2, 1},
                new int[]{1, 3, 3, 1},
                new int[]{1, 4, 6, 4, 1},
                new int[]{1, 5, 10, 10, 5, 1},
                new int[]{1, 6, 15, 20, 15, 6, 1},
                new int[]{1, 7, 21, 35, 35, 21, 7, 1},
                new int[]{1, 8, 28, 56, 70, 56, 28, 8, 1},
                new int[]{1, 9, 36, 84, 126, 126, 84, 36, 9, 1}}));
            Assert.That(PascalTriangle(11), Is.EqualTo(new int[][] {
                new int[] { 1 },
                new int[]{1, 1},
                new int[]{1, 2, 1},
                new int[]{1, 3, 3, 1},
                new int[]{1, 4, 6, 4, 1},
                new int[]{1, 5, 10, 10, 5, 1},
                new int[]{1, 6, 15, 20, 15, 6, 1},
                new int[]{1, 7, 21, 35, 35, 21, 7, 1},
                new int[]{1, 8, 28, 56, 70, 56, 28, 8, 1},
                new int[]{1, 9, 36, 84, 126, 126, 84, 36, 9, 1},
                new int[]{1, 10, 45, 120, 210, 252, 210, 120, 45, 10, 1}}));
            Assert.That(PascalTriangle(12), Is.EqualTo(new int[][] {
                new int[] { 1 },
                new int[]{1, 1},
                new int[]{1, 2, 1},
                new int[]{1, 3, 3, 1},
                new int[]{1, 4, 6, 4, 1},
                new int[]{1, 5, 10, 10, 5, 1},
                new int[]{1, 6, 15, 20, 15, 6, 1},
                new int[]{1, 7, 21, 35, 35, 21, 7, 1},
                new int[]{1, 8, 28, 56, 70, 56, 28, 8, 1},
                new int[]{1, 9, 36, 84, 126, 126, 84, 36, 9, 1},
                new int[]{1, 10, 45, 120, 210, 252, 210, 120, 45, 10, 1},
                new int[]{1, 11, 55, 165, 330, 462, 462, 330, 165, 55, 11, 1}}));
            Assert.That(PascalTriangle(13), Is.EqualTo(new int[][] {
                new int[] { 1 },
                new int[]{1, 1},
                new int[]{1, 2, 1},
                new int[]{1, 3, 3, 1},
                new int[]{1, 4, 6, 4, 1},
                new int[]{1, 5, 10, 10, 5, 1},
                new int[]{1, 6, 15, 20, 15, 6, 1},
                new int[]{1, 7, 21, 35, 35, 21, 7, 1},
                new int[]{1, 8, 28, 56, 70, 56, 28, 8, 1},
                new int[]{1, 9, 36, 84, 126, 126, 84, 36, 9, 1},
                new int[]{1, 10, 45, 120, 210, 252, 210, 120, 45, 10, 1},
                new int[]{1, 11, 55, 165, 330, 462, 462, 330, 165, 55, 11, 1},
                new int[]{1, 12, 66, 220, 495, 792, 924, 792, 495, 220, 66, 12, 1}}));
            Assert.That(PascalTriangle(14), Is.EqualTo(new int[][] {
                new int[] { 1 },
                new int[]{1, 1},
                new int[]{1, 2, 1},
                new int[]{1, 3, 3, 1},
                new int[]{1, 4, 6, 4, 1},
                new int[]{1, 5, 10, 10, 5, 1},
                new int[]{1, 6, 15, 20, 15, 6, 1},
                new int[]{1, 7, 21, 35, 35, 21, 7, 1},
                new int[]{1, 8, 28, 56, 70, 56, 28, 8, 1},
                new int[]{1, 9, 36, 84, 126, 126, 84, 36, 9, 1},
                new int[]{1, 10, 45, 120, 210, 252, 210, 120, 45, 10, 1},
                new int[]{1, 11, 55, 165, 330, 462, 462, 330, 165, 55, 11, 1},
                new int[]{1, 12, 66, 220, 495, 792, 924, 792, 495, 220, 66, 12, 1},
                new int[]{1, 13, 78, 286, 715, 1287, 1716, 1716, 1287, 715, 286, 78, 13, 1}}));
            Assert.That(PascalTriangle(15), Is.EqualTo(new int[][] {
                new int[] { 1 },
                new int[]{1, 1},
                new int[]{1, 2, 1},
                new int[]{1, 3, 3, 1},
                new int[]{1, 4, 6, 4, 1},
                new int[]{1, 5, 10, 10, 5, 1},
                new int[]{1, 6, 15, 20, 15, 6, 1},
                new int[]{1, 7, 21, 35, 35, 21, 7, 1},
                new int[]{1, 8, 28, 56, 70, 56, 28, 8, 1},
                new int[]{1, 9, 36, 84, 126, 126, 84, 36, 9, 1},
                new int[]{1, 10, 45, 120, 210, 252, 210, 120, 45, 10, 1},
                new int[]{1, 11, 55, 165, 330, 462, 462, 330, 165, 55, 11, 1},
                new int[]{1, 12, 66, 220, 495, 792, 924, 792, 495, 220, 66, 12, 1},
                new int[]{1, 13, 78, 286, 715, 1287, 1716, 1716, 1287, 715, 286, 78, 13, 1},
                new int[]{1, 14, 91, 364, 1001, 2002, 3003, 3432, 3003, 2002, 1001, 364, 91, 14, 1}}));

            Assert.That(() => PascalTriangle(0), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-1), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-2), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-3), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-4), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-5), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-6), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-7), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-8), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-9), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-10), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-11), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-12), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-13), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => PascalTriangle(-14), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        /// <summary>
        /// Тестирование Rotate() для квадратных зубчатых массивов
        /// </summary>
        [Test]
        public void TestRotateForJaggedArray()
        {
            //Размер 1x1
            int[][] JaggedArray = new int[][] {
                new int[]{1}};

            Rotate(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{1}}));

            //Размер 2x2
            JaggedArray = new int[][] {
                new int[]{1, 2},
                new int[]{3, 4}};

            Rotate(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{3, 1},
                new int[]{4, 2}}));

            //Размер 3x3
            JaggedArray = new int[][] {
                new int[]{1, 2, 3},
                new int[]{4, 5, 6},
                new int[]{7, 8, 9}};

            Rotate(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{7, 4, 1},
                new int[]{8, 5, 2},
                new int[]{9, 6, 3}}));

            //Размер 4x4
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4},
                new int[]{5, 6, 7, 8},
                new int[]{9, 10, 11, 12},
                new int[]{13, 14, 15, 16}};

            Rotate(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{13, 9, 5, 1},
                new int[]{14, 10, 6, 2},
                new int[]{15, 11, 7, 3},
                new int[]{16, 12, 8, 4}}));

            //Размер 5x5
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4, 5 },
                new int[]{6, 7, 8, 9, 10 },
                new int[]{11, 12, 13, 14, 15 },
                new int[]{16, 17, 18, 19, 20 },
                new int[]{21, 22, 23, 24, 25 } };

            Rotate(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{21, 16, 11, 6, 1},
                new int[]{22, 17, 12, 7, 2},
                new int[]{23, 18, 13, 8, 3},
                new int[]{24, 19, 14, 9, 4},
                new int[]{25, 20, 15, 10, 5} }));

            //Размер 0x0
            JaggedArray = new int[][] {};

            Assert.That(() => Rotate(JaggedArray), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Null
            JaggedArray = null;

            Assert.That(() => Rotate(JaggedArray), Throws.TypeOf<ArgumentNullException>());
        }
        /// <summary>
        /// Тестирование Transpose() для квадратных зубчатых массивов
        /// </summary>
        [Test]
        public void TestTransposeForJaggedArray()
        {
            //Размер 1x1
            int[][] JaggedArray = new int[][] {
                new int[]{1}};

            Transpose(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{1}}));

            //Размер 2x2
            JaggedArray = new int[][] {
                new int[]{1, 2},
                new int[]{3, 4 } };

            Transpose(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{1, 3},
                new int[]{2, 4 }}));

            //Размер 3x3
            JaggedArray = new int[][] {
                new int[]{1, 2, 3},
                new int[]{4, 5, 6 },
                new int[]{7, 8, 9 } };

            Transpose(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{1, 4, 7},
                new int[]{2, 5, 8 },
                new int[]{3, 6, 9 } }));

            //Размер 4x4
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4},
                new int[]{5, 6, 7, 8},
                new int[]{9, 10, 11, 12},
                new int[]{13, 14, 15, 16}};

            Transpose(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{1, 5, 9, 13},
                new int[]{2, 6, 10, 14},
                new int[]{3, 7, 11, 15},
                new int[]{4, 8, 12, 16}}));

            //Размер 5x5
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4, 5},
                new int[]{6, 7, 8, 9, 10},
                new int[]{11, 12, 13, 14, 15},
                new int[]{16, 17, 18, 19, 20},
                new int[]{21, 22, 23, 24, 25 }};

            Transpose(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{ 1, 6, 11, 16, 21 },
                new int[]{ 2, 7, 12, 17, 22 },
                new int[]{ 3, 8, 13, 18, 23 },
                new int[]{ 4, 9, 14, 19, 24 },
                new int[]{ 5, 10, 15, 20, 25 }}));

            //Неквадратный зубчатый массив
            JaggedArray = new int[][] {
                new int[]{1, 2}};

            Assert.That(() => Transpose(JaggedArray), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Неквадратный зубчатый массив
            JaggedArray = new int[][] {
                new int[]{1, 2},
                new int[]{3}};

            Assert.That(() => Transpose(JaggedArray), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Неквадратный зубчатый массив
            JaggedArray = new int[][] {
                new int[]{1, 2},
                new int[]{3, 4, 5}};

            Assert.That(() => Transpose(JaggedArray), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Неквадратный зубчатый массив
            JaggedArray = new int[][] {
                new int[]{1},
                new int[]{2, 3, 4}};

            Assert.That(() => Transpose(JaggedArray), Throws.TypeOf<ArgumentOutOfRangeException>());

        }
        /// <summary>
        /// Тестирование SymCol()
        /// </summary>
        [Test]
        public void TestSymCol()
        {
            //Размер 1x1
            int[][] JaggedArray = new int[][] {
                new int[]{1}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{1}}));

            //Размер 2x1
            JaggedArray = new int[][] {
                new int[]{1},
                new int[]{2} };

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{1},
                new int[]{2}}));

            //Размер 3x1
            JaggedArray = new int[][] {
                new int[]{1},
                new int[]{2},
                new int[]{3}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{1},
                new int[]{2},
                new int[]{3}}));

            //Размер 4x1
            JaggedArray = new int[][] {
                new int[]{1},
                new int[]{2},
                new int[]{3},
                new int[]{4}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{1},
                new int[]{2},
                new int[]{3},
                new int[]{4}}));

            //Размер 5x1
            JaggedArray = new int[][] {
                new int[]{1},
                new int[]{2},
                new int[]{3},
                new int[]{4},
                new int[]{5}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{1},
                new int[]{2},
                new int[]{3},
                new int[]{4},
                new int[]{5}}));

            //Размер 1x2
            JaggedArray = new int[][] {
                new int[]{1, 2}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{2, 1}}));

            //Размер 1x3
            JaggedArray = new int[][] {
                new int[]{1, 2, 3}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{3, 2, 1}}));

            //Размер 1x4
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{4, 3, 2, 1}}));

            //Размер 1x5
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4, 5}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{5, 4, 3, 2, 1}}));

            //Размер 2x2
            JaggedArray = new int[][] {
                new int[]{1, 2},
                new int[]{3, 4}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{2, 1},
                new int[]{4, 3}}));

            //Размер 2x3
            JaggedArray = new int[][] {
                new int[]{1, 2, 3},
                new int[]{4, 5, 6}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{3, 2, 1},
                new int[]{6, 5, 4}}));

            //Размер 2x4
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4},
                new int[]{5, 6, 7, 8}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{4, 3, 2, 1},
                new int[]{8, 7, 6, 5}}));

            //Размер 2x5
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4, 5},
                new int[]{6, 7, 8, 9, 10}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{5, 4, 3, 2, 1},
                new int[]{10, 9, 8, 7, 6}}));

            //Размер 3x2
            JaggedArray = new int[][] {
                new int[]{1, 2},
                new int[]{3, 4},
                new int[]{5, 6}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{2, 1},
                new int[]{4, 3},
                new int[]{6, 5}}));

            //Размер 3x3
            JaggedArray = new int[][] {
                new int[]{1, 2, 3},
                new int[]{4, 5, 6},
                new int[]{7, 8, 9}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{3, 2, 1},
                new int[]{6, 5 , 4},
                new int[]{9, 8, 7}}));

            //Размер 3x4
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4},
                new int[]{5, 6, 7, 8},
                new int[]{9, 10, 11, 12}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{4, 3, 2, 1},
                new int[]{8, 7, 6, 5},
                new int[]{12, 11, 10, 9}}));

            //Размер 3x5
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4, 5},
                new int[]{6, 7, 8, 9, 10},
                new int[]{11, 12, 13, 14, 15}};

            SymCol(JaggedArray);

            Assert.That(JaggedArray, Is.EqualTo(new int[][] {
                new int[]{5, 4, 3, 2, 1},
                new int[]{10, 9, 8, 7, 6},
                new int[]{15, 14, 13, 12, 11}}));

            //Непрямоугольный зубчатый массив
            JaggedArray = new int[][] {
                new int[]{1, 2},
                new int[]{6, 7, 8, 9, 10},
                new int[]{11, 12, 13, 14, 15}};

            Assert.That(() => SymCol(JaggedArray), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Непрямоугольный зубчатый массив
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4, 5},
                new int[]{6, 7, 8, }};

            Assert.That(() => SymCol(JaggedArray), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Непрямоугольный зубчатый массив
            JaggedArray = new int[][] {
                new int[]{1},
                new int[]{6, 7}};

            Assert.That(() => SymCol(JaggedArray), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Непрямоугольный зубчатый массив
            JaggedArray = new int[][] {
                new int[]{1, 2, 3, 4, 5},
                new int[]{6, 7, 8, }};

            Assert.That(() => SymCol(JaggedArray), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Пустой зубчатый массив
            JaggedArray = new int[][] { };

            Assert.That(() => SymCol(JaggedArray), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Null
            JaggedArray = null;

            Assert.That(() => SymCol(JaggedArray), Throws.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Тестирование MaxArea()
        /// </summary>
        [Test]
        public void TestMaxArea()
        {
            Assert.That(MaxArea(new double[] { 1, 1 }), Is.EqualTo(1));

            Assert.That(MaxArea(new double[] { 1, 1, 3 }), Is.EqualTo(2));

            Assert.That(MaxArea(new double[] { 1, 5, 1 }), Is.EqualTo(2));

            Assert.That(MaxArea(new double[] { 5, 5, 1 }), Is.EqualTo(5));

            Assert.That(MaxArea(new double[] { 4, 5, 1, 10 }), Is.EqualTo(12));

            Assert.That(MaxArea(new double[] { 0, 7, 1, 5 }), Is.EqualTo(10));

            Assert.That(MaxArea(new double[] { 1, 3, 6, 5 }), Is.EqualTo(6));

            Assert.That(MaxArea(new double[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }), Is.EqualTo(49));

            Assert.That(MaxArea(new double[] { 1 }), Is.EqualTo(0));

            Assert.That(() => MaxArea(new double[] { }), Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => MaxArea(null), Throws.TypeOf<ArgumentNullException>());


        }
        /// <summary>
        /// Тестирование JosephusTwo()
        /// </summary>
        [Test]
        public void TestJosephusTwo()
        {
            for (int i = 1; i <= 10; i++) Assert.That(JosephusTwo(1, i), Is.EqualTo(1));

            for (int i = 1; i <= 10; i++) Assert.That(JosephusTwo(i, 1), Is.EqualTo(i));

            for (int i = 2; i <= 10; i++) Assert.That(JosephusTwo(2, i), Is.EqualTo(i % 2 + 1));

            Assert.That(JosephusTwo(3, 2), Is.EqualTo(3));
            Assert.That(JosephusTwo(3, 3), Is.EqualTo(2));
            Assert.That(JosephusTwo(3, 4), Is.EqualTo(2));
            Assert.That(JosephusTwo(3, 5), Is.EqualTo(1));
            Assert.That(JosephusTwo(3, 6), Is.EqualTo(1));
            Assert.That(JosephusTwo(3, 7), Is.EqualTo(3));
            Assert.That(JosephusTwo(3, 8), Is.EqualTo(3));
            Assert.That(JosephusTwo(3, 9), Is.EqualTo(2));
            Assert.That(JosephusTwo(3, 10), Is.EqualTo(2));

            Assert.That(JosephusTwo(4, 2), Is.EqualTo(1));
            Assert.That(JosephusTwo(4, 3), Is.EqualTo(1));
            Assert.That(JosephusTwo(4, 4), Is.EqualTo(2));
            Assert.That(JosephusTwo(4, 5), Is.EqualTo(2));
            Assert.That(JosephusTwo(4, 6), Is.EqualTo(3));
            Assert.That(JosephusTwo(4, 7), Is.EqualTo(2));
            Assert.That(JosephusTwo(4, 8), Is.EqualTo(3));
            Assert.That(JosephusTwo(4, 9), Is.EqualTo(3));
            Assert.That(JosephusTwo(4, 10), Is.EqualTo(4));

            Assert.That(JosephusTwo(5, 2), Is.EqualTo(3));
            Assert.That(JosephusTwo(5, 3), Is.EqualTo(4));
            Assert.That(JosephusTwo(5, 4), Is.EqualTo(1));
            Assert.That(JosephusTwo(5, 5), Is.EqualTo(2));
            Assert.That(JosephusTwo(5, 6), Is.EqualTo(4));
            Assert.That(JosephusTwo(5, 7), Is.EqualTo(4));
            Assert.That(JosephusTwo(5, 8), Is.EqualTo(1));
            Assert.That(JosephusTwo(5, 9), Is.EqualTo(2));
            Assert.That(JosephusTwo(5, 10), Is.EqualTo(4));

            Assert.That(JosephusTwo(6, 2), Is.EqualTo(5));
            Assert.That(JosephusTwo(6, 3), Is.EqualTo(1));
            Assert.That(JosephusTwo(6, 4), Is.EqualTo(5));
            Assert.That(JosephusTwo(6, 5), Is.EqualTo(1));
            Assert.That(JosephusTwo(6, 6), Is.EqualTo(4));
            Assert.That(JosephusTwo(6, 7), Is.EqualTo(5));
            Assert.That(JosephusTwo(6, 8), Is.EqualTo(3));
            Assert.That(JosephusTwo(6, 9), Is.EqualTo(5));
            Assert.That(JosephusTwo(6, 10), Is.EqualTo(2));

            Assert.That(JosephusTwo(7, 2), Is.EqualTo(7));
            Assert.That(JosephusTwo(7, 3), Is.EqualTo(4));
            Assert.That(JosephusTwo(7, 4), Is.EqualTo(2));
            Assert.That(JosephusTwo(7, 5), Is.EqualTo(6));
            Assert.That(JosephusTwo(7, 6), Is.EqualTo(3));
            Assert.That(JosephusTwo(7, 7), Is.EqualTo(5));
            Assert.That(JosephusTwo(7, 8), Is.EqualTo(4));
            Assert.That(JosephusTwo(7, 9), Is.EqualTo(7));
            Assert.That(JosephusTwo(7, 10), Is.EqualTo(5));

            Assert.That(JosephusTwo(8, 2), Is.EqualTo(1));
            Assert.That(JosephusTwo(8, 3), Is.EqualTo(7));
            Assert.That(JosephusTwo(8, 4), Is.EqualTo(6));
            Assert.That(JosephusTwo(8, 5), Is.EqualTo(3));
            Assert.That(JosephusTwo(8, 6), Is.EqualTo(1));
            Assert.That(JosephusTwo(8, 7), Is.EqualTo(4));
            Assert.That(JosephusTwo(8, 8), Is.EqualTo(4));
            Assert.That(JosephusTwo(8, 9), Is.EqualTo(8));
            Assert.That(JosephusTwo(8, 10), Is.EqualTo(7));

            Assert.That(JosephusTwo(9, 2), Is.EqualTo(3));
            Assert.That(JosephusTwo(9, 3), Is.EqualTo(1));
            Assert.That(JosephusTwo(9, 4), Is.EqualTo(1));
            Assert.That(JosephusTwo(9, 5), Is.EqualTo(8));
            Assert.That(JosephusTwo(9, 6), Is.EqualTo(7));
            Assert.That(JosephusTwo(9, 7), Is.EqualTo(2));
            Assert.That(JosephusTwo(9, 8), Is.EqualTo(3));
            Assert.That(JosephusTwo(9, 9), Is.EqualTo(8));
            Assert.That(JosephusTwo(9, 10), Is.EqualTo(8));

            Assert.That(JosephusTwo(10, 2), Is.EqualTo(5));
            Assert.That(JosephusTwo(10, 3), Is.EqualTo(4));
            Assert.That(JosephusTwo(10, 4), Is.EqualTo(5));
            Assert.That(JosephusTwo(10, 5), Is.EqualTo(3));
            Assert.That(JosephusTwo(10, 6), Is.EqualTo(3));
            Assert.That(JosephusTwo(10, 7), Is.EqualTo(9));
            Assert.That(JosephusTwo(10, 8), Is.EqualTo(1));
            Assert.That(JosephusTwo(10, 9), Is.EqualTo(7));
            Assert.That(JosephusTwo(10, 10), Is.EqualTo(8));

            for (int i = 0; i >= -10; i--) Assert.That(() => JosephusTwo(1, i), Throws.TypeOf<ArgumentOutOfRangeException>());
            for (int i = 0; i >= -10; i--) Assert.That(() => JosephusTwo(i, 1), Throws.TypeOf<ArgumentOutOfRangeException>());

        }
        /// <summary>
        /// Тестирование LongestCommonPrefix()
        /// </summary>
        [Test]
        public void TestLongestCommonPrefix()
        {
            string[] arr = new string[] { "flower", "flow", "flowers" };

            Assert.That(LongestCommonPrefix(null), Is.EqualTo("flow"));

            arr = new string[] { "flower", "flow", "flood", "fly" };

            Assert.That(LongestCommonPrefix(null), Is.EqualTo("fl"));

            arr = new string[] { "cupcake", "cup", "curr" };

            Assert.That(LongestCommonPrefix(null), Is.EqualTo("cu"));

            arr = new string[] { "cat", "can", "car", "cinema" };

            Assert.That(LongestCommonPrefix(null), Is.EqualTo("c"));

            arr = new string[] { "bat", "buy"};

            Assert.That(LongestCommonPrefix(null), Is.EqualTo("b"));

            arr = new string[] { "hello", "cat", "what", "tin" };

            Assert.That(LongestCommonPrefix(null), Is.EqualTo(""));

            arr = new string[] { "tin", "tab", "bat", "nit" };

            Assert.That(LongestCommonPrefix(null), Is.EqualTo(""));

            arr = new string[] { "what", "where", "who"};

            Assert.That(LongestCommonPrefix(null), Is.EqualTo("wh"));

            arr = new string[] { "hello" };

            Assert.That(LongestCommonPrefix(null), Is.EqualTo("hello"));

            arr = new string[] { "tea" };

            Assert.That(LongestCommonPrefix(null), Is.EqualTo("tea"));

            arr = new string[] { };

            Assert.That(() => LongestCommonPrefix(arr), Throws.TypeOf<ArgumentOutOfRangeException>());

            arr = null;

            Assert.That(() => LongestCommonPrefix(arr), Throws.TypeOf<ArgumentNullException>());

        }

    }
}