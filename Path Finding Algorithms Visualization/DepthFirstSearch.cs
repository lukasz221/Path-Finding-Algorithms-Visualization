using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Path_Finding_Algorithms_Visualization
{
    internal class DepthFirstSearch
    {
        List<Tile> tilesList;
        List<Tile> stackTiles;
        List<Tile> visitedTiles;

        Tile finish;
        Tile start;

        public DepthFirstSearch()
        {
            tilesList = new List<Tile>();
            stackTiles = new List<Tile>();
            visitedTiles = new List<Tile>();
        }

        public void StartPathFindingDepthFirstSearch(List<Tile> listOfTiles, Tile start, Tile finish)
        {
            tilesList = listOfTiles;
            this.finish = finish;
            this.start = start;
            Tile currnet;
            stackTiles.Add(start);

            while (stackTiles.Any())
            {
                currnet = stackTiles.Last();
                currnet.SetActive();
                Thread.Sleep(30);
                if (currnet.IsVisited)
                {
                    stackTiles.RemoveAt(stackTiles.Count - 1);
                }
                Directions(currnet);
                currnet.SetVisited();
                if (currnet == finish)
                {
                    Path();
                    break;
                }
            }
        }

        private void Directions(Tile tile)
        {
            if (UpDir(tile) != null && UpDir(tile).IsVisited == false)
            {
                stackTiles.Add(UpDir(tile));
            }
            else if (RightDir(tile) != null && RightDir(tile).IsVisited == false)
            {
                stackTiles.Add(RightDir(tile));
            }
            else if (DownDir(tile) != null && DownDir(tile).IsVisited == false)
            {
                stackTiles.Add(DownDir(tile));
            }
            else if (LeftDir(tile) != null && LeftDir(tile).IsVisited == false)
            {
                stackTiles.Add(LeftDir(tile));
            }
            stackTiles.RemoveAll(tile => tile == null);
        }
        private void Path()
        {
            foreach (var item in stackTiles)
            {
                Thread.Sleep(20);
                item.SetPath();
            }
        }

        private Tile UpDir(Tile tile)
        {
            foreach (var item in tilesList.Where(i => i.Y + 1 == tile.Y && i.X == tile.X))
            {
                if (item.IsWalkable && !visitedTiles.Contains(item))
                {
                    return item;
                }
            }
            return null;
        }
        private Tile DownDir(Tile tile)
        {
            foreach (var item in tilesList.Where(i => i.Y - 1 == tile.Y && i.X == tile.X))
            {
                if (item.IsWalkable && !visitedTiles.Contains(item))
                {
                    return item;
                }
            }
            return null;
        }
        private Tile LeftDir(Tile tile)
        {
            foreach (var item in tilesList.Where(i => i.Y == tile.Y && i.X + 1 == tile.X))
            {
                if (item.IsWalkable && !visitedTiles.Contains(item))
                {
                    return item;
                }
            }
            return null;
        }
        private Tile RightDir(Tile tile)
        {
            foreach (var item in tilesList.Where(i => i.Y == tile.Y && i.X - 1 == tile.X))
            {
                if (item.IsWalkable && !visitedTiles.Contains(item))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
