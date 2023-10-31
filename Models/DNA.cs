namespace SKC_MVC.Models
{
    public class DNA<T>
    {
        public List<List<T>> Genes { get; private set; }
        public float Fitness { get; private set; }

        private Random random;
        private Func<int, T> getRandomGene;
        private Func<int, int> getListSize;
        private Func<int, float> fitnessFunction;

        T str;
        public DNA(int rows, Random random, Func<int, int> getListSize, Func<int, T> getRandomGene, Func<int, float> fitnessFunction, bool shouldInitGenes = true)
        {
            Genes = new List<List<T>>();

            for (int i = 0; i < rows; i++)
            {
                Genes.Add(new List<T>());
                if (!shouldInitGenes)
                    for (int j = 0; j < getListSize(i); j++)
                    {
                        Genes[i].Add(str);


                    }
            }
            this.random = random;
            this.getRandomGene = getRandomGene;
            this.fitnessFunction = fitnessFunction;
            this.getListSize = getListSize;

            if (shouldInitGenes)
            {
                for (int i = 0; i < Genes.Count; i++)
                {

                    for (int j = 0; j < getListSize(i); j++)
                    {

                        Genes[i].Add(getRandomGene(i));

                    }

                }

            }


        }

        public float CalculateFitness(int index)
        {
            Fitness = fitnessFunction(index);
            return Fitness;
        }

        public DNA<T> Crossover(DNA<T> otherParent)
        {
            DNA<T> child = new DNA<T>(Genes.Count, random, getListSize, getRandomGene, fitnessFunction, shouldInitGenes: false);

            for (int i = 0; i < Genes.Count; i++)
            {
                for (int j = 0; j < Genes[i].Count; j++)
                {

                    child.Genes[i][j] = random.NextDouble() < 0.5 ? Genes[i][j] : otherParent.Genes[i][j];

                }
            }

            return child;
        }

        public void Mutate(float mutationRate)
        {
            for (int i = 0; i < Genes.Count; i++)
            {
                for (int j = 0; j < getListSize(i); j++)
                    if (random.NextDouble() < mutationRate)
                    {

                        Genes[i][j] = getRandomGene(i);
                    }
            }
        }
    }
}
