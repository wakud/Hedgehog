namespace Hedgehog.BLL.Tests
{
    [TestFixture]
    public class HedgehogMeetingTests
    {
        private HedgehogMeeting hedgehogMeeting;

        [SetUp]
        public void Setup()
        {
            hedgehogMeeting = new HedgehogMeeting();
        }

        /// <summary>
        /// ���������� ��������, ���� �� ��������� ���, � �������, �� ��������� ���� ������������ ����������.
        /// </summary>
        [Test]
        public void GetMinimumMeetings_WhenAllPopulationsEqual_ShouldReturnMaxPopulation()
        {
            // Arrange
            int needColor = GetRandomColor();
            int[] population = { 50, 50, 50 };

            // Act
            int result = hedgehogMeeting.GetMinimumMeetings(needColor, population);

            // Assert
            Assert.AreEqual(50, result);
        }

        /// <summary>
        /// ���������� ��������, ���� ��������� �� ������ ���� ��������������, � �������, �� ��������� ���� -1.
        /// </summary>
        [Test]
        public void GetMinimumMeetings_WhenPopulationsCannotBeBalanced_ShouldReturnMinusOne()
        {
            // Arrange
            int needColor = GetRandomColor();
            int[] population = { 10, 20, 30 };

            // Act
            int result = hedgehogMeeting.GetMinimumMeetings(needColor, population);

            // Assert
            Assert.AreEqual(-1, result);
        }

        /// <summary>
        /// ���������� ��������, ���� �� ���� �������� ����-���� �������� ���� � ����-��� ��������� ������, 
        /// � �������, �� ��������� ���� -1.
        /// </summary>
        [Test]
        public void GetMinimumMeetings_WhenPopulationsIsRandom_ShouldReturnMinusOne()
        {
            // Arrange
            int needColor = GetRandomColor();
            int[] population = GetRandomPopulation();

            // Act
            int result = hedgehogMeeting.GetMinimumMeetings(needColor, population);

            // Assert
            Assert.AreEqual(-1, result);
        }

        /// <summary>
        /// ���������� ��������, ���� ��������� ����-��, � �������, �� ��������� ���� ���������.
        /// </summary>
        [Test]
        public void GetMinimumMeetings_WithRandomPopulation_ShouldReturnCorrectResult()
        {
            // Arrange
            int needColor = GetRandomColor();
            int[] population = { 30, 20, 40 };

            // Act
            int expectedResult = GetExpectedResult(needColor, population);
            int result = hedgehogMeeting.GetMinimumMeetings(needColor, population);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// �������� ��������� ���� �� 0 �� 2
        /// </summary>
        /// <returns></returns>
        private int GetRandomColor()
        {
            return new Random().Next(0, 3);
        }

        /// <summary>
        /// �������� �������� ��������� �� 0 �� 100
        /// </summary>
        /// <returns></returns>
        private int[] GetRandomPopulation()
        {
            int[] population = new int[3];
            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                population[i] = random.Next(0, 101); 
            }

            return population;
        }

        /// <summary>
        /// ���������� �������� ���� �� ���� ������ ������� ��� � �������� ��������� ���������. //TDD
        /// </summary>
        /// <param name="needColor"></param>
        /// <param name="population"></param>
        /// <returns></returns>
        private int GetExpectedResult(int needColor, int[] population)
        {
            List<int> populationList = new List<int>(population);
            int countNeedColor = populationList[needColor];
            populationList.RemoveAt(needColor);

            if (population.Min() == 0 && population.Max() == 0)
            {
                return -1;
            }
            else if (populationList.Max() == populationList.Min())
            {
                return populationList.Max();
            }

            int attempts = 0;
            int maxPopulation = populationList.Max();
            int minPopulation = populationList.Min();

            while (countNeedColor >= 0)
            {
                if (maxPopulation != minPopulation)
                {
                    countNeedColor--;
                    maxPopulation--;
                    minPopulation += 2;
                    attempts++;
                }
                else
                {
                    return attempts + maxPopulation;
                }
            }

            return -1;
        }
    }
}
