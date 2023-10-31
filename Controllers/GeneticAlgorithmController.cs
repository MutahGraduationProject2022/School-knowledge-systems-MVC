using Microsoft.AspNetCore.Mvc;
using SKC_MVC.Models;

namespace SKC_MVC.Controllers
{
    public class GeneticAlgorithmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("genetic-algorithm/run")]
        public IActionResult RunGeneticAlgorithm()
        {
            // Define parameters here using comments to indicate data types

            // Number of new DNA individuals to introduce
            int numNewDNA = 10;

            // Flag to indicate whether to apply crossover on new DNA
            bool crossoverNewDNA = true;

            // Create instances of DNA and GeneticAlgorithm classes with appropriate parameters
            DNA<int> dna = new DNA<int>(
                /* rows: */ 5,
                /* random: */ new Random(),
                /* getListSize: */ row => 10,
                /* getRandomGene: */ row => 0,
                /* fitnessFunction: */ row => 0.0f);

            GeneticAlgorithm<int> geneticAlgorithm = new GeneticAlgorithm<int>(
                /* populationSize: */ 50,
                /* dnaSize: */ 5,
                /* getListSize: */ row => 10,
                /* random: */ new Random(),
                /* getRandomGene: */ row => 0,
                /* fitnessFunction: */ row => 0.0f,
                /* elitism: */ 10,
                /* mutationRate: */ 0.1f);

            // Run the genetic algorithm with the specified parameters
            geneticAlgorithm.NewGeneration(numNewDNA, crossoverNewDNA);

            // You can access the results and update your database or perform any other actions as needed
            // For example, access geneticAlgorithm.BestGenes, geneticAlgorithm.BestFitness, and other properties

            // Pass parameters and results to the view
            ViewData["numNewDNA"] = numNewDNA;
            ViewData["crossoverNewDNA"] = crossoverNewDNA;
            ViewData["BestFitness"] = geneticAlgorithm.BestFitness;
            ViewData["BestGenes"] = geneticAlgorithm.BestGenes;

            return View();
        }
    }
}
