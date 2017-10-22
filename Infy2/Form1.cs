using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infy2
{

    enum MODE
    {
        OPERATE,
        WRITE,
        REMOVE,
    }

    public partial class Infy : Form
    {
        LifeGame lifegame = new LifeGame(true);
        DrawLifeGame drawlifegame = new DrawLifeGame();

        bool isplay = false;
        int basemousex, basemousey;
        float camerax, cameray;
        MODE mode = MODE.WRITE;

        int zoomlebel;

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
            zoomlebel += e.Delta * SystemInformation.MouseWheelScrollLines / 360;
            if (zoomlebel < -10) zoomlebel = -10;
            else if (zoomlebel > 10) zoomlebel = 10;
            drawlifegame.Zoom = (float)Math.Pow(1.1, zoomlebel);
            cellshow();
        }

        /// <summary>
        /// クリックしたときのセルの座標を返します。
        /// </summary>
        /// <returns>クリックしたセルの座標</returns>
        private CellOfLifeGame ClickedCell()
        {
            //フォーム上の座標でマウスポインタの位置を取得する
            //画面座標でマウスポインタの位置を取得する
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
            //画面座標をクライアント座標に変換する
            System.Drawing.Point cp = PointToClient(sp);
            //pictureBox1の座標を求める
            //X座標を取得する
            int xonform = cp.X - pictureBox1.Location.X;
            //Y座標を取得する
            int yonform = cp.Y - pictureBox1.Location.Y;
            return new CellOfLifeGame((int)(drawlifegame.X + xonform / (11 * drawlifegame.Zoom)), (int)(drawlifegame.Y + yonform / (11 * drawlifegame.Zoom)));
        }

        /// <summary>
        /// マウスの左ボタンを押したときに、
        /// マウスの座標を変数に格納します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, EventArgs e)
        {
            switch (MouseButtons)
            {
                case MouseButtons.Left:
                    switch (mode)
                    {
                        case MODE.OPERATE:
                            basemousex = MousePosition.X;
                            basemousey = MousePosition.Y;
                            camerax = drawlifegame.X;
                            cameray = drawlifegame.Y;
                            break;
                        case MODE.WRITE:
                            lifegame.SetCell(ClickedCell());
                            break;
                        case MODE.REMOVE:
                            lifegame.RemoveCell(ClickedCell());
                            break;
                        default:
                            break;
                    }
                    cellshow();
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    switch (mode)
                    {
                        case MODE.OPERATE:
                            break;
                        case MODE.WRITE:
                            lifegame.RemoveCell(ClickedCell());
                            break;
                        case MODE.REMOVE:
                            lifegame.SetCell(ClickedCell());
                            break;
                        default:
                            break;
                    }
                    cellshow();
                    break;
                case MouseButtons.Middle:
                    basemousex = MousePosition.X;
                    basemousey = MousePosition.Y;
                    camerax = drawlifegame.X;
                    cameray = drawlifegame.Y;
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
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
            switch (MouseButtons)
            {
                case MouseButtons.Left:
                    switch (mode)
                    {
                        case MODE.OPERATE:
                            drawlifegame.X = camerax - (MousePosition.X - basemousex) / (10 * drawlifegame.Zoom);
                            drawlifegame.Y = cameray - (MousePosition.Y - basemousey) / (10 * drawlifegame.Zoom);
                            break;
                        case MODE.WRITE:
                            lifegame.SetCell(ClickedCell());
                            break;
                        case MODE.REMOVE:
                            lifegame.RemoveCell(ClickedCell());
                            break;
                        default:
                            break;
                    }
                    cellshow();
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    switch (mode)
                    {
                        case MODE.OPERATE:
                            break;
                        case MODE.WRITE:
                            lifegame.RemoveCell(ClickedCell());
                            break;
                        case MODE.REMOVE:
                            lifegame.SetCell(ClickedCell());
                            break;
                        default:
                            break;
                    }
                    cellshow();
                    break;
                case MouseButtons.Middle:
                    drawlifegame.X = camerax - (MousePosition.X - basemousex) / (10 * drawlifegame.Zoom);
                    drawlifegame.Y = cameray - (MousePosition.Y - basemousey) / (10 * drawlifegame.Zoom);
                    cellshow();
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
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

        private void 操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = MODE.OPERATE;
            ModeLabel.Text = "モード:操作";
        }

        private void 書き込みToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = MODE.WRITE;
            ModeLabel.Text = "モード:書き込み";
        }

        private void 消去ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = MODE.REMOVE;
            ModeLabel.Text = "モード:消去";
        }

        private void 新規作成_Click(object sender, EventArgs e)
        {
            lifegame.ClearAllCell();
            cellshow();
        }

        private void 開く_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();
            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            //ofd.FileName = "default.html";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            //ofd.InitialDirectory = @"C:\";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "Infyファイル(*.infy)|*.infy|LIFEファイル(*.life)|*.life|対応ファイル(*.infy;*.life)|*.infy;*.life|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 3;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                Console.WriteLine(ofd.FileName);

                ReadLifeFile(ofd.FileName);
            }
        }

        private void ReadLifeFile(string name)
        {
            System.IO.StreamReader sr = new StreamReader(name);
            var line = sr.ReadLine();
            var reg = new System.Text.RegularExpressions.Regex(@"\[(.*?)\]\[(.*?)\]");
            lifegame.ClearAllCell();
            while (sr.Peek() >= 0)
            {
                line = sr.ReadLine();
                System.Text.RegularExpressions.Match mr = reg.Match(line);
                // int.TryParse(mr.Gro.ToString(), out int x);
                Console.WriteLine(mr.Groups[0].Value + "," + mr.Groups[1].Value+","+mr.Groups[2].Value);
                int.TryParse(mr.Groups[1].Value, out int x);
                int.TryParse(mr.Groups[2].Value, out int y);
                lifegame.SetCell(x, y);
            }
            cellshow();
        }

        private void 閉じる_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
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

        
        //フォームのLoadイベントハンドラ
        private void Form1_Load(object sender, System.EventArgs e)
        {

            /*
            //ドロップを受け入れる
            pictureBox1.AllowDrop = true;

            //イベントハンドラを追加
            pictureBox1.DragEnter += new DragEventHandler(pictureBox1_DragEnter);
            pictureBox1.DragDrop += new DragEventHandler(pictureBox1_DragDrop);
            */
        }

        /*
        //pictureBox1でマウスボタンが押された時
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //マウスの左ボタンだけが押されている時のみドラッグできるようにする
            if (e.Button == MouseButtons.Left)
            {
                //ドラッグの準備
                ListBox lbx = (ListBox)sender;
                //ドラッグするアイテムのインデックスを取得する
                int itemIndex = lbx.IndexFromPoint(e.X, e.Y);
                if (itemIndex < 0) return;
                //ドラッグするアイテムの内容を取得する
                string itemText = (string)lbx.Items[itemIndex];

                //ドラッグ&ドロップ処理を開始する
                DragDropEffects dde =
                    lbx.DoDragDrop(itemText, DragDropEffects.All);

                //ドロップ効果がMoveの時はもとのアイテムを削除する
                if (dde == DragDropEffects.Move)
                    lbx.Items.RemoveAt(itemIndex);
            }
        }

        //ListBox2内にドラッグされた時
        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            //ドラッグされているデータがstring型か調べ、
            //そうであればドロップ効果をMoveにする
            if (e.Data.GetDataPresent(typeof(string)))
                e.Effect = DragDropEffects.Move;
            else
                //string型でなければ受け入れない
                e.Effect = DragDropEffects.None;
        }

        //ListBox2にドロップされたとき
        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたデータがstring型か調べる
            if (e.Data.GetDataPresent(typeof(string)))
            {
                //ドロップされたデータ(string型)を取得
                string itemText =
                    (string)e.Data.GetData(typeof(string));
                Console.WriteLine(itemText);
            }
        }
        */
    }
}
