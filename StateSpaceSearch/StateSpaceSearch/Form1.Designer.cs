namespace StateSpaceSearch
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startLabel = new System.Windows.Forms.Label();
            this.destLabel = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.startComboBox = new System.Windows.Forms.ComboBox();
            this.destComboBox = new System.Windows.Forms.ComboBox();
            this.algorithmLabel = new System.Windows.Forms.Label();
            this.aStarRadioButton = new System.Windows.Forms.RadioButton();
            this.depthRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(21, 19);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(72, 15);
            this.startLabel.TabIndex = 0;
            this.startLabel.Text = "Starting City";
            // 
            // destLabel
            // 
            this.destLabel.AutoSize = true;
            this.destLabel.Location = new System.Drawing.Point(21, 65);
            this.destLabel.Name = "destLabel";
            this.destLabel.Size = new System.Drawing.Size(91, 15);
            this.destLabel.TabIndex = 1;
            this.destLabel.Text = "Destination City";
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(21, 183);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 2;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // startComboBox
            // 
            this.startComboBox.FormattingEnabled = true;
            this.startComboBox.Location = new System.Drawing.Point(156, 19);
            this.startComboBox.Name = "startComboBox";
            this.startComboBox.Size = new System.Drawing.Size(176, 23);
            this.startComboBox.TabIndex = 3;
            // 
            // destComboBox
            // 
            this.destComboBox.FormattingEnabled = true;
            this.destComboBox.Location = new System.Drawing.Point(156, 65);
            this.destComboBox.Name = "destComboBox";
            this.destComboBox.Size = new System.Drawing.Size(176, 23);
            this.destComboBox.TabIndex = 4;
            // 
            // algorithmLabel
            // 
            this.algorithmLabel.AutoSize = true;
            this.algorithmLabel.Location = new System.Drawing.Point(21, 127);
            this.algorithmLabel.Name = "algorithmLabel";
            this.algorithmLabel.Size = new System.Drawing.Size(61, 15);
            this.algorithmLabel.TabIndex = 5;
            this.algorithmLabel.Text = "Algorithm";
            // 
            // aStarRadioButton
            // 
            this.aStarRadioButton.AutoSize = true;
            this.aStarRadioButton.Checked = true;
            this.aStarRadioButton.Location = new System.Drawing.Point(156, 127);
            this.aStarRadioButton.Name = "aStarRadioButton";
            this.aStarRadioButton.Size = new System.Drawing.Size(38, 19);
            this.aStarRadioButton.TabIndex = 6;
            this.aStarRadioButton.TabStop = true;
            this.aStarRadioButton.Text = "A*";
            this.aStarRadioButton.UseVisualStyleBackColor = true;
            // 
            // depthRadioButton
            // 
            this.depthRadioButton.AutoSize = true;
            this.depthRadioButton.Location = new System.Drawing.Point(250, 127);
            this.depthRadioButton.Name = "depthRadioButton";
            this.depthRadioButton.Size = new System.Drawing.Size(82, 19);
            this.depthRadioButton.TabIndex = 7;
            this.depthRadioButton.Text = "Depth First";
            this.depthRadioButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 247);
            this.Controls.Add(this.depthRadioButton);
            this.Controls.Add(this.aStarRadioButton);
            this.Controls.Add(this.algorithmLabel);
            this.Controls.Add(this.destComboBox);
            this.Controls.Add(this.startComboBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.destLabel);
            this.Controls.Add(this.startLabel);
            this.Name = "Form1";
            this.Text = "Parameter Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label destLabel;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.ComboBox startComboBox;
        private System.Windows.Forms.ComboBox destComboBox;
        private System.Windows.Forms.Label algorithmLabel;
        private System.Windows.Forms.RadioButton aStarRadioButton;
        private System.Windows.Forms.RadioButton depthRadioButton;
    }
}

