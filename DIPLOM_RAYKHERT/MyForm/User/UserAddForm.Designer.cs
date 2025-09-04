namespace DIPLOM_RAYKHERT.MyForm
{
    partial class UserAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAddForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.roleCb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lastNameTb = new System.Windows.Forms.TextBox();
            this.surnameTb = new System.Windows.Forms.TextBox();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.emailTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.phoneMtb = new System.Windows.Forms.MaskedTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.passTb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.loginTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.roleCb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lastNameTb);
            this.groupBox1.Controls.Add(this.surnameTb);
            this.groupBox1.Controls.Add(this.nameTb);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Основные сведения";
            // 
            // roleCb
            // 
            this.roleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleCb.FormattingEnabled = true;
            this.roleCb.Location = new System.Drawing.Point(10, 166);
            this.roleCb.Name = "roleCb";
            this.roleCb.Size = new System.Drawing.Size(231, 30);
            this.roleCb.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Занимаемая должность";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Отчество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Фамилия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя";
            // 
            // lastNameTb
            // 
            this.lastNameTb.Location = new System.Drawing.Point(90, 89);
            this.lastNameTb.MaxLength = 45;
            this.lastNameTb.Name = "lastNameTb";
            this.lastNameTb.Size = new System.Drawing.Size(236, 26);
            this.lastNameTb.TabIndex = 3;
            this.lastNameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lastNameTb_KeyPress);
            // 
            // surnameTb
            // 
            this.surnameTb.Location = new System.Drawing.Point(90, 24);
            this.surnameTb.MaxLength = 45;
            this.surnameTb.Name = "surnameTb";
            this.surnameTb.Size = new System.Drawing.Size(236, 26);
            this.surnameTb.TabIndex = 2;
            this.surnameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.surnameTb_KeyPress);
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(90, 56);
            this.nameTb.MaxLength = 45;
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(236, 26);
            this.nameTb.TabIndex = 1;
            this.nameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTb_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.emailTb);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.phoneMtb);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(353, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 93);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Контактная информация";
            // 
            // emailTb
            // 
            this.emailTb.Location = new System.Drawing.Point(92, 58);
            this.emailTb.MaxLength = 45;
            this.emailTb.Name = "emailTb";
            this.emailTb.Size = new System.Drawing.Size(197, 26);
            this.emailTb.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 22);
            this.label6.TabIndex = 24;
            this.label6.Text = "Эл. почта";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Номер телефона";
            // 
            // phoneMtb
            // 
            this.phoneMtb.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.phoneMtb.Location = new System.Drawing.Point(146, 25);
            this.phoneMtb.Mask = "+7 (999) 000-00-00";
            this.phoneMtb.Name = "phoneMtb";
            this.phoneMtb.Size = new System.Drawing.Size(143, 26);
            this.phoneMtb.TabIndex = 23;
            this.phoneMtb.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.phoneMtb_MaskInputRejected);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.passTb);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.loginTb);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(353, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(295, 112);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Данные для авторизации";
            // 
            // passTb
            // 
            this.passTb.Location = new System.Drawing.Point(75, 60);
            this.passTb.MaxLength = 45;
            this.passTb.Name = "passTb";
            this.passTb.Size = new System.Drawing.Size(214, 26);
            this.passTb.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 22);
            this.label8.TabIndex = 26;
            this.label8.Text = "Пароль";
            // 
            // loginTb
            // 
            this.loginTb.Location = new System.Drawing.Point(75, 28);
            this.loginTb.MaxLength = 45;
            this.loginTb.Name = "loginTb";
            this.loginTb.Size = new System.Drawing.Size(214, 26);
            this.loginTb.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 22);
            this.label7.TabIndex = 25;
            this.label7.Text = "Логин";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(34)))), ((int)(((byte)(155)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(490, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 34);
            this.button2.TabIndex = 8;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(201)))), ((int)(((byte)(36)))));
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Location = new System.Drawing.Point(12, 214);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(158, 34);
            this.addBtn.TabIndex = 9;
            this.addBtn.Text = "Добавить";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // UserAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(656, 260);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(672, 299);
            this.MinimumSize = new System.Drawing.Size(672, 299);
            this.Name = "UserAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление пользователя";
            this.Load += new System.EventHandler(this.UserAddForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserAddForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.TextBox lastNameTb;
        private System.Windows.Forms.TextBox surnameTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox roleCb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox phoneMtb;
        private System.Windows.Forms.TextBox emailTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox loginTb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox passTb;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button addBtn;
    }
}