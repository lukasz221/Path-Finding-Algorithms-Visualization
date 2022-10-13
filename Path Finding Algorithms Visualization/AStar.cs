using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Path_Finding_Algorithms_Visualization
{
    internal class AStar
    {
        List<Tile> tilesList;
        List<Tile> openList;
        List<Tile> closedList;
        List<Tile> neighbourList;

        Tile finish;
        Tile start;
        Tile shotest;

        bool finishFound = false;
        public AStar()
        {
            tilesList = new List<Tile>();
            closedList = new List<Tile>();
            openList = new List<Tile>();
            neighbourList = new List<Tile>();
        }

        public void StartPathFindingAStar(List<Tile> listOfTiles, Tile start, Tile finish)
        {
            tilesList = listOfTiles;
            this.finish = finish;
            this.start = start;
            Tile currnet;
            start.F = 0;

            openList.Add(start);

            while(openList.Any())
            {
                openList = openList.OrderBy(o => o.H).ToList();
                currnet = openList.First();

                for (int i = 1; i < openList.Count; i++)
                {
                    if (openList[i].F < currnet.F || openList[i].F == currnet.F)
                    {
                        if (openList[i].H < currnet.H)
                        {
                            currnet = openList[i];
                        }
                    }
                }

                openList.Remove(currnet);
                closedList.Add(currnet);

                if (currnet == finish)
                {
                    Debug.Write("done!");
                    RetracePath(start, finish);
                    return;
                }

                Directions(currnet);
                foreach (Tile neighbour in neighbourList)
                {
                    if (!currnet.IsWalkable || closedList.Contains(neighbour))
                    {
                        continue;
                    }
                    else
                    {
                        int newCostToNeighbour = currnet.G + GetDistance(currnet, neighbour);
                        if (newCostToNeighbour < neighbour.G || !openList.Contains(neighbour))
                        {
                            currnet.SetActive();
                            Thread.Sleep(20);
                            currnet.SetVisited();
                            neighbour.G = newCostToNeighbour;
                            neighbour.H = GetDistance(neighbour, finish);
                            neighbour.Parent = currnet;

                            if (!openList.Contains(neighbour))
                                openList.Add(neighbour);
                        }
                    }
                }
            }
        }

        void RetracePath(Tile startNode, Tile endNode)
        {
            List<Tile> path = new List<Tile>();
            Tile currentNode = endNode;

            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.Parent;
                Thread.Sleep(30);
                currentNode.SetPath();
            }
            path.Reverse();
        }

        int GetDistance(Tile nodeA, Tile nodeB)
        {
            int dstX = Math.Abs(nodeA.X - nodeB.X);
            int dstY = Math.Abs(nodeA.Y - nodeB.Y);

            if (dstX > dstY)
            {
                return 14 * dstY + 10 * (dstX - dstY);
            }
            return 14 * dstX + 10 * (dstY - dstX);
        }

        private void Directions(Tile tile)
        {
            neighbourList.Clear();
            neighbourList.Add(UpDir(tile));
            neighbourList.Add(RightDir(tile));
            neighbourList.Add(DownDir(tile));
            neighbourList.Add(LeftDir(tile));
            neighbourList.RemoveAll(tile => tile == null);
            neighbourList = neighbourList.OrderBy(o => o.H).ToList();
        }

        private Tile UpDir(Tile tile)
        {
            foreach (var item in tilesList.Where(i => i.Y + 1 == tile.Y && i.X == tile.X))
            {
                return item;
            }
            return null;
        }
        private Tile DownDir(Tile tile)
        {
            foreach (var item in tilesList.Where(i => i.Y - 1 == tile.Y && i.X == tile.X))
            {
                return item;
            }
            return null;
        }
        private Tile LeftDir(Tile tile)
        {
            foreach (var item in tilesList.Where(i => i.Y == tile.Y && i.X + 1 == tile.X))
            {
                return item;
            }
            return null;
        }
        private Tile RightDir(Tile tile)
        {
            foreach (var item in tilesList.Where(i => i.Y == tile.Y && i.X - 1 == tile.X))
            {
                return item;
            }
            return null;
        }
    }
}
