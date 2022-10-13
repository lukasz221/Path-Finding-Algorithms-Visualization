using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Path_Finding_Algorithms_Visualization
{
    internal class Dijkstra
    {
        List<Tile> tilesList;
        List<Tile> activeTiles;
        List<Tile> visitedTiles;
        
        Tile finish;
        Tile start;
        bool finishFound = false;
        public Dijkstra()
        {
            tilesList = new List<Tile>();
            visitedTiles = new List<Tile>();
            activeTiles = new List<Tile>();
        }

        public void StartPathFindingDijkstra(List<Tile> listOfTiles, Tile start, Tile finish)
        {
            tilesList = listOfTiles;
            this.finish = finish;
            this.start = start;

            activeTiles.Add(start);
            var timer = new Stopwatch();
            start.Parent = null;
            timer.Start();
            while (activeTiles.Any())
            {
                var main = activeTiles.First();

                Directions(main);
                activeTiles.Remove(main);
            }
            if (finishFound)
            {
                Path(finish);
            }
            else
            {
                Debug.WriteLine("No Way Found!");
            }
            timer.Stop(); 
            Debug.Write(timer.ElapsedMilliseconds.ToString());
        }

        private void Directions(Tile tile)
        {
            activeTiles.Add(UpDir(tile));
            activeTiles.Add(RightDir(tile));
            activeTiles.Add(DownDir(tile));
            activeTiles.Add(LeftDir(tile));
            if (activeTiles.Contains(finish))
            {
                activeTiles.Clear();
                finishFound = true;
            }
            activeTiles.RemoveAll(tile => tile == null);
        }

        private Tile Path(Tile p)
        {
            Thread.Sleep(20);
            if (p.Parent == start)
            {
                p.SetPath();
                return p;
            }
            else
            {
                if (p.Parent != null)
                {
                    p.Parent.SetPath();
                    return Path(p.Parent);
                }
                return p;
            }
        }

        private Tile UpDir(Tile tile)
        {
            foreach (var item in tilesList.Where(i => i.Y + 1 == tile.Y && i.X == tile.X))
            {
                return CheckItem(item,tile);
            }
            return null;
        }
        private Tile DownDir(Tile tile)
        {
            foreach (var item in tilesList.Where(i => i.Y - 1 == tile.Y && i.X == tile.X))
            {
                return CheckItem(item, tile);
            }
            return null;
        }
        private Tile LeftDir(Tile tile)
        {
            foreach (var item in tilesList.Where(i => i.Y == tile.Y && i.X + 1 == tile.X))
            {
                return CheckItem(item, tile);
            }
            return null;
        }
        private Tile RightDir(Tile tile)
        {
            foreach (var item in tilesList.Where(i => i.Y == tile.Y && i.X - 1 == tile.X))
            {
                return CheckItem(item, tile);
            }
            return null;
        }

        private Tile CheckItem(Tile item, Tile parent)
        {
            if (item.IsWalkable)
            {
                if (!visitedTiles.Contains(item))
                {
                    item.SetActive();
                    Thread.Sleep(30);
                    Visited(item);
                    item.SetParent(parent);
                    return item;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private void Visited(Tile tile)
        {
            tile.SetVisited();
            activeTiles.Remove(tile);
            visitedTiles.Add(tile);
        }
    }
}
