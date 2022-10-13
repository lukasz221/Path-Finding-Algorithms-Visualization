using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Path_Finding_Algorithms_Visualization
{
    public partial class Form1 : Form
    {
        Dijkstra dij;
        AStar aStar;
        DepthFirstSearch dfs;
        List<Tile> tileList;
        bool StartIsSelected = false;
        bool FinishIsSelected = false;
        bool isMap = false;
        int StartId;
        int FinishId;
        Tile StartTile;
        Tile FinishTile;
        public Form1()
        {
            InitializeComponent();
            tileList = new List<Tile>();
            dij = new Dijkstra();
            aStar = new AStar();
            dfs = new DepthFirstSearch();
        }

        private void buttonStartA_Click(object sender, EventArgs e)
        {
            if (aStar == null)
            {
                aStar = new AStar();
            }
            if (!StartIsSelected || !FinishIsSelected)
            {
                textBoxLogs.Text = string.Format("Add start and finish!" + Environment.NewLine);
            }
            else
            {
                Thread th = new Thread(new ThreadStart(StartThreadAStar));
                th.Start();
            }
        }

        private void buttonStartDijkstra_Click(object sender, EventArgs e)
        {
            if (dij == null)
            {
                dij = new Dijkstra();
            }
            if (!StartIsSelected || !FinishIsSelected)
            {
                textBoxLogs.Text = string.Format("Add start and finish!" + Environment.NewLine);
            }
            else
            {
                Thread th = new Thread(new ThreadStart(StartThreadDijkastra));
                th.Start();
            }
        }

        private void buttonDepthFirstSearch_Click(object sender, EventArgs e)
        {
            if (dfs == null)
            {
                dfs = new DepthFirstSearch();
            }
            if (!StartIsSelected || !FinishIsSelected)
            {
                textBoxLogs.Text = string.Format("Add start and finish!" + Environment.NewLine);
            }
            else
            {
                Thread th = new Thread(new ThreadStart(StartThreadDepthFirstSearch));
                th.Start();
            }

        }
        public void StartThreadAStar()
        {
            aStar.StartPathFindingAStar(tileList, StartTile, FinishTile);
        }
        public void StartThreadDijkastra()
        {
            dij.StartPathFindingDijkstra(tileList, StartTile, FinishTile);
        }
        public void StartThreadDepthFirstSearch()
        {
            dfs.StartPathFindingDepthFirstSearch(tileList, StartTile, FinishTile);
        }

        private void buttonRandomMap_Click(object sender, EventArgs e)
        {
            RandomMap();
        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CreateMap();
        }

        void button_click(object sender, MouseEventArgs e)
        {
            StartAndFinishPutOnMap(sender, e);
        }
        
        private void buttonTest_Click(object sender, EventArgs e)
        {
            DebugMethod();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonRestartMap_Click(object sender, EventArgs e)
        {
            ResetMap();
        }

        private void buttonClearPath_Click(object sender, EventArgs e)
        {
            ClearPath();
        }

        private void CreatePalens(int x, int y)
        {
            int id = 0;

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    id++;
                    Panel p = new Panel();
                    this.Controls.Add(p);
                    p.Name = $"Panel id: {id}* w: {j}* h: {i}*";
                    p.Tag = id;
                    p.BackColor = Color.AliceBlue;
                    p.Size = new Size(40, 40);
                    p.Location = new Point(j * 41 + 10, i * 41 + 100);
                    Tile tile = new Tile(id, j, i, p);
                    tileList.Add(tile);
                    p.MouseClick += new MouseEventHandler(this.button_click);
                }
            }
        }

        private void StartAndFinishPutOnMap(object sender, MouseEventArgs e)
        {
            Panel p = sender as Panel;
            if (e.Button == MouseButtons.Left)
            {
                if (!StartIsSelected)
                {
                    foreach (var item in tileList.Where(i => i.Id == Int32.Parse(p.Tag.ToString())))
                    {       
                        StartTile = item;
                        item.SetStart();
                        StartIsSelected = true;
                    }
                }
                else if (!FinishIsSelected)
                {
                    foreach (var item in tileList.Where(i => i.Id == Int32.Parse(p.Tag.ToString())))
                    {
                        if (item.Id != StartId)
                        {
                            item.SetFinish();
                            FinishTile = item;
                            FinishIsSelected = true;
                        }
                    }
                }
                else
                {
                    foreach (var item in tileList.Where(i => i.Id == Int32.Parse(p.Tag.ToString())))
                    {
                        if (item.Id != StartId && item.Id != FinishId)
                        {
                            item.SetWalkable();
                        }
                    }
                }
            }
        }

        private void CreateMap()
        {
            if (!isMap)
            {
                int x = Int32.Parse(textBoxW.Text);
                int y = Int32.Parse(textBoxH.Text);
                CreatePalens(x, y);
                isMap = true;
            }
            else
            {
                textBoxLogs.Text = string.Format("Map created already!" + Environment.NewLine);
            }
        }

        private void ResetMap()
        {
            isMap = false;  
            foreach (var item in tileList)
            {
                item.Panel.Dispose();
            }
            Clear();
            tileList.Clear();
        }

        private void ClearPath()
        {
            dij = null;
            aStar = null;
            dfs = null;
            foreach (var item in tileList)
            {
                item.ClearPath();
                item.IsVisited = false;
            }
        }

        private void Clear()
        {
            StartIsSelected = false;
            FinishIsSelected = false;
            FinishId = -1;
            StartId = -1;
            foreach (var tile in tileList)
            {
                tile.IsFinish = false;
                tile.IsStart = false;
                tile.IsWalkable = true;
                tile.Panel.BackColor = Color.AliceBlue;
                tile.Parent = null;
                tile.IsActive = false;
                tile.IsPath = false;
                tile.IsVisited = false;
            }
            dij = null;
            aStar = null;
            dfs = null;
        }

        private void DebugMethod()
        {
            foreach (var t in tileList)
            {
                Debug.WriteLine($"### ID: {t.Id} X: {t.X} Y: {t.Y} Start: {t.IsStart} Finish: {t.IsFinish} Walkable: {t.IsWalkable} Panel name: {t.Panel.Name}");
            }
        }

        private void RandomMap()
        {
            Clear();
            Random rnd = new Random();
            foreach (var t in tileList)
            {
                int r = rnd.Next(1, 6);
                if (r == 1)
                {
                    t.SetWalkable();
                }
            }
        }
    }
}
