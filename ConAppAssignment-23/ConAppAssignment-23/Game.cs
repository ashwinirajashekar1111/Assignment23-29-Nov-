using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppAssignment_23
{
    public delegate void SpinEventHandler(int energyChange, int probabilityChange);
    class Game
    {
        private int energyLevel = 1;
        private int winningProbability = 100;
        private int spinCount = 0;

        public event SpinEventHandler SpinEvent;

        public void StartGame()
        {
            Console.WriteLine("Enter Your Name:");
            string playerName = Console.ReadLine();
            Console.WriteLine($"Hello {playerName}!");

            Console.WriteLine("Enter Your Lucky Number from 1 to 10:");
            int luckyNumber = int.Parse(Console.ReadLine());

            SpinEvent += SpinHandler;

            while (spinCount < 10)
            {
                Console.WriteLine($"Spin {spinCount + 1}:");
                int energyChange = spinCount + 1;
                int probabilityChange = (spinCount + 1) * 10;
                SpinEvent?.Invoke(energyChange, probabilityChange);

                Console.WriteLine($"Energy Level {energyLevel} - Winning Probability {winningProbability}");

                if (energyLevel >= 4 && winningProbability > 60)
                {
                    Console.WriteLine("Winner!");
                    return;
                }
                else if (energyLevel >= 1 && winningProbability > 50)
                {
                    Console.WriteLine("Runner Up!");
                    return;
                }

                spinCount++;
            }

            Console.WriteLine("Loser!");
        }

        private void SpinHandler(int energyChange, int probabilityChange)
        {
            energyLevel += energyChange;
            winningProbability += probabilityChange;


            energyLevel = Math.Max(1, energyLevel);
            winningProbability = Math.Max(0, winningProbability);
        }
    }
}



    
