namespace DIPLOM_RAYKHERT.MyForm
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.панельУправляющегоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типКабинетаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ролиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статусыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.программноеОбеспечениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пользователиСистемыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.договорыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменитьПарольToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.курсыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обучающиесяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.преподавателиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.группыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кабинетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расписаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сертификатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прайсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.базаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сделатьРезервнуюКопиюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.восстановитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kurs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fioTb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(34)))), ((int)(((byte)(155)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(1734, 995);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 34);
            this.button2.TabIndex = 7;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(34)))), ((int)(((byte)(155)))));
            this.menuStrip1.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.панельУправляющегоToolStripMenuItem,
            this.договорыToolStripMenuItem,
            this.сменитьПарольToolStripMenuItem,
            this.курсыToolStripMenuItem,
            this.обучающиесяToolStripMenuItem,
            this.преподавателиToolStripMenuItem,
            this.группыToolStripMenuItem,
            this.кабинетыToolStripMenuItem,
            this.расписаниеToolStripMenuItem,
            this.сертификатыToolStripMenuItem,
            this.прайсToolStripMenuItem,
            this.toolStripMenuItem1,
            this.базаДанныхToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(1904, 30);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // панельУправляющегоToolStripMenuItem
            // 
            this.панельУправляющегоToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пользователиСистемыToolStripMenuItem});
            this.панельУправляющегоToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.панельУправляющегоToolStripMenuItem.Name = "панельУправляющегоToolStripMenuItem";
            this.панельУправляющегоToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.панельУправляющегоToolStripMenuItem.Text = "Панель управляющего";
            this.панельУправляющегоToolStripMenuItem.Visible = false;
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.типКабинетаToolStripMenuItem,
            this.ролиToolStripMenuItem,
            this.статусыToolStripMenuItem,
            this.программноеОбеспечениеToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // типКабинетаToolStripMenuItem
            // 
            this.типКабинетаToolStripMenuItem.Name = "типКабинетаToolStripMenuItem";
            this.типКабинетаToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.типКабинетаToolStripMenuItem.Text = "Тип кабинета";
            this.типКабинетаToolStripMenuItem.Click += new System.EventHandler(this.типКабинетаToolStripMenuItem_Click);
            // 
            // ролиToolStripMenuItem
            // 
            this.ролиToolStripMenuItem.Name = "ролиToolStripMenuItem";
            this.ролиToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.ролиToolStripMenuItem.Text = "Роли";
            this.ролиToolStripMenuItem.Click += new System.EventHandler(this.ролиToolStripMenuItem_Click);
            // 
            // статусыToolStripMenuItem
            // 
            this.статусыToolStripMenuItem.Name = "статусыToolStripMenuItem";
            this.статусыToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.статусыToolStripMenuItem.Text = "Статусы";
            this.статусыToolStripMenuItem.Click += new System.EventHandler(this.статусыToolStripMenuItem_Click);
            // 
            // программноеОбеспечениеToolStripMenuItem
            // 
            this.программноеОбеспечениеToolStripMenuItem.Name = "программноеОбеспечениеToolStripMenuItem";
            this.программноеОбеспечениеToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.программноеОбеспечениеToolStripMenuItem.Text = "Программное обеспечение";
            this.программноеОбеспечениеToolStripMenuItem.Click += new System.EventHandler(this.программноеОбеспечениеToolStripMenuItem_Click);
            // 
            // пользователиСистемыToolStripMenuItem
            // 
            this.пользователиСистемыToolStripMenuItem.Name = "пользователиСистемыToolStripMenuItem";
            this.пользователиСистемыToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.пользователиСистемыToolStripMenuItem.Text = "Пользователи системы";
            this.пользователиСистемыToolStripMenuItem.Click += new System.EventHandler(this.пользователиСистемыToolStripMenuItem_Click);
            // 
            // договорыToolStripMenuItem
            // 
            this.договорыToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.договорыToolStripMenuItem.Name = "договорыToolStripMenuItem";
            this.договорыToolStripMenuItem.Size = new System.Drawing.Size(95, 26);
            this.договорыToolStripMenuItem.Text = "Договоры";
            this.договорыToolStripMenuItem.Click += new System.EventHandler(this.договорыToolStripMenuItem_Click);
            // 
            // сменитьПарольToolStripMenuItem
            // 
            this.сменитьПарольToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.сменитьПарольToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.сменитьПарольToolStripMenuItem.Name = "сменитьПарольToolStripMenuItem";
            this.сменитьПарольToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.сменитьПарольToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.сменитьПарольToolStripMenuItem.Text = "Сменить пароль";
            this.сменитьПарольToolStripMenuItem.Click += new System.EventHandler(this.сменитьПарольToolStripMenuItem_Click);
            // 
            // курсыToolStripMenuItem
            // 
            this.курсыToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.курсыToolStripMenuItem.Name = "курсыToolStripMenuItem";
            this.курсыToolStripMenuItem.Size = new System.Drawing.Size(68, 26);
            this.курсыToolStripMenuItem.Text = "Курсы";
            this.курсыToolStripMenuItem.Click += new System.EventHandler(this.курсыToolStripMenuItem_Click);
            // 
            // обучающиесяToolStripMenuItem
            // 
            this.обучающиесяToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.обучающиесяToolStripMenuItem.Name = "обучающиесяToolStripMenuItem";
            this.обучающиесяToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.обучающиесяToolStripMenuItem.Text = "Обучающиеся";
            this.обучающиесяToolStripMenuItem.Click += new System.EventHandler(this.обучающиесяToolStripMenuItem_Click);
            // 
            // преподавателиToolStripMenuItem
            // 
            this.преподавателиToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.преподавателиToolStripMenuItem.Name = "преподавателиToolStripMenuItem";
            this.преподавателиToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.преподавателиToolStripMenuItem.Text = "Преподаватели";
            this.преподавателиToolStripMenuItem.Click += new System.EventHandler(this.преподавателиToolStripMenuItem_Click);
            // 
            // группыToolStripMenuItem
            // 
            this.группыToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.группыToolStripMenuItem.Name = "группыToolStripMenuItem";
            this.группыToolStripMenuItem.Size = new System.Drawing.Size(74, 26);
            this.группыToolStripMenuItem.Text = "Группы";
            this.группыToolStripMenuItem.Click += new System.EventHandler(this.группыToolStripMenuItem_Click);
            // 
            // кабинетыToolStripMenuItem
            // 
            this.кабинетыToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.кабинетыToolStripMenuItem.Name = "кабинетыToolStripMenuItem";
            this.кабинетыToolStripMenuItem.Size = new System.Drawing.Size(93, 26);
            this.кабинетыToolStripMenuItem.Text = "Кабинеты";
            this.кабинетыToolStripMenuItem.Click += new System.EventHandler(this.кабинетыToolStripMenuItem_Click);
            // 
            // расписаниеToolStripMenuItem
            // 
            this.расписаниеToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.расписаниеToolStripMenuItem.Name = "расписаниеToolStripMenuItem";
            this.расписаниеToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.расписаниеToolStripMenuItem.Text = "Расписание занятий";
            this.расписаниеToolStripMenuItem.Click += new System.EventHandler(this.расписаниеToolStripMenuItem_Click);
            // 
            // сертификатыToolStripMenuItem
            // 
            this.сертификатыToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.сертификатыToolStripMenuItem.Name = "сертификатыToolStripMenuItem";
            this.сертификатыToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.сертификатыToolStripMenuItem.Text = "Сертификаты";
            this.сертификатыToolStripMenuItem.Click += new System.EventHandler(this.сертификатыToolStripMenuItem_Click);
            // 
            // прайсToolStripMenuItem
            // 
            this.прайсToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.прайсToolStripMenuItem.Name = "прайсToolStripMenuItem";
            this.прайсToolStripMenuItem.Size = new System.Drawing.Size(66, 26);
            this.прайсToolStripMenuItem.Text = "Прайс";
            this.прайсToolStripMenuItem.Click += new System.EventHandler(this.прайсToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 26);
            this.toolStripMenuItem1.Text = "Статистика продаж";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // базаДанныхToolStripMenuItem
            // 
            this.базаДанныхToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.базаДанныхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сделатьРезервнуюКопиюToolStripMenuItem,
            this.восстановитьToolStripMenuItem});
            this.базаДанныхToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.базаДанныхToolStripMenuItem.Name = "базаДанныхToolStripMenuItem";
            this.базаДанныхToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.базаДанныхToolStripMenuItem.Size = new System.Drawing.Size(111, 26);
            this.базаДанныхToolStripMenuItem.Text = "База данных";
            // 
            // сделатьРезервнуюКопиюToolStripMenuItem
            // 
            this.сделатьРезервнуюКопиюToolStripMenuItem.Name = "сделатьРезервнуюКопиюToolStripMenuItem";
            this.сделатьРезервнуюКопиюToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.сделатьРезервнуюКопиюToolStripMenuItem.Text = "Сделать резервную копию";
            this.сделатьРезервнуюКопиюToolStripMenuItem.Click += new System.EventHandler(this.сделатьРезервнуюКопиюToolStripMenuItem_Click);
            // 
            // восстановитьToolStripMenuItem
            // 
            this.восстановитьToolStripMenuItem.Name = "восстановитьToolStripMenuItem";
            this.восстановитьToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.восстановитьToolStripMenuItem.Text = "Восстановить";
            this.восстановитьToolStripMenuItem.Click += new System.EventHandler(this.восстановитьToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(89)))), ((int)(((byte)(150)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Kurs,
            this.Column7,
            this.DATEE,
            this.Status});
            this.dataGridView1.Location = new System.Drawing.Point(0, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1904, 802);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.DataPropertyName = "id_заявки_на_обучение";
            this.Column1.HeaderText = "Номер заявки";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 105;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "ФИО обучающегося";
            this.Column2.HeaderText = "ФИО обучающегося";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Kurs
            // 
            this.Kurs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Kurs.DataPropertyName = "название";
            this.Kurs.HeaderText = "Курс";
            this.Kurs.Name = "Kurs";
            this.Kurs.ReadOnly = true;
            this.Kurs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.DataPropertyName = "ФИО менеджера";
            this.Column7.HeaderText = "ФИО менеджера";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DATEE
            // 
            this.DATEE.DataPropertyName = "дата_заявки";
            this.DATEE.HeaderText = "Дата заявки";
            this.DATEE.Name = "DATEE";
            this.DATEE.ReadOnly = true;
            this.DATEE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "статус";
            this.Status.HeaderText = "Статус заявки";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(12, 872);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 157);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление заявками";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Orange;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(12, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(209, 34);
            this.button4.TabIndex = 16;
            this.button4.Text = "Редактировать";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(12, 112);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(209, 34);
            this.button3.TabIndex = 12;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(201)))), ((int)(((byte)(36)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(12, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 34);
            this.button1.TabIndex = 11;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(8, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "Текущие заявки на обучение";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(1472, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Вы:";
            // 
            // fioTb
            // 
            this.fioTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fioTb.AutoSize = true;
            this.fioTb.BackColor = System.Drawing.Color.Transparent;
            this.fioTb.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.fioTb.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fioTb.Location = new System.Drawing.Point(1516, 39);
            this.fioTb.Name = "fioTb";
            this.fioTb.Size = new System.Drawing.Size(57, 22);
            this.fioTb.TabIndex = 14;
            this.fioTb.Text = "[ФИО]";
            this.fioTb.Click += new System.EventHandler(this.label3_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(420, 943);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(558, 35);
            this.label3.TabIndex = 15;
            this.label3.Text = "Опыт, создающий результат с 1991 года!";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fioTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1918, 1048);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная форма";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem панельУправляющегоToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типКабинетаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ролиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статусыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem программноеОбеспечениеToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label fioTb;
        private System.Windows.Forms.ToolStripMenuItem пользователиСистемыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменитьПарольToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem договорыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem курсыToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem обучающиесяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem преподавателиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem группыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кабинетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расписаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сертификатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прайсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kurs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.ToolStripMenuItem базаДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сделатьРезервнуюКопиюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem восстановитьToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}