namespace Character_Sheet
{
    partial class EighteenStrengthWarior
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EighteenStrengthWarior));
            this.RNGRollCheck = new System.Windows.Forms.CheckBox();
            this.FinishButton = new System.Windows.Forms.Button();
            this.RollBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RollBoxLabel = new System.Windows.Forms.Label();
            this.ExplanationBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RNGRollCheck
            // 
            this.RNGRollCheck.AutoSize = true;
            this.RNGRollCheck.BackColor = System.Drawing.Color.Goldenrod;
            this.RNGRollCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.RNGRollCheck.ForeColor = System.Drawing.Color.Cornsilk;
            this.RNGRollCheck.Location = new System.Drawing.Point(18, 160);
            this.RNGRollCheck.Margin = new System.Windows.Forms.Padding(5);
            this.RNGRollCheck.Name = "RNGRollCheck";
            this.RNGRollCheck.Size = new System.Drawing.Size(162, 24);
            this.RNGRollCheck.TabIndex = 0;
            this.RNGRollCheck.Text = "Let Us Roll for You";
            this.RNGRollCheck.UseVisualStyleBackColor = false;
            this.RNGRollCheck.CheckedChanged += new System.EventHandler(this.RNGRollCheck_CheckedChanged);
            // 
            // FinishButton
            // 
            this.FinishButton.BackColor = System.Drawing.Color.Cornsilk;
            this.FinishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FinishButton.Location = new System.Drawing.Point(485, 322);
            this.FinishButton.Margin = new System.Windows.Forms.Padding(5);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(196, 55);
            this.FinishButton.TabIndex = 1;
            this.FinishButton.Text = "Finish";
            this.FinishButton.UseVisualStyleBackColor = false;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // RollBox
            // 
            this.RollBox.BackColor = System.Drawing.Color.Cornsilk;
            this.RollBox.Enabled = false;
            this.RollBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.RollBox.Location = new System.Drawing.Point(168, 27);
            this.RollBox.Margin = new System.Windows.Forms.Padding(5);
            this.RollBox.Multiline = true;
            this.RollBox.Name = "RollBox";
            this.RollBox.Size = new System.Drawing.Size(220, 76);
            this.RollBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 3;
            // 
            // RollBoxLabel
            // 
            this.RollBoxLabel.AutoSize = true;
            this.RollBoxLabel.BackColor = System.Drawing.Color.Goldenrod;
            this.RollBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.RollBoxLabel.ForeColor = System.Drawing.Color.Cornsilk;
            this.RollBoxLabel.Location = new System.Drawing.Point(8, 50);
            this.RollBoxLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RollBoxLabel.Name = "RollBoxLabel";
            this.RollBoxLabel.Size = new System.Drawing.Size(119, 20);
            this.RollBoxLabel.TabIndex = 4;
            this.RollBoxLabel.Text = "Insert Your Roll";
            // 
            // ExplanationBox
            // 
            this.ExplanationBox.BackColor = System.Drawing.Color.Cornsilk;
            this.ExplanationBox.Enabled = false;
            this.ExplanationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ExplanationBox.Location = new System.Drawing.Point(18, 18);
            this.ExplanationBox.Margin = new System.Windows.Forms.Padding(5);
            this.ExplanationBox.Multiline = true;
            this.ExplanationBox.Name = "ExplanationBox";
            this.ExplanationBox.Size = new System.Drawing.Size(676, 132);
            this.ExplanationBox.TabIndex = 5;
            this.ExplanationBox.Text = resources.GetString("ExplanationBox.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Goldenrod;
            this.groupBox1.Controls.Add(this.RollBoxLabel);
            this.groupBox1.Controls.Add(this.RollBox);
            this.groupBox1.Location = new System.Drawing.Point(18, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 115);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Roll Input";
            // 
            // EighteenStrengthWarior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(713, 391);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExplanationBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.RNGRollCheck);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "EighteenStrengthWarior";
            this.Text = "EighteenStrengthWarior";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox RNGRollCheck;
        private System.Windows.Forms.Button FinishButton;
        private System.Windows.Forms.TextBox RollBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RollBoxLabel;
        private System.Windows.Forms.TextBox ExplanationBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}