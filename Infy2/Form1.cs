using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infy2
{
    public partial class Infy : Form
    {
        LifeGame lifegame = new LifeGame();
        DrawLifeGame drawlifegame = new DrawLifeGame();
        bool isplay = false;
        int basemousex, basemousey;
        float camerax, cameray;

        public Infy()
        {
            InitializeComponent();
            pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseWheel);
            pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseMove);
            Resize += new EventHandler(Form1_Resize);

            /*
            lifegame.SetCell(new CellOfLifeGame(9, 0));
            lifegame.SetCell(new CellOfLifeGame(9, 1));
            lifegame.SetCell(new CellOfLifeGame(9, 2));
            */

            /*
            lifegame.SetCell(new CellOfLifeGame(9, 11));
            lifegame.SetCell(new CellOfLifeGame(10, 10));
            lifegame.SetCell(new CellOfLifeGame(11, 10));
            lifegame.SetCell(new CellOfLifeGame(12, 10));
            lifegame.SetCell(new CellOfLifeGame(13, 10));
            lifegame.SetCell(new CellOfLifeGame(13, 11));
            lifegame.SetCell(new CellOfLifeGame(13, 12));
            lifegame.SetCell(new CellOfLifeGame(12, 13));
            */

            /*
            lifegame.SetCell(new CellOfLifeGame(13, 11));
            lifegame.SetCell(new CellOfLifeGame(13, 12));
            lifegame.SetCell(new CellOfLifeGame(13, 13));
            lifegame.SetCell(new CellOfLifeGame(12, 13));
            lifegame.SetCell(new CellOfLifeGame(11, 12));
            */

            
            lifegame.SetCell(new CellOfLifeGame(1, 3));
            lifegame.SetCell(new CellOfLifeGame(2, 4));
            lifegame.SetCell(new CellOfLifeGame(3, 4));
            lifegame.SetCell(new CellOfLifeGame(4, 4));
            lifegame.SetCell(new CellOfLifeGame(5, 4));
            lifegame.SetCell(new CellOfLifeGame(5, 3));
            lifegame.SetCell(new CellOfLifeGame(5, 2));
            lifegame.SetCell(new CellOfLifeGame(4, 1));
            lifegame.SetCell(new CellOfLifeGame(1, 8));
            lifegame.SetCell(new CellOfLifeGame(2, 9));
            lifegame.SetCell(new CellOfLifeGame(3, 9));
            lifegame.SetCell(new CellOfLifeGame(3, 10));
            lifegame.SetCell(new CellOfLifeGame(3, 11));
            lifegame.SetCell(new CellOfLifeGame(2, 12));
            lifegame.SetCell(new CellOfLifeGame(1, 17));
            lifegame.SetCell(new CellOfLifeGame(2, 18));
            lifegame.SetCell(new CellOfLifeGame(3, 18));
            lifegame.SetCell(new CellOfLifeGame(4, 18));
            lifegame.SetCell(new CellOfLifeGame(5, 18));
            lifegame.SetCell(new CellOfLifeGame(5, 17));
            lifegame.SetCell(new CellOfLifeGame(5, 16));
            lifegame.SetCell(new CellOfLifeGame(4, 15));
            

            //test

            //lifegame.Random(10, 10, 100, 100);

            timer1.Interval = 10;
            cellshow();

        }

        /// <summary>
        /// マウスホイールイベントを処理します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            drawlifegame.Zoom *= (float)Math.Pow(1.1, e.Delta * SystemInformation.MouseWheelScrollLines / 360);
            cellshow();
        }

        /// <summary>
        /// マウスの左ボタンを押したときに、
        /// マウスの座標を変数に格納します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, EventArgs e)
        {
            //Console.WriteLine("Down");
            basemousex = MousePosition.X;
            basemousey = MousePosition.Y;
            camerax = drawlifegame.X;
            cameray = drawlifegame.Y;
        }

        /// <summary>
        /// マウスを押している状態で、
        /// マウスを動かしたときに、
        /// 画面が動くように制御します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseMove(object sender, EventArgs e)
        {
            if ((MouseButtons & MouseButtons.Left) == MouseButtons.Left)
            {
                //Console.WriteLine((MousePosition.X - basemousex) + "," + (MousePosition.Y - basemousey));
                drawlifegame.X = camerax - (MousePosition.X - basemousex) / (10 * drawlifegame.Zoom);
                drawlifegame.Y = cameray - (MousePosition.Y - basemousey) / (10 * drawlifegame.Zoom);
                cellshow();
            }
        }

        /// <summary>
        /// 画面の大きさが変わったときに描画をし直します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            // Console.WriteLine("Form size changed {0} x {1}.", c.Width, c.Height);
            cellshow();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cellshow();
            // ピクチャボックスにフォーカスを移す
            pictureBox1.Focus();
        }

        /// <summary>
        /// クリックすると再生し、
        /// もう一度クリックすると停止します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void play_Click(object sender, EventArgs e)
        {
            if (isplay)
            {
                play.Text = "再生";
                timer1.Stop();
            }
            else
            {
                play.Text = "停止";
                timer1.Start();
            }
            isplay = !isplay;
        }

        /// <summary>
        /// 何世代目のセルが何セル生きているかを表示します。
        /// </summary>
        private void cellshow()
        {
            pictureBox1.Image = drawlifegame.Draw(lifegame.LifeList, pictureBox1.Width, pictureBox1.Height);
            label1.Text = lifegame.Generate + "世代目 " + lifegame.LifeList.Count + "セル" + " (x" + drawlifegame.Zoom.ToString("F2") + ")";
        }

        /// <summary>
        /// どのくらいの周期で世代を交代するかを設定したとおりに更新します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            cellshow();
            lifegame.NextGeneration();
        }
    }
}
