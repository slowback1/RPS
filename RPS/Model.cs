using System;
using System.Threading;

namespace RPS
{
    class Model
    {
        public int userScore;
        public int opponentScore;
        public int roundsPlayed;
        public struct InputHistory
        {
            public int rock;
            public int paper;
            public int scissors;
            public InputHistory(int arock, int apaper, int ascissors)
            {
                rock = arock;
                paper = apaper;
                scissors = ascissors;
            }

        }
        public struct InputDifferences
        {
            public int rtop;
            public int rtos;
            public int ptos;
            public InputDifferences(int artop, int artos, int aptos)
            {
                rtop = artop;
                rtos = artos;
                ptos = aptos;
            }
        }
        public struct OInputWeights
        {
            public int rock;
            public int paper;
            public int scissors;
            public OInputWeights(int arock, int apaper, int ascissors)
            {
                rock = arock;
                paper = apaper;
                scissors = ascissors;
            }
        }
        InputHistory ihist;
        public Model()
        {
            userScore = 0;
            opponentScore = 0;
            roundsPlayed = 0;
            ihist = new InputHistory(0, 0, 0);
        }
        public double WeightFormula(int input)
        {
            return 0.005 * input * input * input;
        }
        public int SetInput(int input)
        {
            if (input < 13)
            {
                return 13;
            }
            else if (input > 73)
            {
                return 73;
            }
            else
            {
                return input;
            }
        }
        public InputDifferences SetDifferences(int rock, int paper, int scissors)
        {
            return new InputDifferences(rock - paper, rock - scissors, paper - scissors);
        }
        public OInputWeights SetWeights()
        {
            if (roundsPlayed > 10)
            {
                InputDifferences idiff = SetDifferences(
                    ihist.rock,
                    ihist.paper,
                    ihist.scissors);
                return new OInputWeights(
                    SetInput((int)(33 + WeightFormula(idiff.rtop) + WeightFormula(idiff.rtos))),
                    SetInput((int)(33 - WeightFormula(idiff.rtop) + WeightFormula(idiff.ptos))),
                    SetInput((int)(33 - WeightFormula(idiff.rtos) - WeightFormula(idiff.ptos))));

            }
            else
            {
                return new OInputWeights(33, 33, 33);
            }

        }
        public int SetOpposingRPS()
        {
            OInputWeights weights = SetWeights();
            Random rnd = new Random();
            int roll = rnd.Next(1,
                                weights.rock
                                + weights.paper
                                + weights.scissors
                                + 1);
            if (roll <= weights.rock)
            {
                Thread.Sleep(250);
                Console.WriteLine("I choose paper.");
                return 2;
            }
            else if (roll < weights.rock + weights.paper)
            {
                Thread.Sleep(250);
                Console.WriteLine("I choose scissors.");
                return 3;
            }
            else
            {
                Thread.Sleep(250);
                Console.WriteLine("I choose rock.");
                return 1;
            }
        }
        public bool UpdateScores(int result)
        {
            roundsPlayed += 1;
            if (result == 1)
            {
                userScore += 1;
            }
            else if (result == 0)
            {
                opponentScore += 1;
            }
            return true;
        }
        public bool UpdateInputHistory(int userInput)
        {
            switch (userInput)
            {
                case 1:
                    ihist.rock += 1;
                    break;
                case 2:
                    ihist.paper += 1;
                    break;
                case 3:
                    ihist.scissors += 1;
                    break;
                default:
                    throw new Exception();

            }
            return true;
        }

    }

}
