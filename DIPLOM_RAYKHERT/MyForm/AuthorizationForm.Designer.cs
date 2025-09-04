namespace DIPLOM_RAYKHERT
{
    partial class AuthorizationForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationForm));
            this.logoPb = new System.Windows.Forms.PictureBox();
            this.loginTb = new System.Windows.Forms.TextBox();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.humanPb = new System.Windows.Forms.PictureBox();
            this.lockPb = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.logoPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lockPb)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPb
            // 
            this.logoPb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoPb.BackColor = System.Drawing.Color.Transparent;
            this.logoPb.Image = ((System.Drawing.Image)(resources.GetObject("logoPb.Image")));
            this.logoPb.Location = new System.Drawing.Point(47, 33);
            this.logoPb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logoPb.Name = "logoPb";
            this.logoPb.Size = new System.Drawing.Size(336, 98);
            this.logoPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPb.TabIndex = 0;
            this.logoPb.TabStop = false;
            // 
            // loginTb
            // 
            this.loginTb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.loginTb.Location = new System.Drawing.Point(129, 160);
            this.loginTb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loginTb.MaxLength = 45;
            this.loginTb.Name = "loginTb";
            this.loginTb.Size = new System.Drawing.Size(195, 26);
            this.loginTb.TabIndex = 1;
            this.toolTip1.SetToolTip(this.loginTb, "Введите ваш логин");
            this.loginTb.TextChanged += new System.EventHandler(this.loginTb_TextChanged);
            this.loginTb.Enter += new System.EventHandler(this.loginTb_Enter);
            this.loginTb.Leave += new System.EventHandler(this.loginTb_Leave);
            // 
            // passwordTb
            // 
            this.passwordTb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordTb.Location = new System.Drawing.Point(129, 196);
            this.passwordTb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordTb.MaxLength = 45;
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.Size = new System.Drawing.Size(195, 26);
            this.passwordTb.TabIndex = 3;
            this.toolTip1.SetToolTip(this.passwordTb, "Введите ваш пароль");
            this.passwordTb.UseSystemPasswordChar = true;
            this.passwordTb.TextChanged += new System.EventHandler(this.passwordTb_TextChanged);
            this.passwordTb.Enter += new System.EventHandler(this.passwordTb_Enter);
            this.passwordTb.Leave += new System.EventHandler(this.passwordTb_Leave);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox1.Location = new System.Drawing.Point(129, 229);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 26);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Показать пароль";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(34)))), ((int)(((byte)(155)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(47, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Войти";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(225, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 34);
            this.button2.TabIndex = 6;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // humanPb
            // 
            this.humanPb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.humanPb.BackColor = System.Drawing.Color.Transparent;
            this.humanPb.Image = ((System.Drawing.Image)(resources.GetObject("humanPb.Image")));
            this.humanPb.Location = new System.Drawing.Point(92, 158);
            this.humanPb.Name = "humanPb";
            this.humanPb.Size = new System.Drawing.Size(30, 28);
            this.humanPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.humanPb.TabIndex = 7;
            this.humanPb.TabStop = false;
            this.humanPb.Click += new System.EventHandler(this.humanPb_Click);
            // 
            // lockPb
            // 
            this.lockPb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lockPb.BackColor = System.Drawing.Color.Transparent;
            this.lockPb.Image = ((System.Drawing.Image)(resources.GetObject("lockPb.Image")));
            this.lockPb.Location = new System.Drawing.Point(92, 196);
            this.lockPb.Name = "lockPb";
            this.lockPb.Size = new System.Drawing.Size(30, 28);
            this.lockPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lockPb.TabIndex = 8;
            this.lockPb.TabStop = false;
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(441, 338);
            this.Controls.Add(this.lockPb);
            this.Controls.Add(this.humanPb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.loginTb);
            this.Controls.Add(this.logoPb);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(457, 377);
            this.Name = "AuthorizationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.AuthorizationForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AuthorizationForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.logoPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lockPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPb;
        private System.Windows.Forms.TextBox loginTb;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox humanPb;
        private System.Windows.Forms.PictureBox lockPb;
        public System.Windows.Forms.ToolTip toolTip1;
    }
}

