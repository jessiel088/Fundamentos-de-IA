using System;
using System.Collections.Generic;
using System.Text;

namespace Puzle1_8
{
    class Aestrella
    {
        public List<Game> gam = new List<Game>();
        public List<Game> AStarSearch(Game root)
        {
            List<Game> PathToSolution = new List<Game>();
            Queue<int, Game> FrontierList = new Queue<int, Game>();
            List<Game> ExploredList = new List<Game>();
            int maxNumberOfFrontierList = 0;

            root.costHeuristic = getHeuristicCost(root);
            root.costTotalEstimated = root.costFromRoot + getHeuristicCost(root);
            FrontierList.Enqueue(getCostFromRoot(root) + root.costHeuristic, root);
            bool isGoalFound = false;

            while (FrontierList.Count() > 0 && !isGoalFound)
            {
                Game currentNode = FrontierList.Peek().Value;

                if (currentNode.Meta())
                {
                    Console.WriteLine("no se encontro la meta");
                    isGoalFound = true;
                    PathTrace(PathToSolution, currentNode);
                    Console.WriteLine("Expanded List's Count is " + ExploredList.Count());
                    Console.WriteLine("Maximum number stored in Frontier List is " + maxNumberOfFrontierList);
                    break;
                }

                ExploredList.Add(currentNode);
                if (maxNumberOfFrontierList < FrontierList.Count()) maxNumberOfFrontierList = FrontierList.Count();
                FrontierList.Dequeue();

                currentNode.ExpandNode();
                

                for (int i = 0; i < currentNode.game.Count; i++)
                {   
                    currentNode.juego[i].costFromRoot = getCostFromRoot(currentNode.game[i]);
                    currentNode.juego[i].costHeuristic = getHeuristicCost(currentNode.game[i]);
                    currentNode.juego[i].costTotalEstimated = currentNode.game[i].costFromRoot
                                                                + currentNode.game[i].costHeuristic;

                    if (!Contains(FrontierList, currentNode.game[i]) && !Contains(ExploredList, currentNode.game[i]))
                    {
                        FrontierList.Enqueue(currentNode.game[i].costTotalEstimated, currentNode.game[i]);
                    }
                    else if (Contains(FrontierList, currentNode.game[i]))
                    {
                        checkWhichHasHighCost(ref FrontierList, currentNode.game[i], "Heuristic");
                    }
                }
            }
            return PathToSolution;
        }

        public void PathTrace(List<Game> path, Game n)
        {
            Console.WriteLine("Tracing path..");
            NodeNum current = n;
            path.Add(current);

            while (current.num != null)
            {
                current = current.num;
                path.Add(current);
            }
        }

        public void checkWhichHasHighCost(ref Queue<int, Game> FrontierList, Game n, string nameOfCost)
        {
            int value = 0;

            if (nameOfCost.Equals("Uniform")) value = n.costFromRoot;
            else if (nameOfCost.Equals("Heuristic")) value = n.costHeuristic;

            Queue<int, Game> templateList = new Queue<int, Game>();
            List<Game> nodeList = FrontierList.getHeapVariables();
            List<int> costList = FrontierList.getHeapCosts();
            int index = 0;
            bool willChange = false;

            for (int i = 0; i < nodeList.Count(); i++)
            {
                if (nodeList[i].isSamePuzzle(n.final))
                {
                    if (value < costList[i])
                    {
                        willChange = true;
                        index = i;
                        break;
                    }
                }
            }

            if (willChange)
            {
                for (int i = 0; i < nodeList.Count(); i++)
                {
                    if (i != index) templateList.Enqueue(costList[i], nodeList[i]);
                }
                templateList.Enqueue(value, nodeList[nodeList.Count - 1]);

                FrontierList = templateList;
            }

        }

        public static bool Contains(List<Game> list, Game c)
        {
            bool contains = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].isSamePuzzle(c.final))
                    contains = true;
            }
            return contains;
        }

        public static bool Contains(Stack<Game> stack, Game c)
        {
            bool contains = false;
            Game[] template = new Game[stack.Count];

            stack.CopyTo(template, 0);

            for (int i = 0; i < stack.Count; i++)
            {
                if (template[i].isSamePuzzle(c.final))
                    contains = true;
            }
            return contains;
        }

        public static bool Contains(Queue<int, Game> list, Game c)
        {
            bool contains = false;

            List<Game> nodeList = list.getHeapVariables();

            for (int i = 0; i < list.Count(); i++)
            {
                if (nodeList[i].isSamePuzzle(c.))
                    contains = true;
            }
            return contains;
        }

        public static int getCostFromRoot(Game n)
        {
            Game current = n;
            List<Game> listUC = new List<Game>();
            listUC.Add(current);

            while (current.f != null)
            {
                current = current;
                listUC.Add(current);
            }
            return listUC.Count - 1;
        }

        public static int getHeuristicCost(Game n)
        {
            int heuristicValue = 0;

            int[] rowIndexes = { 2, 0, 0, 0, 1, 1, 1, 2, 2 };
            int[] columnIndexes = { 2, 0, 1, 2, 0, 1, 2, 0, 1 };

            for (int number = 1; number <= 8; number++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (n.game[i, j] == number)
                        {
                            heuristicValue += ManhattanDistance(i, rowIndexes[number], j, columnIndexes[number]);
                            i = j = 3;
                            break;
                        }

                    }
                }
            }

            return heuristicValue;
        }

        public static int ManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

    }
}
