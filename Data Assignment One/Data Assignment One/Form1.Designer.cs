namespace Data_Assignment_One
{
    partial class NumberConversion
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
            this.components = new System.ComponentModel.Container();
            this.Convert = new System.Windows.Forms.Button();
            this.DecimalTextbox = new System.Windows.Forms.TextBox();
            this.DecimalLabel = new System.Windows.Forms.Label();
            this.HexLabel = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.HexTextbox = new System.Windows.Forms.TextBox();
            this.BinaryLabel = new System.Windows.Forms.Label();
            this.BinaryTextbox = new System.Windows.Forms.TextBox();
            this.InstuctionLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // Convert
            // 
            this.Convert.Location = new System.Drawing.Point(288, 98);
            this.Convert.Name = "Convert";
            this.Convert.Size = new System.Drawing.Size(75, 23);
            this.Convert.TabIndex = 0;
            this.Convert.Text = "Convert";
            this.Convert.UseVisualStyleBackColor = true;
            this.Convert.Click += new System.EventHandler(this.Convert_Click);
            // 
            // DecimalTextbox
            // 
            this.DecimalTextbox.AcceptsReturn = true;
            this.DecimalTextbox.Location = new System.Drawing.Point(58, 74);
            this.DecimalTextbox.Name = "DecimalTextbox";
            this.DecimalTextbox.Size = new System.Drawing.Size(139, 20);
            this.DecimalTextbox.TabIndex = 6;
            this.toolTip1.SetToolTip(this.DecimalTextbox, "Please only use 0-9");
            this.DecimalTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Toolbox_KeyPressed);
            // 
            // DecimalLabel
            // 
            this.DecimalLabel.AutoSize = true;
            this.DecimalLabel.Location = new System.Drawing.Point(55, 58);
            this.DecimalLabel.Name = "DecimalLabel";
            this.DecimalLabel.Size = new System.Drawing.Size(45, 13);
            this.DecimalLabel.TabIndex = 7;
            this.DecimalLabel.Text = "Decimal";
            // 
            // HexLabel
            // 
            this.HexLabel.AutoSize = true;
            this.HexLabel.Location = new System.Drawing.Point(55, 108);
            this.HexLabel.Name = "HexLabel";
            this.HexLabel.Size = new System.Drawing.Size(68, 13);
            this.HexLabel.TabIndex = 8;
            this.HexLabel.Text = "Hexadecimal";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(288, 149);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 9;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.Clear_Click);
            // 
            // HexTextbox
            // 
            this.HexTextbox.AcceptsReturn = true;
            this.HexTextbox.Location = new System.Drawing.Point(58, 125);
            this.HexTextbox.Name = "HexTextbox";
            this.HexTextbox.Size = new System.Drawing.Size(139, 20);
            this.HexTextbox.TabIndex = 10;
            this.toolTip1.SetToolTip(this.HexTextbox, "Please only use 0-9 & A-F");
            this.HexTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Toolbox_KeyPressed);
            // 
            // BinaryLabel
            // 
            this.BinaryLabel.AutoSize = true;
            this.BinaryLabel.Location = new System.Drawing.Point(58, 164);
            this.BinaryLabel.Name = "BinaryLabel";
            this.BinaryLabel.Size = new System.Drawing.Size(36, 13);
            this.BinaryLabel.TabIndex = 11;
            this.BinaryLabel.Text = "Binary";
            // 
            // BinaryTextbox
            // 
            this.BinaryTextbox.AcceptsReturn = true;
            this.BinaryTextbox.Location = new System.Drawing.Point(58, 181);
            this.BinaryTextbox.Name = "BinaryTextbox";
            this.BinaryTextbox.Size = new System.Drawing.Size(139, 20);
            this.BinaryTextbox.TabIndex = 12;
            this.toolTip1.SetToolTip(this.BinaryTextbox, "Please only use 0 or 1");
            this.BinaryTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Toolbox_KeyPressed);
            // 
            // InstuctionLabel
            // 
            this.InstuctionLabel.AutoSize = true;
            this.InstuctionLabel.Location = new System.Drawing.Point(58, 13);
            this.InstuctionLabel.Name = "InstuctionLabel";
            this.InstuctionLabel.Size = new System.Drawing.Size(252, 26);
            this.InstuctionLabel.TabIndex = 13;
            this.InstuctionLabel.Text = "Enter Number into 1 of the boxes and Click Convert.\nPlease Clear between each Cov" +
    "ersion";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 4000;
            this.toolTip1.InitialDelay = 300;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // NumberConversion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 223);
            this.Controls.Add(this.InstuctionLabel);
            this.Controls.Add(this.BinaryTextbox);
            this.Controls.Add(this.BinaryLabel);
            this.Controls.Add(this.HexTextbox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.HexLabel);
            this.Controls.Add(this.DecimalLabel);
            this.Controls.Add(this.DecimalTextbox);
            this.Controls.Add(this.Convert);
            this.Name = "NumberConversion";
            this.Text = "Number Conversion";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Convert;
        private System.Windows.Forms.TextBox DecimalTextbox;
        private System.Windows.Forms.Label DecimalLabel;
        private System.Windows.Forms.Label HexLabel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox HexTextbox;
        private System.Windows.Forms.Label BinaryLabel;
        private System.Windows.Forms.TextBox BinaryTextbox;
        private System.Windows.Forms.Label InstuctionLabel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

