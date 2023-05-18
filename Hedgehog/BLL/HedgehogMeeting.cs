using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hedgehog.BLL
{
    public class HedgehogMeeting : IHedgehogMeeting
    {
        /// <summary>
        /// Вираховуємо кількість зустрічей
        /// </summary>
        /// <param name="needColor"></param>
        /// <param name="population"></param>
        /// <returns></returns>
        public int GetMinimumMeetings(int needColor, int[] population)
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
