﻿namespace ParallelMonteCarloPi
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
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pointsPictureBox = new System.Windows.Forms.PictureBox();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.numPointsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pointsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(67, 129);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.ReadOnly = true;
            this.timeTextBox.Size = new System.Drawing.Size(74, 20);
            this.timeTextBox.TabIndex = 29;
            this.timeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Time:";
            // 
            // pointsPictureBox
            // 
            this.pointsPictureBox.BackColor = System.Drawing.Color.White;
            this.pointsPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pointsPictureBox.Location = new System.Drawing.Point(147, 41);
            this.pointsPictureBox.Name = "pointsPictureBox";
            this.pointsPictureBox.Size = new System.Drawing.Size(155, 155);
            this.pointsPictureBox.TabIndex = 27;
            this.pointsPictureBox.TabStop = false;
            // 
            // errorTextBox
            // 
            this.errorTextBox.Location = new System.Drawing.Point(67, 103);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.ReadOnly = true;
            this.errorTextBox.Size = new System.Drawing.Size(74, 20);
            this.errorTextBox.TabIndex = 26;
            this.errorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Error:";
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(67, 77);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(74, 20);
            this.resultTextBox.TabIndex = 24;
            this.resultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Result:";
            // 
            // goButton
            // 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.Location = new System.Drawing.Point(225, 12);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 22;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // numPointsTextBox
            // 
            this.numPointsTextBox.Location = new System.Drawing.Point(67, 14);
            this.numPointsTextBox.Name = "numPointsTextBox";
            this.numPointsTextBox.Size = new System.Drawing.Size(74, 20);
            this.numPointsTextBox.TabIndex = 21;
            this.numPointsTextBox.Text = "10000";
            this.numPointsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "# Points:";
            // 
            // Form1
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 206);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pointsPictureBox);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.numPointsTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "ParallelMonteCarloPi ";
            ((System.ComponentModel.ISupportInitialize)(this.pointsPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pointsPictureBox;
        private System.Windows.Forms.TextBox errorTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox numPointsTextBox;
        private System.Windows.Forms.Label label1;
    }
}

