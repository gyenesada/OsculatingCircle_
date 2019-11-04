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
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(758, 12);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(141, 20);
            this.textBoxX.TabIndex = 0;
            this.textBoxX.Text = "sqr,t";
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(758, 48);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(141, 20);
            this.textBoxY.TabIndex = 1;
            this.textBoxY.Text = "20";
            // 
            // textBoxInt
            // 
            this.textBoxInt.Location = new System.Drawing.Point(799, 74);
            this.textBoxInt.Name = "textBoxInt";
            this.textBoxInt.Size = new System.Drawing.Size(100, 20);
            this.textBoxInt.TabIndex = 2;
            this.textBoxInt.Text = "-10,10";
            // 
            // textBoxPoint
            // 
            this.textBoxPoint.Location = new System.Drawing.Point(799, 100);
            this.textBoxPoint.Name = "textBoxPoint";
            this.textBoxPoint.Size = new System.Drawing.Size(100, 20);
            this.textBoxPoint.TabIndex = 3;
            this.textBoxPoint.Text = "4,20";
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(758, 138);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(141, 23);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "GO!";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 540);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.textBoxPoint);
            this.Controls.Add(this.textBoxInt);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
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
    }
}

