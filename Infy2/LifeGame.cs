using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infy2
{

    /// <summary>
    /// ライフゲームにおける全てのセルを管理し、計算をするクラスです。
    /// </summary>
    struct LifeGame
    {


        private int gen;
        //private bool iscw;
        private List<CellOfLifeGame> initialstate;
        private List<CellOfLifeGame> lifelist;
        private Dictionary<CellOfLifeGame, int> neighborlist;
        private Dictionary<int, bool> birthrule;
        private Dictionary<int, bool> sustainrule;

        private bool[] bir;
        private bool[] sur;



        public LifeGame(bool t)
        {
            gen = 1;
            //iscw = false;
            initialstate = new List<CellOfLifeGame>();
            lifelist = new List<CellOfLifeGame>();
            neighborlist = new Dictionary<CellOfLifeGame, int>();
            birthrule = new Dictionary<int, bool>() { { 0, false }, { 1, false }, { 2, false }, { 3, true }, { 4, false }, { 5, false }, { 6, false }, { 7, false }, { 8, false } };
            sustainrule = new Dictionary<int, bool>() { { 0, false }, { 1, false }, { 2, true }, { 3, true }, { 4, false }, { 5, false }, { 6, false }, { 7, false }, { 8, false } };

            //bir = new bool[9] { false, false, true, false, false, false, false, false, false };
            //sur = new bool[9] { false, false, false, false, false, false, false, false, false };
            bir = new bool[9] { false, false, false, true, false, false, false, false, false };
            sur = new bool[9] { false, false, true, true, false, false, false, false, false };
            //bir = new bool[9] { true, true, true, true, true, true, true, true, true };
            //sur = new bool[9] { true, true, true, true, true, true, true, true, true };
        }

        public int Generate
        {
            get
            {
                return gen;
            }
        }

        /// <summary>ライフゲームの初期状態を管理するプロパティです。</summary>
        public List<CellOfLifeGame> InitialState
        {
            get
            {
                return initialstate;
            }
            set
            {
                initialstate = value;
                lifelist = initialstate;
            }
        }

        public List<CellOfLifeGame> LifeList
        {
            get
            {
                return lifelist;
            }
        }

        public void SetCell(CellOfLifeGame cell)
        {
            if (lifelist.IndexOf(cell) == -1) lifelist.Add(cell);
        }

        public void SetCell(int x, int y)
        {
            if (lifelist.IndexOf(new CellOfLifeGame(x, y)) == -1) lifelist.Add(new CellOfLifeGame(x, y));
        }

        public void RemoveCell(CellOfLifeGame cell)
        {
            if (lifelist.IndexOf(cell) != -1) lifelist.Remove(cell);
        }

        public void RemoveCell(int x, int y)
        {
            if (lifelist.IndexOf(new CellOfLifeGame(x, y)) == -1) lifelist.Remove(new CellOfLifeGame(x, y));
        }

        public void ClearAllCell()
        {
            lifelist.Clear();
        }

        /// <summary>
        /// 各セルのムーア近傍で生きているセルの数をリストアップします。
        /// ただし、周りに1つも生きているセルが存在しないセルはリストに登録されません。
        /// </summary>
        private void MakeNeighborList()
        {
            neighborlist.Clear();
            foreach (var g in lifelist)
            {

                int[] delta = new int[] { -1, 0, 1 };
                foreach (var i in delta)
                {
                    foreach (var j in delta)
                    {
                        var cell = new CellOfLifeGame(g.X + i, g.Y + j);
                        if (neighborlist.ContainsKey(cell))
                        {
                            if (neighborlist[cell] > 4) continue;
                            neighborlist[cell]++;
                        }
                        else
                        {
                            neighborlist.Add(cell, 1);
                        }
                    }

                }
                neighborlist[new CellOfLifeGame(g.X, g.Y)]--;
            }
        }

        /// <summary>ライフゲームを次の世代に更新します。</summary>
        public void NextGeneration()
        {
            gen++;
            MakeNeighborList();
            List<CellOfLifeGame> newlifelist = new List<CellOfLifeGame>();
            //if (iscw) Console.WriteLine("Gen {0} {{", gen);
            foreach (var g in neighborlist)
            {
                if (lifelist.Contains(new CellOfLifeGame(g.Key.X, g.Key.Y)))
                {
                    /*
                    if (sustainrule.ContainsKey(g.Value))
                    {
                        if (sustainrule[g.Value])
                        {
                            newlifelist.Add(g.Key);
                            if (iscw) Console.WriteLine("\t{{ {{ {0}, {1} }}, {{ {2} }} }} -> {{ Sutain }}", g.Key.X, g.Key.Y, g.Value);
                        }
                    }
                    */
                    if (sur[g.Value])
                    {
                        newlifelist.Add(g.Key);
                        //if (iscw) Console.WriteLine("\t{{ {{ {0}, {1} }}, {{ {2} }} }} -> {{ Sutain }}", g.Key.X, g.Key.Y, g.Value);
                    }
                }
                else
                {
                    /*
                    if (birthrule.ContainsKey(g.Value))
                    {
                        if (birthrule[g.Value])
                        {
                            newlifelist.Add(g.Key);
                            if (iscw) Console.WriteLine("\t{{ {{ {0}, {1} }}, {{ {2} }} }} -> {{ Birth }}", g.Key.X, g.Key.Y, g.Value);
                        }
                    }
                    */
                    if (bir[g.Value])
                    {
                        newlifelist.Add(g.Key);
                        //if (iscw) Console.WriteLine("\t{{ {{ {0}, {1} }}, {{ {2} }} }} -> {{ Birth }}", g.Key.X, g.Key.Y, g.Value);
                    }
                }
            }
            //if (iscw) Console.WriteLine("}");
            lifelist.Clear();
            lifelist = newlifelist;

        }

        public void Random(int x, int y, int width, int height)
        {
            System.Random r = new System.Random();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (r.Next(0, 2) == 1)
                    {
                        SetCell(new CellOfLifeGame(x + i, y + j));
                    }
                }
            }
        }
    }
}