namespace DIPLOM_RAYKHERT.MyForm
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.button2 = new System.Windows.Forms.Button();
            this.helpLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(34)))), ((int)(((byte)(155)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(675, 479);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 34);
            this.button2.TabIndex = 29;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // helpLbl
            // 
            this.helpLbl.AutoSize = true;
            this.helpLbl.BackColor = System.Drawing.Color.Transparent;
            this.helpLbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.helpLbl.Location = new System.Drawing.Point(12, 9);
            this.helpLbl.Name = "helpLbl";
            this.helpLbl.Size = new System.Drawing.Size(112, 22);
            this.helpLbl.TabIndex = 30;
            this.helpLbl.Text = "[ПОДСКАЗКИ]";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(845, 525);
            this.Controls.Add(this.helpLbl);
            this.Controls.Add(this.button2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(861, 564);
            this.MinimumSize = new System.Drawing.Size(861, 564);
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HelpForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label helpLbl;
    }
}