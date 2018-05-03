using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDemoGA
{
    public class Program
    {


        public static void Main(string[] args)
        {
            Random rn = new Random();

            Scheme demo = new Scheme();

            // Initialize population
            demo.population.InitializePopulation(10);

            // Calculate fitness of each individual
            demo.population.CalculateFitness();

            Console.WriteLine("Generation: " + demo.generationCount + " Fittest: " + demo.population.fittest);

            //While population gets an individual with maximum fitness
            while(demo.population.fittest < 5)
            {
                ++demo.generationCount;

                //Do selection
                demo.Selection();

                // Do crossover
                demo.Crossover();

                // Do mutation under a random probability
                if(rn.Next()%7 < 5)
                {
                    demo.Mutation();
                }

                // Add fittest offspring to population
                demo.AddFittestOffSpring();

                // Calculate new fitness value
                demo.population.CalculateFitness();

                Console.WriteLine("Generation: " + demo.generationCount + " Fittest: " + demo.population.fittest);
            }

            Console.WriteLine("\nSolution found in generation " + demo.generationCount);
            Console.WriteLine("Fitness: " + demo.population.GetFittest().fitness);
            Console.WriteLine("Genes: ");
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine(demo.population.GetFittest().genes[i]);
            }

            Console.ReadLine();
        }
    }
}
