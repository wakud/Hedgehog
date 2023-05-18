using System;
using System.Text;
using Hedgehog.BLL;

namespace Hedgehog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int desiredColor;
            int red, green, blue;

            // Зчитування бажаного колору
            while (true)
            {
                Console.Write("Введіть бажаний колір (0 - червоний, 1 - зелений, 2 - синій): ");
                if (int.TryParse(Console.ReadLine(), out desiredColor) && desiredColor >= 0 && desiredColor <= 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ви вибрали невірний колір. Спробуйте ще раз.");
                    Console.WriteLine();
                }

            }

            Console.WriteLine();

            // Зчитування початкової популяції їжачків
            red = ReadPopulation("червоних");
            green = ReadPopulation("зелених");
            blue = ReadPopulation("синіх");

            int[] population = { red, green, blue };

            IHedgehogMeeting hedgehogMeeting = new HedgehogMeeting();
            int minimumMeetings = hedgehogMeeting.GetMinimumMeetings(desiredColor, population);

            if (minimumMeetings > 0)
            {
                Console.WriteLine("Мінімальна кількість зустрічей, необхідних для зміни всіх їжачків у заданий колір: " + minimumMeetings);
            }
            else if (minimumMeetings == 0)
            {
                Console.WriteLine("Мінімальна кількість зустрічей: " + minimumMeetings + ". Всі їжачки одного кольору.");
            }
            else
            {
                Console.WriteLine("Це неможливо " + minimumMeetings);
            }

            Console.ReadLine();
        }

        static int ReadPopulation(string colorName)
        {
            while (true)
            {
                Console.Write($"Введіть кількість {colorName} їжачків: ");
                if (int.TryParse(Console.ReadLine(), out int population) && population >= 0 && population <= int.MaxValue)
                {
                    return population;
                }
                else
                {
                    Console.WriteLine("Ви ввели невірну кількість. Спробуйте ще раз.");
                }
            }
        }
    }
}
