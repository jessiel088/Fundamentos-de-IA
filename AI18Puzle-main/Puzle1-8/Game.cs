using System;
using System.Collections.Generic;
using System.Text;

namespace Puzle1_8
{
    class Game
    {
        public List<NodeNum> game = new List<NodeNum>();
        public List<Game> juego = new List<Game>();
        Random random = new Random();
        List<string> noUse = new List<string>();
        //public string[,] tablero = new string[3, 3]; matriz que decarte
        public string[] final = new string[9];
        int res = 0;
        public string[] Meta = { "1", "2", "3", "4", "5", "6", "7", "8", "0" };
        public int costFromRoot = 0;
        public int costHeuristic = 0;
        public int costTotalEstimated = 0;
        public void generateGame()
        {
            do
            {
                int randomNum = int.Parse(random.Next(1, 10).ToString());
                if (!noUse.Contains(randomNum.ToString()))
                {
                    NodeNum num = new NodeNum(randomNum.ToString());
                    game.Add(num);
                    noUse.Add(randomNum.ToString());
                }
            } while (game.Count != 9);
            do
            {
                res++;
                if (res == 9)
                {
                    final[res-1] = " ";
                }
                else
                {
                    final[res-1] = res.ToString();
                }
            } while (res != 9);
            for(int i = 0; i < game.Count; i++)
            {
                if (game[i].num == "9")
                {
                    game[i].num = " ";
                }
            }
            for(int i = 0; i < game.Count; i++)
            {
                Console.Write(game[i].num + " ");
            }
        }

        public void Pasos()
        {

        }

        
        public void SetPuzzle(string[] p)
        {
            for (int i = 0; i < final.GetLength(0); i++)
            {
                this.final[i] = p[i];
            }
        }

        public bool isSamePuzzle(string[] p)
        {
            bool isSamePuzzle = true;

             for (int i = 0; i < final.GetLength(0); i++)
            {
                this.final[i] = p[i];                
            }
            return isSamePuzzle;
        }

        public static int[] CopyPuzzle(int[] p)
        {
            int[] copy = new int[9];

            for (int i = 0; i < p.GetLength(0); i++)
            {
                    copy[i] = p[i];
            }
            return copy;
        }

        public bool GoalTest()
        {
            bool isGoal = true;

            for (int i = 0; i < final.GetLength(0); i++)
            {
                if (final[i] != Meta[i]) isGoal = false;
            }
            return isGoal;
        }
    }
}
