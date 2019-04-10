namespace sql
{
    partial class CallManager
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.butUpdateClient = new System.Windows.Forms.Button();
            this.butDeletClient = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.NomberClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClearName = new System.Windows.Forms.Label();
            this.butFaind = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabOrder = new System.Windows.Forms.TabPage();
            this.butSave = new System.Windows.Forms.Button();
            this.butDeleteOrder = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TableOrder = new System.Windows.Forms.DataGridView();
            this.NameOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdressClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butAddOrder = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabOrder.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabOrder);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(655, 312);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.butUpdateClient);
            this.tabPage1.Controls.Add(this.butDeletClient);
            this.tabPage1.Controls.Add(this.butAdd);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(647, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Клиенты";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // butUpdateClient
            // 
            this.butUpdateClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butUpdateClient.Enabled = false;
            this.butUpdateClient.Location = new System.Drawing.Point(137, 249);
            this.butUpdateClient.Name = "butUpdateClient";
            this.butUpdateClient.Size = new System.Drawing.Size(158, 23);
            this.butUpdateClient.TabIndex = 4;
            this.butUpdateClient.Text = "Изменить";
            this.butUpdateClient.UseVisualStyleBackColor = true;
            this.butUpdateClient.Click += new System.EventHandler(this.butUpdateClient_Click);
            // 
            // butDeletClient
            // 
            this.butDeletClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDeletClient.Enabled = false;
            this.butDeletClient.Location = new System.Drawing.Point(310, 249);
            this.butDeletClient.Name = "butDeletClient";
            this.butDeletClient.Size = new System.Drawing.Size(158, 23);
            this.butDeletClient.TabIndex = 3;
            this.butDeletClient.Text = "Удалить";
            this.butDeletClient.UseVisualStyleBackColor = true;
            this.butDeletClient.Click += new System.EventHandler(this.butDeletClient_Click);
            // 
            // butAdd
            // 
            this.butAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAdd.Location = new System.Drawing.Point(483, 249);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(158, 23);
            this.butAdd.TabIndex = 2;
            this.butAdd.Text = "Новый клиент";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataTable);
            this.groupBox2.Location = new System.Drawing.Point(8, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(633, 157);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Клиенты:";
            // 
            // dataTable
            // 
            this.dataTable.AllowUserToAddRows = false;
            this.dataTable.AllowUserToDeleteRows = false;
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NomberClient,
            this.Name,
            this.Adress,
            this.Phone});
            this.dataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTable.Location = new System.Drawing.Point(3, 16);
            this.dataTable.Name = "dataTable";
            this.dataTable.ReadOnly = true;
            this.dataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataTable.Size = new System.Drawing.Size(627, 138);
            this.dataTable.TabIndex = 0;
            this.dataTable.DoubleClick += new System.EventHandler(this.dataTable_DoubleClick);
            // 
            // NomberClient
            // 
            this.NomberClient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.NomberClient.HeaderText = "№";
            this.NomberClient.Name = "NomberClient";
            this.NomberClient.ReadOnly = true;
            this.NomberClient.Width = 43;
            // 
            // Name
            // 
            this.Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Name.HeaderText = "ФИО";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Name.Width = 59;
            // 
            // Adress
            // 
            this.Adress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Adress.HeaderText = "Адрес";
            this.Adress.Name = "Adress";
            this.Adress.ReadOnly = true;
            this.Adress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Adress.Width = 63;
            // 
            // Phone
            // 
            this.Phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Phone.HeaderText = "Телефон";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.Width = 77;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ClearName);
            this.groupBox1.Controls.Add(this.butFaind);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск:";
            // 
            // ClearName
            // 
            this.ClearName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearName.AutoSize = true;
            this.ClearName.Enabled = false;
            this.ClearName.Location = new System.Drawing.Point(610, 20);
            this.ClearName.Name = "ClearName";
            this.ClearName.Size = new System.Drawing.Size(14, 13);
            this.ClearName.TabIndex = 5;
            this.ClearName.Text = "Х";
            this.ClearName.Click += new System.EventHandler(this.ClearName_Click);
            // 
            // butFaind
            // 
            this.butFaind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butFaind.Location = new System.Drawing.Point(552, 43);
            this.butFaind.Name = "butFaind";
            this.butFaind.Size = new System.Drawing.Size(75, 25);
            this.butFaind.TabIndex = 4;
            this.butFaind.Text = "Поиск";
            this.butFaind.UseVisualStyleBackColor = true;
            this.butFaind.Click += new System.EventHandler(this.butFaind_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(67, 17);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(560, 20);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Запрос:";
            // 
            // tabOrder
            // 
            this.tabOrder.Controls.Add(this.butSave);
            this.tabOrder.Controls.Add(this.butDeleteOrder);
            this.tabOrder.Controls.Add(this.groupBox3);
            this.tabOrder.Controls.Add(this.butAddOrder);
            this.tabOrder.Location = new System.Drawing.Point(4, 22);
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrder.Size = new System.Drawing.Size(647, 286);
            this.tabOrder.TabIndex = 1;
            this.tabOrder.Text = "Заказы";
            this.tabOrder.UseVisualStyleBackColor = true;
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.Enabled = false;
            this.butSave.Location = new System.Drawing.Point(98, 246);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(162, 34);
            this.butSave.TabIndex = 3;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butDeleteOrder
            // 
            this.butDeleteOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butDeleteOrder.Enabled = false;
            this.butDeleteOrder.Location = new System.Drawing.Point(286, 246);
            this.butDeleteOrder.Name = "butDeleteOrder";
            this.butDeleteOrder.Size = new System.Drawing.Size(162, 34);
            this.butDeleteOrder.TabIndex = 2;
            this.butDeleteOrder.Text = "Удалить";
            this.butDeleteOrder.UseVisualStyleBackColor = true;
            this.butDeleteOrder.Click += new System.EventHandler(this.butDeleteOrder_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.TableOrder);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(631, 234);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Заказы";
            // 
            // TableOrder
            // 
            this.TableOrder.AllowUserToAddRows = false;
            this.TableOrder.AllowUserToDeleteRows = false;
            this.TableOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameOrder,
            this.Date,
            this.NameClient,
            this.AdressClient,
            this.Comment});
            this.TableOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableOrder.Location = new System.Drawing.Point(3, 16);
            this.TableOrder.Name = "TableOrder";
            this.TableOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TableOrder.Size = new System.Drawing.Size(625, 215);
            this.TableOrder.TabIndex = 0;
            this.TableOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableOrder_CellClick);
            this.TableOrder.DoubleClick += new System.EventHandler(this.TableOrder_DoubleClick);
            // 
            // NameOrder
            // 
            this.NameOrder.HeaderText = "№ Заявки";
            this.NameOrder.Name = "NameOrder";
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата подачи заявки";
            this.Date.Name = "Date";
            // 
            // NameClient
            // 
            this.NameClient.HeaderText = "ФИО Клиента";
            this.NameClient.Name = "NameClient";
            // 
            // AdressClient
            // 
            this.AdressClient.HeaderText = "Адрес клиента";
            this.AdressClient.Name = "AdressClient";
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Краткое описание";
            this.Comment.Name = "Comment";
            // 
            // butAddOrder
            // 
            this.butAddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddOrder.Enabled = false;
            this.butAddOrder.Location = new System.Drawing.Point(477, 246);
            this.butAddOrder.Name = "butAddOrder";
            this.butAddOrder.Size = new System.Drawing.Size(162, 34);
            this.butAddOrder.TabIndex = 0;
            this.butAddOrder.Text = "Новый заказ";
            this.butAddOrder.UseVisualStyleBackColor = true;
            this.butAddOrder.Click += new System.EventHandler(this.butAddOrder_Click);
            // 
            // CallManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 312);
            this.Controls.Add(this.tabControl1);
            //this.Name = "CallManager";
            this.Text = "Диспетчер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CallManager_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabOrder.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butFaind;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
