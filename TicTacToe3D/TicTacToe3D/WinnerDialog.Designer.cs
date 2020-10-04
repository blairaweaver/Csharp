namespace TicTacToe3D
{
    partial class WinnerDialog
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
            this.winnerTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // winnerTextBox
            // 
            this.winnerTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.winnerTextBox.Location = new System.Drawing.Point(46, 35);
            this.winnerTextBox.Name = "winnerTextBox";
            this.winnerTextBox.ReadOnly = true;
            this.winnerTextBox.Size = new System.Drawing.Size(315, 29);
            this.winnerTextBox.TabIndex = 0;
            this.winnerTextBox.TabStop = false;
            this.winnerTextBox.Text = "You have won the game!";
            // 
            // WinnerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 115);
            this.Controls.Add(this.winnerTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WinnerDialog";
            this.Text = "Congratulations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox winnerTextBox;
    }
}