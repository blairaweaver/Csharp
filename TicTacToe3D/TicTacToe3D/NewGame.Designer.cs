﻿namespace TicTacToe3D
{
    partial class NewGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.humanRadioButton = new System.Windows.Forms.RadioButton();
            this.compRadioButton = new System.Windows.Forms.RadioButton();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(34, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1:";
            // 
            // humanRadioButton
            // 
            this.humanRadioButton.AutoSize = true;
            this.humanRadioButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.humanRadioButton.Location = new System.Drawing.Point(163, 48);
            this.humanRadioButton.Name = "humanRadioButton";
            this.humanRadioButton.Size = new System.Drawing.Size(61, 29);
            this.humanRadioButton.TabIndex = 1;
            this.humanRadioButton.TabStop = true;
            this.humanRadioButton.Text = "You";
            this.humanRadioButton.UseVisualStyleBackColor = true;
            // 
            // compRadioButton
            // 
            this.compRadioButton.AutoSize = true;
            this.compRadioButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.compRadioButton.Location = new System.Drawing.Point(268, 48);
            this.compRadioButton.Name = "compRadioButton";
            this.compRadioButton.Size = new System.Drawing.Size(114, 29);
            this.compRadioButton.TabIndex = 2;
            this.compRadioButton.TabStop = true;
            this.compRadioButton.Text = "Computer";
            this.compRadioButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startButton.Location = new System.Drawing.Point(135, 116);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(103, 52);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 217);
            this.ControlBox = false;
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.compRadioButton);
            this.Controls.Add(this.humanRadioButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGame";
            this.Text = "NewGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton humanRadioButton;
        private System.Windows.Forms.RadioButton compRadioButton;
        private System.Windows.Forms.Button startButton;
    }
}