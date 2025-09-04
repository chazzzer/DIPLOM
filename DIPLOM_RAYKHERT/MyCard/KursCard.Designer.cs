namespace DIPLOM_RAYKHERT
{
    partial class KursCard
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KursCard));
            this.kursPb = new System.Windows.Forms.PictureBox();
            this.kursTb = new System.Windows.Forms.Label();
            this.priceTb = new System.Windows.Forms.Label();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.hoursTb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kursPb)).BeginInit();
            this.SuspendLayout();
            // 
            // kursPb
            // 
            this.kursPb.Location = new System.Drawing.Point(0, 0);
            this.kursPb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.kursPb.Name = "kursPb";
            this.kursPb.Size = new System.Drawing.Size(625, 250);
            this.kursPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.kursPb.TabIndex = 0;
            this.kursPb.TabStop = false;
            // 
            // kursTb
            // 
            this.kursTb.AutoSize = true;
            this.kursTb.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.kursTb.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.kursTb.Location = new System.Drawing.Point(14, 264);
            this.kursTb.Name = "kursTb";
            this.kursTb.Size = new System.Drawing.Size(160, 22);
            this.kursTb.TabIndex = 1;
            this.kursTb.Text = "[НАЗВАНИЕ КУРСА]";
            // 
            // priceTb
            // 
            this.priceTb.AutoSize = true;
            this.priceTb.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceTb.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.priceTb.Location = new System.Drawing.Point(13, 326);
            this.priceTb.Name = "priceTb";
            this.priceTb.Size = new System.Drawing.Size(110, 29);
            this.priceTb.TabIndex = 2;
            this.priceTb.Text = "[ПРАЙС]";
            // 
            // editBtn
            // 
            this.editBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("editBtn.BackgroundImage")));
            this.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtn.Location = new System.Drawing.Point(565, 260);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(48, 48);
            this.editBtn.TabIndex = 3;
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteBtn.BackgroundImage")));
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Location = new System.Drawing.Point(565, 319);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(48, 48);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // hoursTb
            // 
            this.hoursTb.AutoSize = true;
            this.hoursTb.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.hoursTb.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.hoursTb.Location = new System.Drawing.Point(14, 286);
            this.hoursTb.Name = "hoursTb";
            this.hoursTb.Size = new System.Drawing.Size(66, 22);
            this.hoursTb.TabIndex = 5;
            this.hoursTb.Text = "[ЧАСЫ]";
            // 
            // KursCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(34)))), ((int)(((byte)(155)))));
            this.Controls.Add(this.hoursTb);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.priceTb);
            this.Controls.Add(this.kursTb);
            this.Controls.Add(this.kursPb);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KursCard";
            this.Size = new System.Drawing.Size(625, 379);
            this.Load += new System.EventHandler(this.KursCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kursPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox kursPb;
        private System.Windows.Forms.Label kursTb;
        private System.Windows.Forms.Label priceTb;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label hoursTb;
    }
}
