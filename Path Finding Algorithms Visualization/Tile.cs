using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Path_Finding_Algorithms_Visualization
{
    internal class Tile
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int H { get; set; }
        public int G { get; set; }
        public int F { get; set; }
        public bool IsWalkable { get; set; }
        public bool IsStart { get; set; }
        public bool IsFinish { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisited { get; set; }
        public bool IsPath { get; set; }
        public Panel Panel { get; set; }
        public Tile Parent { get; set; }

        Color FinishColor = Color.Red;
        Color StartColor = Color.Green;
        Color WalkableColor = Color.AliceBlue;
        Color NonWalkableColor = Color.Black;
        Color ActiveColor = Color.Lime;
        Color VisitedColor = Color.Gray;
        Color PathColor = Color.Orange;

        public Tile(int id, int x, int y, Panel p)
        {
            Panel = p;
            Id = id;
            X = x;
            Y = y;
            IsWalkable = true;
        }

        public void SetParent(Tile parent)
        {
            Parent = parent;
        }

        public void Clear()
        {
            IsWalkable = true;
            IsStart = false;
            IsFinish = false;
            Panel.BackColor = WalkableColor;
        }
        public void ClearPath()
        {
            if (IsStart)
            {
                IsPath = false;
                Parent = null;
                Panel.BackColor = StartColor;
            }
            else if (IsFinish)
            {
                IsPath = false;
                Parent = null;
                Panel.BackColor = FinishColor;
            }
            else if (!IsWalkable)
            {
                IsPath = false;
                Parent = null;
                Panel.BackColor = NonWalkableColor;
            }
            else
            {
                IsPath = false;
                Parent = null;
                Panel.BackColor = WalkableColor;
            }

        }
        public void SetStart()
        {
            IsStart = true;
            Panel.BackColor = StartColor;
        }
        public void SetFinish()
        {
            IsFinish = true;
            Panel.BackColor = FinishColor;
        }
        public void SetWalkable()
        {
            if (IsWalkable)
            {
                IsWalkable = false;
                Panel.BackColor = NonWalkableColor;
            }
            else
            {
                IsWalkable = true;
                Panel.BackColor = WalkableColor;
            }
        }
        public void SetActive()
        {
            if (IsStart || IsFinish)
            {
                IsActive = true;
            }
            else
            {
                IsActive = true;
                Panel.BackColor = ActiveColor;
            }
        }
        public void SetVisited()
        {
            if (IsStart || IsFinish)
            {
                IsVisited = true;
            }
            else
            {
                IsVisited = true;
                Panel.BackColor = VisitedColor;
            }
        }

        public void SetPath()
        {
            if (IsStart)
            {
                IsPath = true;
                Panel.BackColor = StartColor;
            }
            if (IsFinish)
            {
                IsPath = true;
                Panel.BackColor = FinishColor;
            }
            else
            {
                IsPath = true;
                Panel.BackColor = PathColor;
            }
        }

        public int FCost()
        {
            return G + H;
        }
    }
}
