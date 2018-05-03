using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDemoGA
{
    class Individual
    {
        public int fitness = 0;
        public int[] genes = new int[5];
        public int geneLength = 5;

        public Individual()
        {
            Random rn = new Random();

            //Set genes randomly for each individual
            for(int i = 0; i < genes.Length; i++)
            {
                // Generates a random bit in each index.
                genes[i] = Math.Abs(rn.Next() % 2);
            }

            fitness = 0;
        }

        // Calculate fitness
        public void CalcFitness()
        {
            //The fitness increases for every single "1" in the array.
            fitness = 0;
            for(int i = 0; i < 5; i++)
            {
                if(genes[i] == 1)
                {
                    ++fitness;
                }
            }
        }
    }
}
