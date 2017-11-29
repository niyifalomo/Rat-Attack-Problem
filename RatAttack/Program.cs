using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatAttack
{
    class Program
    {
        /*
         * Dynamic Programming Problem.
         * RAT ATTACK- 
         * http://uva.onlinejudge.org/index.php?option=com_onlinejudge&Itemid=8&category=362&page=show_problem&problem=1301
          */

        static void Main(string[] args)
        {
            //enstinguished rat populations
            int[,] entinguishedRatCounts = new int[1025, 1025];

            try
            {
                //Number of scenarios -test cases 
                int scenariosCount = Convert.ToInt32(Console.ReadLine());

                /*
                 * for each scenario, calculate the position (x,y) and sum of the rat poulation which will be extinguished
                 */

                while (scenariosCount > 0)
                {
                    //strength of gas bomb
                    int gasBombStrength = Convert.ToInt32(Console.ReadLine());    //d

                    //total rat population
                    int ratPopulationCount = Convert.ToInt32(Console.ReadLine());  //n

                    //initial position x and y and population size
                    int positionX = 0;
                    int positionY = 0;
                    int populationSize = 0;

                    //validateInput();

                    for (int i = 0; i < ratPopulationCount; i++)
                    {
                        string line = Console.ReadLine();

                        //Split line input into array - sample input  10 10 7
                        string[] values = line.Split(' ');

                        //get positions
                        positionX = Convert.ToInt32(values[0]);  //x
                        positionY = Convert.ToInt32(values[1]); //y
                        populationSize = Convert.ToInt32(values[2]);   // i

                        //Calculate min and max values of X & Y 
                        int minPositionX = Math.Max(0, positionX - gasBombStrength);
                        int maxPositionX = Math.Min(positionX + gasBombStrength, 1024);
                        int minPositionY = Math.Max(0, positionY - gasBombStrength);
                        int maxPositionY = Math.Min(positionY + gasBombStrength, 1024);

                        //Calculate the sum of rat populations that will be estinguished
                        for (int j = minPositionX; j <= maxPositionX; j++)
                        {
                            for (int k = minPositionY; k <= maxPositionY; k++)
                                entinguishedRatCounts[j, k] += populationSize;
                        }
                    }

                    //chosenX,chosenY --chosen location for the gas bomb.
                    //extinguishedRatsCount -number of rats that will be extinguished

                    int chosenX = 0, chosenY = 0, extinguishedRatsCount = -1;

                    //Get the maximum rat populationthat will be estinsguished
                    for (int l = 0; l < 1025; l++)
                    {
                        for (int m = 0; m < 1025; m++)
                        {
                            if (extinguishedRatsCount < entinguishedRatCounts[l, m])
                            {
                                chosenY = m;
                                chosenX = l;
                                extinguishedRatsCount = entinguishedRatCounts[l, m];

                            }
                        }
                    }

                    //Display output
                    Console.WriteLine("\nOUTPUT");
                    Console.WriteLine($"{chosenX} {chosenY} {extinguishedRatsCount}");

                }
            }
            catch (Exception ex)
            {
                Console.Write("An error occured....Ensure input data is valid");
            }

            Console.ReadLine();
        }

    }
}
