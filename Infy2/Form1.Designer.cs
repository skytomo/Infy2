namespace Infy2
{
    partial class Infy
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Infy));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.play = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ModeLabel = new System.Windows.Forms.ToolStripSplitButton();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.書き込みToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.消去ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイル = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新規作成 = new System.Windows.Forms.ToolStripMenuItem();
            this.開く = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.閉じる = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(784, 514);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 50);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "ファイル";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Black;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.play,
            this.label1,
            this.ModeLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 537);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // play
            // 
            this.play.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.play.ForeColor = System.Drawing.Color.DodgerBlue;
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(32, 19);
            this.play.Text = "再生";
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.Text = "0世代目 0セル";
            // 
            // ModeLabel
            // 
            this.ModeLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ModeLabel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作ToolStripMenuItem,
            this.書き込みToolStripMenuItem,
            this.消去ToolStripMenuItem});
            this.ModeLabel.ForeColor = System.Drawing.Color.White;
            this.ModeLabel.Image = ((System.Drawing.Image)(resources.GetObject("ModeLabel.Image")));
            this.ModeLabel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(60, 22);
            this.ModeLabel.Text = "モード";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.操作ToolStripMenuItem.Text = "操作";
            this.操作ToolStripMenuItem.Click += new System.EventHandler(this.操作ToolStripMenuItem_Click);
            // 
            // 書き込みToolStripMenuItem
            // 
            this.書き込みToolStripMenuItem.Name = "書き込みToolStripMenuItem";
            this.書き込みToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.書き込みToolStripMenuItem.Text = "書き込み";
            this.書き込みToolStripMenuItem.Click += new System.EventHandler(this.書き込みToolStripMenuItem_Click);
            // 
            // 消去ToolStripMenuItem
            // 
            this.消去ToolStripMenuItem.Name = "消去ToolStripMenuItem";
            this.消去ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.消去ToolStripMenuItem.Text = "消去";
            this.消去ToolStripMenuItem.Click += new System.EventHandler(this.消去ToolStripMenuItem_Click);
            // 
            // ファイル
            // 
            this.ファイル.Location = new System.Drawing.Point(0, 26);
            this.ファイル.Name = "ファイル";
            this.ファイル.Size = new System.Drawing.Size(784, 24);
            this.ファイル.TabIndex = 3;
            this.ファイル.Text = "ファイル";
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Black;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(784, 26);
            this.menuStrip2.TabIndex = 4;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新規作成,
            this.開く,
            this.toolStripSeparator1,
            this.閉じる});
            this.ファイルFToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 新規作成
            // 
            this.新規作成.BackColor = System.Drawing.Color.White;
            this.新規作成.ForeColor = System.Drawing.Color.Black;
            this.新規作成.Name = "新規作成";
            this.新規作成.Size = new System.Drawing.Size(152, 22);
            this.新規作成.Text = "新規作成(&N)";
            this.新規作成.Click += new System.EventHandler(this.新規作成_Click);
            // 
            // 開く
            // 
            this.開く.Name = "開く";
            this.開く.Size = new System.Drawing.Size(152, 22);
            this.開く.Text = "開く(&O)";
            this.開く.Click += new System.EventHandler(this.開く_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // 閉じる
            // 
            this.閉じる.Name = "閉じる";
            this.閉じる.Size = new System.Drawing.Size(152, 22);
            this.閉じる.Text = "閉じる(&X)";
            this.閉じる.Click += new System.EventHandler(this.閉じる_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Infy
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ファイル);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Infy";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel play;
        private System.Windows.Forms.ToolStripStatusLabel label1;
        private System.Windows.Forms.ToolStripSplitButton ModeLabel;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 書き込みToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 消去ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip ファイル;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新規作成;
        private System.Windows.Forms.ToolStripMenuItem 開く;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 閉じる;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

