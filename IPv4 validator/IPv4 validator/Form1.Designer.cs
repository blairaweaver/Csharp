namespace IPv4_validator
{
    partial class IPv4Validator
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
            this.ValidateButton = new System.Windows.Forms.Button();
            this.IPv4Masked = new System.Windows.Forms.MaskedTextBox();
            this.HexOutputTextBox = new System.Windows.Forms.TextBox();
            this.HexOutputLabel = new System.Windows.Forms.Label();
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.ErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // ValidateButton
            // 
            this.ValidateButton.Location = new System.Drawing.Point(185, 55);
            this.ValidateButton.Name = "ValidateButton";
            this.ValidateButton.Size = new System.Drawing.Size(75, 23);
            this.ValidateButton.TabIndex = 0;
            this.ValidateButton.Text = "validate";
            this.ValidateButton.UseVisualStyleBackColor = true;
            this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
            // 
            // IPv4Masked
            // 
            this.IPv4Masked.Location = new System.Drawing.Point(42, 58);
            this.IPv4Masked.Mask = "000.000.000.000";
            this.IPv4Masked.Name = "IPv4Masked";
            this.IPv4Masked.Size = new System.Drawing.Size(94, 20);
            this.IPv4Masked.TabIndex = 2;
            this.IPv4Masked.ValidatingType = typeof(int);
            this.IPv4Masked.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.IPv4Masked_MaskInputRejected);
            this.IPv4Masked.Click += new System.EventHandler(this.IPv4Input_Click);
            this.IPv4Masked.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IPv4Masked_KeyPressed);
            // 
            // HexOutputTextBox
            // 
            this.HexOutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HexOutputTextBox.Location = new System.Drawing.Point(43, 109);
            this.HexOutputTextBox.Name = "HexOutputTextBox";
            this.HexOutputTextBox.ReadOnly = true;
            this.HexOutputTextBox.Size = new System.Drawing.Size(94, 13);
            this.HexOutputTextBox.TabIndex = 3;
            this.HexOutputTextBox.Visible = false;
            // 
            // HexOutputLabel
            // 
            this.HexOutputLabel.AutoSize = true;
            this.HexOutputLabel.Location = new System.Drawing.Point(40, 93);
            this.HexOutputLabel.Name = "HexOutputLabel";
            this.HexOutputLabel.Size = new System.Drawing.Size(169, 13);
            this.HexOutputLabel.TabIndex = 4;
            this.HexOutputLabel.Text = "Corresponding Hexadecimal Value";
            this.HexOutputLabel.Visible = false;
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Location = new System.Drawing.Point(43, 14);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(189, 26);
            this.InstructionLabel.TabIndex = 6;
            this.InstructionLabel.Text = "Fill in the IPv4 address using Numbers.\nAdd 0 as needed to complete address";
            // 
            // IPv4Validator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 151);
            this.Controls.Add(this.InstructionLabel);
            this.Controls.Add(this.HexOutputLabel);
            this.Controls.Add(this.HexOutputTextBox);
            this.Controls.Add(this.IPv4Masked);
            this.Controls.Add(this.ValidateButton);
            this.Name = "IPv4Validator";
            this.Text = "IPv4 validator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ValidateButton;
        private System.Windows.Forms.MaskedTextBox IPv4Masked;
        private System.Windows.Forms.TextBox HexOutputTextBox;
        private System.Windows.Forms.Label HexOutputLabel;
        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.ToolTip ErrorToolTip;
    }
}

