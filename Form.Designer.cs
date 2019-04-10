namespace sql
{
    partial class Transaction
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
            this.butWriteFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butPathCheck = new System.Windows.Forms.Button();
            this.butPathAct = new System.Windows.Forms.Button();
            this.butPathDB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textPathCheck = new System.Windows.Forms.TextBox();
            this.textPathAct = new System.Windows.Forms.TextBox();
            this.textPathDB = new System.Windows.Forms.TextBox();
            this.checkCheck = new System.Windows.Forms.CheckBox();
            this.checkAct = new System.Windows.Forms.CheckBox();
            this.checkDB = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butSaveCheck = new System.Windows.Forms.Button();
            this.butSaveAct = new System.Windows.Forms.Button();
            this.textSavePathCheck = new System.Windows.Forms.TextBox();
            this.textSavePathAct = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkSaveCheck = new System.Windows.Forms.CheckBox();
            this.checkSaveAct = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // butWriteFile
            // 
            this.butWriteFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butWriteFile.Location = new System.Drawing.Point(511, 279);
            this.butWriteFile.Name = "butWriteFile";
            this.butWriteFile.Size = new System.Drawing.Size(88, 23);
            this.butWriteFile.TabIndex = 12;
            this.butWriteFile.Text = "Сохранить";
            this.butWriteFile.UseVisualStyleBackColor = true;
            this.butWriteFile.Click += new System.EventHandler(this.butWriteFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.butPathCheck);
            this.groupBox1.Controls.Add(this.butPathAct);
            this.groupBox1.Controls.Add(this.butPathDB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textPathCheck);
            this.groupBox1.Controls.Add(this.textPathAct);
            this.groupBox1.Controls.Add(this.textPathDB);
            this.groupBox1.Controls.Add(this.checkCheck);
            this.groupBox1.Controls.Add(this.checkAct);
            this.groupBox1.Controls.Add(this.checkDB);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 125);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Путь к файлам:";
            // 
            // butPathCheck
            // 
            this.butPathCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPathCheck.Enabled = false;
            this.butPathCheck.Location = new System.Drawing.Point(561, 92);
            this.butPathCheck.Name = "butPathCheck";
            this.butPathCheck.Size = new System.Drawing.Size(24, 23);
            this.butPathCheck.TabIndex = 23;
            this.butPathCheck.Text = "...";
            this.butPathCheck.UseVisualStyleBackColor = true;
            this.butPathCheck.Click += new System.EventHandler(this.butPathCheck_Click);
            // 
            // butPathAct
            // 
            this.butPathAct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPathAct.Enabled = false;
            this.butPathAct.Location = new System.Drawing.Point(561, 66);
            this.butPathAct.Name = "butPathAct";
            this.butPathAct.Size = new System.Drawing.Size(24, 23);
            this.butPathAct.TabIndex = 22;
            this.butPathAct.Text = "...";
            this.butPathAct.UseVisualStyleBackColor = true;
            this.butPathAct.Click += new System.EventHandler(this.butPathAct_Click);
            // 
            // butPathDB
            // 
            this.butPathDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPathDB.Enabled = false;
            this.butPathDB.Location = new System.Drawing.Point(561, 40);
            this.butPathDB.Name = "butPathDB";
            this.butPathDB.Size = new System.Drawing.Size(24, 23);
            this.butPathDB.TabIndex = 21;
            this.butPathDB.Text = "...";
            this.butPathDB.UseVisualStyleBackColor = true;
            this.butPathDB.Click += new System.EventHandler(this.butPathDB_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Путь к шаблону Чеков:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Путь к шаблону Актов:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Путь к БД:";
            // 
            // textPathCheck
            // 
            this.textPathCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPathCheck.Enabled = false;
            this.textPathCheck.Location = new System.Drawing.Point(141, 94);
            this.textPathCheck.Name = "textPathCheck";
            this.textPathCheck.Size = new System.Drawing.Size(414, 20);
            this.textPathCheck.TabIndex = 17;
            // 
            // textPathAct
            // 
            this.textPathAct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPathAct.Enabled = false;
            this.textPathAct.Location = new System.Drawing.Point(141, 68);
            this.textPathAct.Name = "textPathAct";
            this.textPathAct.Size = new System.Drawing.Size(414, 20);
            this.textPathAct.TabIndex = 16;
            // 
            // textPathDB
            // 
            this.textPathDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPathDB.Enabled = false;
            this.textPathDB.Location = new System.Drawing.Point(141, 42);
            this.textPathDB.Name = "textPathDB";
            this.textPathDB.Size = new System.Drawing.Size(414, 20);
            this.textPathDB.TabIndex = 15;
            // 
            // checkCheck
            // 
            this.checkCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkCheck.AutoSize = true;
            this.checkCheck.Location = new System.Drawing.Point(362, 19);
            this.checkCheck.Name = "checkCheck";
            this.checkCheck.Size = new System.Drawing.Size(215, 17);
            this.checkCheck.TabIndex = 14;
            this.checkCheck.Text = "Изменить положение шаблона чеков";
            this.checkCheck.UseVisualStyleBackColor = true;
            this.checkCheck.CheckedChanged += new System.EventHandler(this.checkCheck_CheckedChanged);
            // 
            // checkAct
            // 
            this.checkAct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAct.AutoSize = true;
            this.checkAct.Location = new System.Drawing.Point(141, 19);
            this.checkAct.Name = "checkAct";
            this.checkAct.Size = new System.Drawing.Size(215, 17);
            this.checkAct.TabIndex = 13;
            this.checkAct.Text = "Изменить положение шаблона актов";
            this.checkAct.UseVisualStyleBackColor = true;
            this.checkAct.CheckedChanged += new System.EventHandler(this.checkAct_CheckedChanged);
            // 
            // checkDB
            // 
            this.checkDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDB.AutoSize = true;
            this.checkDB.Location = new System.Drawing.Point(6, 19);
            this.checkDB.Name = "checkDB";
            this.checkDB.Size = new System.Drawing.Size(129, 17);
            this.checkDB.TabIndex = 12;
            this.checkDB.Text = "Изменить адрес БД";
            this.checkDB.UseVisualStyleBackColor = true;
            this.checkDB.CheckedChanged += new System.EventHandler(this.checkDB_CheckedChanged);
            this.checkDB.Enter += new System.EventHandler(this.butPathDB_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.butSaveCheck);
            this.groupBox2.Controls.Add(this.butSaveAct);
            this.groupBox2.Controls.Add(this.textSavePathCheck);
            this.groupBox2.Controls.Add(this.textSavePathAct);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.checkSaveCheck);
            this.groupBox2.Controls.Add(this.checkSaveAct);
            this.groupBox2.Location = new System.Drawing.Point(12, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 111);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Места сохранения:";
            // 
            // butSaveCheck
            // 
            this.butSaveCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSaveCheck.Enabled = false;
            this.butSaveCheck.Location = new System.Drawing.Point(561, 81);
            this.butSaveCheck.Name = "butSaveCheck";
            this.butSaveCheck.Size = new System.Drawing.Size(24, 23);
            this.butSaveCheck.TabIndex = 7;
            this.butSaveCheck.Text = "...";
            this.butSaveCheck.UseVisualStyleBackColor = true;
            this.butSaveCheck.Click += new System.EventHandler(this.butSaveCheck_Click);
            // 
            // butSaveAct
            // 
            this.butSaveAct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSaveAct.Enabled = false;
            this.butSaveAct.Location = new System.Drawing.Point(561, 47);
            this.butSaveAct.Name = "butSaveAct";
            this.butSaveAct.Size = new System.Drawing.Size(24, 23);
            this.butSaveAct.TabIndex = 6;
            this.butSaveAct.Text = "...";
            this.butSaveAct.UseVisualStyleBackColor = true;
            this.butSaveAct.Click += new System.EventHandler(this.butSaveAct_Click);
            // 
            // textSavePathCheck
            // 
            this.textSavePathCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSavePathCheck.Enabled = false;
            this.textSavePathCheck.Location = new System.Drawing.Point(170, 83);
            this.textSavePathCheck.Name = "textSavePathCheck";
            this.textSavePathCheck.Size = new System.Drawing.Size(385, 20);
            this.textSavePathCheck.TabIndex = 5;
            // 
            // textSavePathAct
            // 
            this.textSavePathAct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSavePathAct.Enabled = false;
            this.textSavePathAct.Location = new System.Drawing.Point(170, 47);
            this.textSavePathAct.Name = "textSavePathAct";
            this.textSavePathAct.Size = new System.Drawing.Size(385, 20);
            this.textSavePathAct.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Путь в месту хранения чеков:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Путь к месту хранения актов:";
            // 
            // checkSaveCheck
            // 
            this.checkSaveCheck.AutoSize = true;
            this.checkSaveCheck.Location = new System.Drawing.Point(189, 19);
            this.checkSaveCheck.Name = "checkSaveCheck";
            this.checkSaveCheck.Size = new System.Drawing.Size(186, 17);
            this.checkSaveCheck.TabIndex = 1;
            this.checkSaveCheck.Text = "Выбрать место хранения чеков";
            this.checkSaveCheck.UseVisualStyleBackColor = true;
            this.checkSaveCheck.CheckedChanged += new System.EventHandler(this.checkSaveCheck_CheckedChanged);
            // 
            // checkSaveAct
            // 
            this.checkSaveAct.AutoSize = true;
            this.checkSaveAct.Location = new System.Drawing.Point(6, 19);
            this.checkSaveAct.Name = "checkSaveAct";
            this.checkSaveAct.Size = new System.Drawing.Size(174, 17);
            this.checkSaveAct.TabIndex = 0;
            this.checkSaveAct.Text = "Выбрать место хрненя актов";
            this.checkSaveAct.UseVisualStyleBackColor = true;
            this.checkSaveAct.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
            // 
            // Transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 314);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butWriteFile);
            this.Name = "Transaction";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "Form";
            this.Load += new System.EventHandler(this.Transaction_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button butWriteFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butPathCheck;
        private System.Windows.Forms.Button butPathAct;
        private System.Windows.Forms.Button butPathDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPathCheck;
        private System.Windows.Forms.TextBox textPathAct;
        private System.Windows.Forms.TextBox textPathDB;
        private System.Windows.Forms.CheckBox checkCheck;
        private System.Windows.Forms.CheckBox checkAct;
        private System.Windows.Forms.CheckBox checkDB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textSavePathCheck;
        private System.Windows.Forms.TextBox textSavePathAct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkSaveCheck;
        private System.Windows.Forms.CheckBox checkSaveAct;
        private System.Windows.Forms.Button butSaveCheck;
        private System.Windows.Forms.Button butSaveAct;
    }
}

