using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infy2
{
    /// <summary>
    /// ライフゲームのセルの座標を管理するためのクラスです。
    /// </summary>
    struct CellOfLifeGame
    {
        private int x, y;

        /// <summary>セルのx軸の値を表します。</summary>
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>セルのy軸の値を表します。</summary>
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        /// <summary>
        /// LifeGameのセルの座標を格納するためのコンストラクタです。
        /// </summary>
        /// <param name="x">セルのx軸の値を表します。</param> 
        /// <param name="y">セルのy軸の値を表します。</param>       
        public CellOfLifeGame(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// 座標の絶対値を計算し、原点からの距離を計算します。
        /// </summary>
        public double Abs() { return Math.Sqrt(x * x + y * y); }
    }
}