using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDemoGA
{
    class Population
    {
        // NOTE: increase population 
        public int popSize = 10;
        public Individual[] individuals = new Individual[10];
        public int fittest = 0;

        // Initialize population
        public void InitializePopulation(int size)
        {
            for(int i = 0; i < individuals.Length; i++)
            {
                individuals[i] = new Individual();
            }
        }

        // Get the fittest individual
        public Individual GetFittest()
        {
            // initializing the maximum fit value.
            int maxFit = int.MinValue;
            int maxFitIndex = 0;
            for (int i = 0; i < individuals.Length; i++)
            {
                if (individuals[i].fitness >= maxFit)
                {
                    maxFit = individuals[i].fitness;
                    maxFitIndex = i;
                }
            }
            fittest = individuals[maxFitIndex].fitness;
            return individuals[maxFitIndex];
        }

        // Get the second most fit individual
        public Individual GetSecondFittest()
        {
            int maxFit1 = 0;
            int maxFit2 = 0;
            for (int i = 0; i < individuals.Length; i++)
            {
                if(individuals[i].fitness >= individuals[maxFit1].fitness)
                {
                    maxFit2 = maxFit1;
                    maxFit1 = i;
                } else if (individuals[i].fitness >= individuals[maxFit2].fitness)
                {
                    maxFit2 = i;
                }
            }
            return individuals[maxFit2];
        }

        // Get index of least fit individual
        public int GetLeastFittestIndex()
        {
            int minFitVal = int.MaxValue;
            int minFitIndex = 0;
            for(int i = 0; i < individuals.Length; i++)
            {
                if(minFitVal >= individuals[i].fitness)
                {
                    minFitVal = individuals[i].fitness;
                    minFitIndex = i;
                }
            }
            return minFitIndex;
        }

        // Calculate fitness of each individual
        public void CalculateFitness()
        {
            for(int i = 0; i < individuals.Length; i++)
            {
                individuals[i].CalcFitness();
            }
            GetFittest();
        }
    }
}
