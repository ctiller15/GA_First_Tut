using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDemoGA
{
    class Scheme
    {
        public Population population = new Population();
        public Individual fittest;
        public Individual secondFittest;
        public int generationCount = 0;

        // Selection
        public void Selection()
        {

            // Select the most fit individual
            fittest = population.GetFittest();

            //Select the second fittest individual
            secondFittest = population.GetSecondFittest();
        }

        // Crossover
        public void Crossover()
        {
            Random rn = new Random();

            // Select a random crossover point
            int crossOverPoint = rn.Next(population.individuals[0].geneLength);

            //Swap values among parents
            for (int i = 0; i < crossOverPoint; i++)
            {
                int temp = fittest.genes[i];
                fittest.genes[i] = secondFittest.genes[i];
                secondFittest.genes[i] = temp;
            }
        }

        //Mutation
        public void Mutation()
        {
            Random rn = new Random();

            //Select a random mutation point
            int mutationPoint = rn.Next(population.individuals[0].geneLength);

            //Flip values at the mutation point
            if(fittest.genes[mutationPoint] == 0)
            {
                fittest.genes[mutationPoint] = 1;
            } else
            {
                fittest.genes[mutationPoint] = 0;
            }
        }

        //Get fittest offspring
        public Individual GetFittestOffspring()
        {
            if (fittest.fitness > secondFittest.fitness)
            {
                return fittest;
            }
            return secondFittest;
        }

        //Replace least fittest individual from most fittest offspring
        public void AddFittestOffSpring()
        {
            // Update fitness values of offspring
            fittest.CalcFitness();
            secondFittest.CalcFitness();

            //Get index of least fit individual
            int leastFittestIndex = population.GetLeastFittestIndex();

            // Replace least fittest individual with most fittest offspring
            population.individuals[leastFittestIndex] = GetFittestOffspring();
        }
    }
}
