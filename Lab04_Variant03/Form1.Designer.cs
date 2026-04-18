namespace Lab04_Variant03
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            //Controls
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.grpBfs = new System.Windows.Forms.GroupBox();
            this.lblBfsStart = new System.Windows.Forms.Label();
            this.cmbBfsStart = new System.Windows.Forms.ComboBox();
            this.btnBfs = new System.Windows.Forms.Button();
            this.grpDfs = new System.Windows.Forms.GroupBox();
            this.lblDfsStart = new System.Windows.Forms.Label();
            this.cmbDfsStart = new System.Windows.Forms.ComboBox();
            this.btnDfs = new System.Windows.Forms.Button();
            this.grpReach = new System.Windows.Forms.GroupBox();
            this.lblReachFrom = new System.Windows.Forms.Label();
            this.cmbReachFrom = new System.Windows.Forms.ComboBox();
            this.lblReachTo = new System.Windows.Forms.Label();
            this.cmbReachTo = new System.Windows.Forms.ComboBox();
            this.btnReach = new System.Windows.Forms.Button();
            this.btnComponents = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.lblOutput = new System.Windows.Forms.Label();

            this.panelLeft.SuspendLayout();
            this.grpBfs.SuspendLayout();
            this.grpDfs.SuspendLayout();
            this.grpReach.SuspendLayout();
            this.SuspendLayout();

            //Form 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.MinimumSize = new System.Drawing.Size(1020, 690);
            this.Text = "ЛР №4 — Дорожная сеть района (Вариант 3)";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            //panelLeft
            this.panelLeft.Location = new System.Drawing.Point(10, 10);
            this.panelLeft.Size = new System.Drawing.Size(310, 615);
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.btnLoad,
                this.grpBfs, this.grpDfs, this.grpReach,
                this.btnComponents, this.btnClear
            });

            //lblTitle
            this.lblTitle.Text = "Дорожная сеть района";
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Size = new System.Drawing.Size(285, 40);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //btnLoad 
            this.btnLoad.Text = "Загрузить граф из файла";
            this.btnLoad.Location = new System.Drawing.Point(10, 58);
            this.btnLoad.Size = new System.Drawing.Size(285, 34);
            this.btnLoad.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            // grpBfs 
            this.grpBfs.Text = "BFS — обход в ширину";
            this.grpBfs.Location = new System.Drawing.Point(10, 105);
            this.grpBfs.Size = new System.Drawing.Size(285, 110);

            this.lblBfsStart.Text = "Стартовая вершина:";
            this.lblBfsStart.Location = new System.Drawing.Point(8, 25);
            this.lblBfsStart.Size = new System.Drawing.Size(150, 22);

            this.cmbBfsStart.Location = new System.Drawing.Point(8, 48);
            this.cmbBfsStart.Size = new System.Drawing.Size(265, 26);
            this.cmbBfsStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnBfs.Text = "Запустить BFS";
            this.btnBfs.Location = new System.Drawing.Point(8, 78);
            this.btnBfs.Size = new System.Drawing.Size(265, 26);
            this.btnBfs.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnBfs.ForeColor = System.Drawing.Color.White;
            this.btnBfs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBfs.Click += new System.EventHandler(this.btnBfs_Click);

            this.grpBfs.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblBfsStart, this.cmbBfsStart, this.btnBfs
            });

            //grpDfs 
            this.grpDfs.Text = "DFS — обход в глубину";
            this.grpDfs.Location = new System.Drawing.Point(10, 225);
            this.grpDfs.Size = new System.Drawing.Size(285, 110);

            this.lblDfsStart.Text = "Стартовая вершина:";
            this.lblDfsStart.Location = new System.Drawing.Point(8, 25);
            this.lblDfsStart.Size = new System.Drawing.Size(150, 22);

            this.cmbDfsStart.Location = new System.Drawing.Point(8, 48);
            this.cmbDfsStart.Size = new System.Drawing.Size(265, 26);
            this.cmbDfsStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnDfs.Text = "Запустить DFS";
            this.btnDfs.Location = new System.Drawing.Point(8, 78);
            this.btnDfs.Size = new System.Drawing.Size(265, 26);
            this.btnDfs.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnDfs.ForeColor = System.Drawing.Color.White;
            this.btnDfs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDfs.Click += new System.EventHandler(this.btnDfs_Click);

            this.grpDfs.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblDfsStart, this.cmbDfsStart, this.btnDfs
            });

            // grpReach
            this.grpReach.Text = "Проверка достижимости (BFS)";
            this.grpReach.Location = new System.Drawing.Point(10, 345);
            this.grpReach.Size = new System.Drawing.Size(285, 145);

            this.lblReachFrom.Text = "Из вершины:";
            this.lblReachFrom.Location = new System.Drawing.Point(8, 25);
            this.lblReachFrom.Size = new System.Drawing.Size(100, 22);

            this.cmbReachFrom.Location = new System.Drawing.Point(8, 48);
            this.cmbReachFrom.Size = new System.Drawing.Size(265, 26);
            this.cmbReachFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblReachTo.Text = "В вершину:";
            this.lblReachTo.Location = new System.Drawing.Point(8, 78);
            this.lblReachTo.Size = new System.Drawing.Size(100, 22);

            this.cmbReachTo.Location = new System.Drawing.Point(8, 100);
            this.cmbReachTo.Size = new System.Drawing.Size(265, 26);
            this.cmbReachTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnReach.Text = "Проверить достижимость";
            this.btnReach.Location = new System.Drawing.Point(8, 112);
            this.btnReach.Size = new System.Drawing.Size(265, 26);
            this.btnReach.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnReach.ForeColor = System.Drawing.Color.White;
            this.btnReach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReach.Click += new System.EventHandler(this.btnReach_Click);

            this.grpReach.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblReachFrom, this.cmbReachFrom,
                this.lblReachTo,   this.cmbReachTo,
                this.btnReach
            });

            // btnComponents 
            this.btnComponents.Text = "Компоненты связности";
            this.btnComponents.Location = new System.Drawing.Point(10, 500);
            this.btnComponents.Size = new System.Drawing.Size(285, 34);
            this.btnComponents.BackColor = System.Drawing.Color.DarkOrange;
            this.btnComponents.ForeColor = System.Drawing.Color.White;
            this.btnComponents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComponents.Click += new System.EventHandler(this.btnComponents_Click);

            // btnClear 
            this.btnClear.Text = "Очистить вывод";
            this.btnClear.Location = new System.Drawing.Point(10, 544);
            this.btnClear.Size = new System.Drawing.Size(285, 34);
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // lblOutput 
            this.lblOutput.Text = "Результаты:";
            this.lblOutput.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.lblOutput.Location = new System.Drawing.Point(330, 10);
            this.lblOutput.Size = new System.Drawing.Size(120, 22);

            //txtOutput 
            this.txtOutput.Location = new System.Drawing.Point(330, 35);
            this.txtOutput.Size = new System.Drawing.Size(655, 590);
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtOutput.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtOutput.ForeColor = System.Drawing.Color.LightGreen;
            this.txtOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //Add to Form 
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.panelLeft, this.lblOutput, this.txtOutput
            });

            this.panelLeft.ResumeLayout(false);
            this.grpBfs.ResumeLayout(false);
            this.grpDfs.ResumeLayout(false);
            this.grpReach.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        //Fields 
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.GroupBox grpBfs;
        private System.Windows.Forms.Label lblBfsStart;
        private System.Windows.Forms.ComboBox cmbBfsStart;
        private System.Windows.Forms.Button btnBfs;
        private System.Windows.Forms.GroupBox grpDfs;
        private System.Windows.Forms.Label lblDfsStart;
        private System.Windows.Forms.ComboBox cmbDfsStart;
        private System.Windows.Forms.Button btnDfs;
        private System.Windows.Forms.GroupBox grpReach;
        private System.Windows.Forms.Label lblReachFrom;
        private System.Windows.Forms.ComboBox cmbReachFrom;
        private System.Windows.Forms.Label lblReachTo;
        private System.Windows.Forms.ComboBox cmbReachTo;
        private System.Windows.Forms.Button btnReach;
        private System.Windows.Forms.Button btnComponents;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.RichTextBox txtOutput;
    }
}

