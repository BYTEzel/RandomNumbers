using System;
using System.Collections.Generic;

namespace RandomNumbers
{
    class Program
    {
        // Task 8
        public static int RandomInt(int lowerBorder, int upperBorder)
        {
            if (lowerBorder > upperBorder)
            {
                throw new ArgumentException("Lower border larger than upper border");
            }

            Random generator = new Random();
            
            // If something already exist in JAVA, use it
            // return generator.Next(lowerBorder, upperBorder);
            
            // Otherwise do it by hand
            double numberBetween0And1 = generator.NextDouble();
            int difference = upperBorder - lowerBorder;
            int numberInRange = (int)(numberBetween0And1 * difference);
            int numberInInterval = numberInRange + lowerBorder;
            return numberInInterval;
        }

        // Task 9
        public static int TryToRandomlyComputeNumber(int lowerBorder, int upperBorder, int desiredNumber)
        {
            if (desiredNumber < lowerBorder || desiredNumber > upperBorder)
            {
                throw new ArgumentException("Desired number is not inside the interval");
            }

            bool numberFound = false;
            int numberOfTries = 0;
            while (!numberFound)
            {
                var randomNumber = RandomInt(lowerBorder, upperBorder);
                if (randomNumber == desiredNumber)
                {
                    numberFound = true;
                }
                else
                {
                    numberOfTries++;
                }
            }
            Console.WriteLine("Es wurden " + numberOfTries + " Versuche benoetigt.");
            return numberOfTries;
        }

        // Task 10
        public static void MeanNumberOfTries(int numberOfRuns, int lowerBorder, int upperBorder, int desiredNumber)
        {
            List<int> numberOfTriesCollected = new List<int>();

            for (int i = 0; i < numberOfRuns; i++)
            {
                int numberOfTries = TryToRandomlyComputeNumber(lowerBorder, upperBorder, desiredNumber);
                numberOfTriesCollected.Add(numberOfTries);
            }

            double numberOfTriesAdded = 0;
            foreach (var numberOfTries in numberOfTriesCollected)
            {
                Console.Write(numberOfTries + " ");
                numberOfTriesAdded += numberOfTries;
            }
            double meanNumberOfTries = numberOfTriesAdded / numberOfTriesCollected.Count;
            Console.WriteLine();
            Console.Write("Durchschnittliche Anzahl Versuche: " + meanNumberOfTries);
        }

        static void Main(string[] args)
        {
            MeanNumberOfTries(9, 50, 100, 72);
        }
    }
}