#pragma warning disable CS0169 // Поле "CallManager.клиентаDataGridViewTextBoxColumn" никогда не используется.
        private System.Windows.Forms.DataGridViewTextBoxColumn клиентаDataGridViewTextBoxColumn;
#pragma warning restore CS0169 // Поле "CallManager.клиентаDataGridViewTextBoxColumn" никогда не используется.
#pragma warning disable CS0169 // Поле "CallManager.фИОКлиентаDataGridViewTextBoxColumn" никогда не используется.
        private System.Windows.Forms.DataGridViewTextBoxColumn фИОКлиентаDataGridViewTextBoxColumn;
#pragma warning restore CS0169 // Поле "CallManager.фИОКлиентаDataGridViewTextBoxColumn" никогда не используется.
#pragma warning disable CS0169 // Поле "CallManager.адресКлиентаDataGridViewTextBoxColumn" никогда не используется.
        private System.Windows.Forms.DataGridViewTextBoxColumn адресКлиентаDataGridViewTextBoxColumn;
#pragma warning restore CS0169 // Поле "CallManager.адресКлиентаDataGridViewTextBoxColumn" никогда не используется.
#pragma warning disable CS0169 // Поле "CallManager.телефонКлиентаDataGridViewTextBoxColumn" никогда не используется.
        private System.Windows.Forms.DataGridViewTextBoxColumn телефонКлиентаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomberClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.TabPage tabOrder;
        private System.Windows.Forms.Button butAddOrder;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView TableOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdressClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.Button butDeleteOrder;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butUpdateClient;
        private System.Windows.Forms.Button butDeletClient;
        private System.Windows.Forms.Label ClearName;
#pragma warning restore CS0169 // Поле "CallManager.телефонКлиентаDataGridViewTextBoxColumn" никогда не используется.
#pragma warning disable CS0108 // "CallManager.Name" скрывает наследуемый член "Control.Name". Если скрытие было намеренным, используйте ключевое слово new.
#pragma warning restore CS0108 // "CallManager.Name" скрывает наследуемый член "Control.Name". Если скрытие было намеренным, используйте ключевое слово new.
    }
}