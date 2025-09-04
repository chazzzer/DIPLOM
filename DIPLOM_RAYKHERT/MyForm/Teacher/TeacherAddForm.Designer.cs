namespace DIPLOM_RAYKHERT.MyForm.Teacher
{
    partial class TeacherAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherAddForm));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.emailTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.phoneMtb = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lastNameTb = new System.Windows.Forms.TextBox();
            this.surnameTb = new System.Windows.Forms.TextBox();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(201)))), ((int)(((byte)(36)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(10, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 34);
            this.button1.TabIndex = 35;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.emailTb);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.phoneMtb);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(313, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 123);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Контактная информация";
            // 
            // emailTb
            // 
            this.emailTb.Location = new System.Drawing.Point(92, 69);
            this.emailTb.MaxLength = 45;
            this.emailTb.Name = "emailTb";
            this.emailTb.Size = new System.Drawing.Size(197, 26);
            this.emailTb.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 22);
            this.label7.TabIndex = 28;
            this.label7.Text = "Эл. почта";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 22);
            this.label9.TabIndex = 26;
            this.label9.Text = "Номер телефона";
            // 
            // phoneMtb
            // 
            this.phoneMtb.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.phoneMtb.Location = new System.Drawing.Point(146, 37);
            this.phoneMtb.Mask = "+7 (999) 000-00-00";
            this.phoneMtb.Name = "phoneMtb";
            this.phoneMtb.Size = new System.Drawing.Size(143, 26);
            this.phoneMtb.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lastNameTb);
            this.groupBox1.Controls.Add(this.surnameTb);
            this.groupBox1.Controls.Add(this.nameTb);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(10, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 123);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Основные сведения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 22);
            this.label3.TabIndex = 12;
            this.label3.Text = "Отчество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "Фамилия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Имя";
            // 
            // lastNameTb
            // 
            this.lastNameTb.Location = new System.Drawing.Point(90, 88);
            this.lastNameTb.MaxLength = 45;
            this.lastNameTb.Name = "lastNameTb";
            this.lastNameTb.Size = new System.Drawing.Size(199, 26);
            this.lastNameTb.TabIndex = 9;
            this.lastNameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.surnameTb_KeyPress);
            // 
            // surnameTb
            // 
            this.surnameTb.Location = new System.Drawing.Point(90, 23);
            this.surnameTb.MaxLength = 45;
            this.surnameTb.Name = "surnameTb";
            this.surnameTb.Size = new System.Drawing.Size(199, 26);
            this.surnameTb.TabIndex = 8;
            this.surnameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.surnameTb_KeyPress);
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(90, 55);
            this.nameTb.MaxLength = 45;
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(199, 26);
            this.nameTb.TabIndex = 7;
            this.nameTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.surnameTb_KeyPress);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(34)))), ((int)(((byte)(155)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(465, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 34);
            this.button2.TabIndex = 31;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TeacherAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(621, 178);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(637, 217);
            this.MinimumSize = new System.Drawing.Size(637, 217);
            this.Name = "TeacherAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление преподавателя";
            this.Load += new System.EventHandler(this.TeacherAddForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TeacherAddForm_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox emailTb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox phoneMtb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lastNameTb;
        private System.Windows.Forms.TextBox surnameTb;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Button button2;
    }
}