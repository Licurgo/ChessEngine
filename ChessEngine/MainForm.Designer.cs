namespace ChessEngine
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.rtbBoard = new System.Windows.Forms.RichTextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblPerm = new System.Windows.Forms.Label();
            this.txtPermNbr = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblDepth = new System.Windows.Forms.Label();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.gbWhite = new System.Windows.Forms.GroupBox();
            this.lblwBestScore = new System.Windows.Forms.Label();
            this.lblwBestMove = new System.Windows.Forms.Label();
            this.lblBestScore = new System.Windows.Forms.Label();
            this.lblBestMove = new System.Windows.Forms.Label();
            this.gpBlack = new System.Windows.Forms.GroupBox();
            this.lblbBestScore = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblbBestMove = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblwBestPerm = new System.Windows.Forms.Label();
            this.lblwBestDepth = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblbBestPerm = new System.Windows.Forms.Label();
            this.lblbBestDepth = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbWhite.SuspendLayout();
            this.gpBlack.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(510, 309);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // rtbBoard
            // 
            this.rtbBoard.BackColor = System.Drawing.Color.Tan;
            this.rtbBoard.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbBoard.Location = new System.Drawing.Point(592, 12);
            this.rtbBoard.Name = "rtbBoard";
            this.rtbBoard.Size = new System.Drawing.Size(380, 320);
            this.rtbBoard.TabIndex = 2;
            this.rtbBoard.Text = "";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(511, 280);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(430, 281);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblPerm
            // 
            this.lblPerm.AutoSize = true;
            this.lblPerm.Location = new System.Drawing.Point(203, 286);
            this.lblPerm.Name = "lblPerm";
            this.lblPerm.Size = new System.Drawing.Size(73, 13);
            this.lblPerm.TabIndex = 5;
            this.lblPerm.Text = "Permutation #";
            // 
            // txtPermNbr
            // 
            this.txtPermNbr.Location = new System.Drawing.Point(324, 282);
            this.txtPermNbr.Name = "txtPermNbr";
            this.txtPermNbr.Size = new System.Drawing.Size(100, 20);
            this.txtPermNbr.TabIndex = 6;
            this.txtPermNbr.Text = "0";
            this.txtPermNbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 339);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(960, 410);
            this.dataGridView1.TabIndex = 7;
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.Location = new System.Drawing.Point(203, 259);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(36, 13);
            this.lblDepth.TabIndex = 8;
            this.lblDepth.Text = "Depth";
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(324, 256);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(100, 20);
            this.txtDepth.TabIndex = 9;
            this.txtDepth.Text = "0";
            this.txtDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbWhite
            // 
            this.gbWhite.Controls.Add(this.lblwBestPerm);
            this.gbWhite.Controls.Add(this.lblwBestDepth);
            this.gbWhite.Controls.Add(this.label5);
            this.gbWhite.Controls.Add(this.label6);
            this.gbWhite.Controls.Add(this.lblwBestScore);
            this.gbWhite.Controls.Add(this.lblwBestMove);
            this.gbWhite.Controls.Add(this.lblBestScore);
            this.gbWhite.Controls.Add(this.lblBestMove);
            this.gbWhite.Location = new System.Drawing.Point(13, 12);
            this.gbWhite.Name = "gbWhite";
            this.gbWhite.Size = new System.Drawing.Size(573, 100);
            this.gbWhite.TabIndex = 10;
            this.gbWhite.TabStop = false;
            this.gbWhite.Text = "Best White";
            // 
            // lblwBestScore
            // 
            this.lblwBestScore.AutoSize = true;
            this.lblwBestScore.Location = new System.Drawing.Point(94, 60);
            this.lblwBestScore.Name = "lblwBestScore";
            this.lblwBestScore.Size = new System.Drawing.Size(62, 13);
            this.lblwBestScore.TabIndex = 3;
            this.lblwBestScore.Text = "ScoreValue";
            // 
            // lblwBestMove
            // 
            this.lblwBestMove.AutoSize = true;
            this.lblwBestMove.Location = new System.Drawing.Point(94, 80);
            this.lblwBestMove.Name = "lblwBestMove";
            this.lblwBestMove.Size = new System.Drawing.Size(61, 13);
            this.lblwBestMove.TabIndex = 2;
            this.lblwBestMove.Text = "MoveValue";
            // 
            // lblBestScore
            // 
            this.lblBestScore.AutoSize = true;
            this.lblBestScore.Location = new System.Drawing.Point(6, 60);
            this.lblBestScore.Name = "lblBestScore";
            this.lblBestScore.Size = new System.Drawing.Size(35, 13);
            this.lblBestScore.TabIndex = 1;
            this.lblBestScore.Text = "Score";
            // 
            // lblBestMove
            // 
            this.lblBestMove.AutoSize = true;
            this.lblBestMove.Location = new System.Drawing.Point(6, 80);
            this.lblBestMove.Name = "lblBestMove";
            this.lblBestMove.Size = new System.Drawing.Size(34, 13);
            this.lblBestMove.TabIndex = 0;
            this.lblBestMove.Text = "Move";
            // 
            // gpBlack
            // 
            this.gpBlack.Controls.Add(this.lblbBestPerm);
            this.gpBlack.Controls.Add(this.lblbBestScore);
            this.gpBlack.Controls.Add(this.lblbBestDepth);
            this.gpBlack.Controls.Add(this.label4);
            this.gpBlack.Controls.Add(this.label9);
            this.gpBlack.Controls.Add(this.lblbBestMove);
            this.gpBlack.Controls.Add(this.label10);
            this.gpBlack.Controls.Add(this.label3);
            this.gpBlack.Location = new System.Drawing.Point(12, 118);
            this.gpBlack.Name = "gpBlack";
            this.gpBlack.Size = new System.Drawing.Size(573, 100);
            this.gpBlack.TabIndex = 11;
            this.gpBlack.TabStop = false;
            this.gpBlack.Text = "Best Black";
            // 
            // lblbBestScore
            // 
            this.lblbBestScore.AutoSize = true;
            this.lblbBestScore.Location = new System.Drawing.Point(94, 60);
            this.lblbBestScore.Name = "lblbBestScore";
            this.lblbBestScore.Size = new System.Drawing.Size(62, 13);
            this.lblbBestScore.TabIndex = 7;
            this.lblbBestScore.Text = "ScoreValue";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Move";
            // 
            // lblbBestMove
            // 
            this.lblbBestMove.AutoSize = true;
            this.lblbBestMove.Location = new System.Drawing.Point(94, 80);
            this.lblbBestMove.Name = "lblbBestMove";
            this.lblbBestMove.Size = new System.Drawing.Size(61, 13);
            this.lblbBestMove.TabIndex = 6;
            this.lblbBestMove.Text = "MoveValue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Score";
            // 
            // lblwBestPerm
            // 
            this.lblwBestPerm.AutoSize = true;
            this.lblwBestPerm.Location = new System.Drawing.Point(94, 40);
            this.lblwBestPerm.Name = "lblwBestPerm";
            this.lblwBestPerm.Size = new System.Drawing.Size(58, 13);
            this.lblwBestPerm.TabIndex = 7;
            this.lblwBestPerm.Text = "PermValue";
            // 
            // lblwBestDepth
            // 
            this.lblwBestDepth.AutoSize = true;
            this.lblwBestDepth.Location = new System.Drawing.Point(94, 20);
            this.lblwBestDepth.Name = "lblwBestDepth";
            this.lblwBestDepth.Size = new System.Drawing.Size(63, 13);
            this.lblwBestDepth.TabIndex = 6;
            this.lblwBestDepth.Text = "DepthValue";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Permutation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Depth";
            // 
            // lblbBestPerm
            // 
            this.lblbBestPerm.AutoSize = true;
            this.lblbBestPerm.Location = new System.Drawing.Point(94, 40);
            this.lblbBestPerm.Name = "lblbBestPerm";
            this.lblbBestPerm.Size = new System.Drawing.Size(58, 13);
            this.lblbBestPerm.TabIndex = 11;
            this.lblbBestPerm.Text = "PermValue";
            // 
            // lblbBestDepth
            // 
            this.lblbBestDepth.AutoSize = true;
            this.lblbBestDepth.Location = new System.Drawing.Point(94, 20);
            this.lblbBestDepth.Name = "lblbBestDepth";
            this.lblbBestDepth.Size = new System.Drawing.Size(63, 13);
            this.lblbBestDepth.TabIndex = 10;
            this.lblbBestDepth.Text = "DepthValue";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Permutation";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Depth";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.gpBlack);
            this.Controls.Add(this.gbWhite);
            this.Controls.Add(this.txtDepth);
            this.Controls.Add(this.lblDepth);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtPermNbr);
            this.Controls.Add(this.lblPerm);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.rtbBoard);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbWhite.ResumeLayout(false);
            this.gbWhite.PerformLayout();
            this.gpBlack.ResumeLayout(false);
            this.gpBlack.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RichTextBox rtbBoard;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblPerm;
        private System.Windows.Forms.TextBox txtPermNbr;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.TextBox txtDepth;
        private System.Windows.Forms.GroupBox gbWhite;
        private System.Windows.Forms.Label lblwBestScore;
        private System.Windows.Forms.Label lblwBestMove;
        private System.Windows.Forms.Label lblBestScore;
        private System.Windows.Forms.Label lblBestMove;
        private System.Windows.Forms.GroupBox gpBlack;
        private System.Windows.Forms.Label lblbBestScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblbBestMove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblwBestPerm;
        private System.Windows.Forms.Label lblwBestDepth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblbBestPerm;
        private System.Windows.Forms.Label lblbBestDepth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

