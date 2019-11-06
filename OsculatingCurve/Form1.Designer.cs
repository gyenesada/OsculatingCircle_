namespace OsculatingCurve
{
    partial class Form1
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
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxInt = new System.Windows.Forms.TextBox();
            this.textBoxPoint = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.animationBtn = new System.Windows.Forms.Button();
            this.pointBtn = new System.Windows.Forms.Button();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelInt = new System.Windows.Forms.Label();
            this.labelPont = new System.Windows.Forms.Label();
            this.holdOnCB = new System.Windows.Forms.CheckBox();
            this.centerCB = new System.Windows.Forms.CheckBox();
            this.cleanBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(781, 12);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(118, 20);
            this.textBoxX.TabIndex = 0;
            this.textBoxX.Text = "t";
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(781, 48);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(118, 20);
            this.textBoxY.TabIndex = 1;
            this.textBoxY.Text = "sqr,t";
            // 
            // textBoxInt
            // 
            this.textBoxInt.Location = new System.Drawing.Point(824, 74);
            this.textBoxInt.Name = "textBoxInt";
            this.textBoxInt.Size = new System.Drawing.Size(75, 20);
            this.textBoxInt.TabIndex = 2;
            this.textBoxInt.Text = "-10,10";
            // 
            // textBoxPoint
            // 
            this.textBoxPoint.Location = new System.Drawing.Point(799, 162);
            this.textBoxPoint.Name = "textBoxPoint";
            this.textBoxPoint.Size = new System.Drawing.Size(100, 20);
            this.textBoxPoint.TabIndex = 3;
            this.textBoxPoint.Text = ",";
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(823, 100);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(76, 23);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Kirajzolás";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(0, 1);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(752, 537);
            this.canvas.TabIndex = 5;
            this.canvas.TabStop = false;
            this.canvas.Click += new System.EventHandler(this.canvas_Click);
            // 
            // animationBtn
            // 
            this.animationBtn.Location = new System.Drawing.Point(824, 300);
            this.animationBtn.Name = "animationBtn";
            this.animationBtn.Size = new System.Drawing.Size(75, 23);
            this.animationBtn.TabIndex = 6;
            this.animationBtn.Text = "Kör indítása";
            this.animationBtn.UseVisualStyleBackColor = true;
            this.animationBtn.Click += new System.EventHandler(this.animationBtn_Click);
            // 
            // pointBtn
            // 
            this.pointBtn.Location = new System.Drawing.Point(824, 188);
            this.pointBtn.Name = "pointBtn";
            this.pointBtn.Size = new System.Drawing.Size(75, 23);
            this.pointBtn.TabIndex = 7;
            this.pointBtn.Text = "Pontbeli";
            this.pointBtn.UseVisualStyleBackColor = true;
            this.pointBtn.Click += new System.EventHandler(this.pointBtn_Click);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(758, 15);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 8;
            this.labelX.Text = "X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(758, 51);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 9;
            this.labelY.Text = "Y";
            // 
            // labelInt
            // 
            this.labelInt.AutoSize = true;
            this.labelInt.Location = new System.Drawing.Point(758, 77);
            this.labelInt.Name = "labelInt";
            this.labelInt.Size = new System.Drawing.Size(61, 13);
            this.labelInt.TabIndex = 10;
            this.labelInt.Text = "Intervallum:";
            this.labelInt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelPont
            // 
            this.labelPont.AutoSize = true;
            this.labelPont.Location = new System.Drawing.Point(758, 165);
            this.labelPont.Name = "labelPont";
            this.labelPont.Size = new System.Drawing.Size(32, 13);
            this.labelPont.TabIndex = 11;
            this.labelPont.Text = "Pont:";
            // 
            // holdOnCB
            // 
            this.holdOnCB.AutoSize = true;
            this.holdOnCB.Location = new System.Drawing.Point(761, 254);
            this.holdOnCB.Name = "holdOnCB";
            this.holdOnCB.Size = new System.Drawing.Size(61, 17);
            this.holdOnCB.TabIndex = 12;
            this.holdOnCB.Text = "hold on";
            this.holdOnCB.UseVisualStyleBackColor = true;
            this.holdOnCB.CheckedChanged += new System.EventHandler(this.holdOnCB_CheckedChanged);
            // 
            // centerCB
            // 
            this.centerCB.AutoSize = true;
            this.centerCB.Enabled = false;
            this.centerCB.Location = new System.Drawing.Point(761, 277);
            this.centerCB.Name = "centerCB";
            this.centerCB.Size = new System.Drawing.Size(78, 17);
            this.centerCB.TabIndex = 13;
            this.centerCB.Text = "center only";
            this.centerCB.UseVisualStyleBackColor = true;
            // 
            // cleanBtn
            // 
            this.cleanBtn.Enabled = false;
            this.cleanBtn.Location = new System.Drawing.Point(824, 353);
            this.cleanBtn.Name = "cleanBtn";
            this.cleanBtn.Size = new System.Drawing.Size(75, 23);
            this.cleanBtn.TabIndex = 14;
            this.cleanBtn.Text = "Tisztítás";
            this.cleanBtn.UseVisualStyleBackColor = true;
            this.cleanBtn.Click += new System.EventHandler(this.cleanBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 540);
            this.Controls.Add(this.cleanBtn);
            this.Controls.Add(this.centerCB);
            this.Controls.Add(this.holdOnCB);
            this.Controls.Add(this.labelPont);
            this.Controls.Add(this.labelInt);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.pointBtn);
            this.Controls.Add(this.animationBtn);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.textBoxPoint);
            this.Controls.Add(this.textBoxInt);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxInt;
        private System.Windows.Forms.TextBox textBoxPoint;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button animationBtn;
        private System.Windows.Forms.Button pointBtn;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelInt;
        private System.Windows.Forms.Label labelPont;
        private System.Windows.Forms.CheckBox holdOnCB;
        private System.Windows.Forms.CheckBox centerCB;
        private System.Windows.Forms.Button cleanBtn;
    }
}

