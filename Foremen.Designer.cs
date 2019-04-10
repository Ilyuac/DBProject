namespace sql
{
    partial class Foremen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Foremen));
            this.IControl = new System.Windows.Forms.TabControl();
            this.Person = new System.Windows.Forms.TabPage();
            this.CheckListPerson = new System.Windows.Forms.CheckedListBox();
            this.Order = new System.Windows.Forms.TabPage();
            this.ListOrder = new System.Windows.Forms.ListBox();
            this.Act = new System.Windows.Forms.TabPage();
            this.groupAct = new System.Windows.Forms.GroupBox();
            this.butDoAct = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListDO = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BoxNomAct = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.UpdateMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Time = new System.Windows.Forms.Timer(this.components);
            this.IControl.SuspendLayout();
            this.Person.SuspendLayout();
            this.Order.SuspendLayout();
            this.Act.SuspendLayout();
            this.groupAct.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // IControl
            // 
            this.IControl.Controls.Add(this.Person);
            this.IControl.Controls.Add(this.Order);
            this.IControl.Controls.Add(this.Act);
            this.IControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IControl.Location = new System.Drawing.Point(0, 24);
            this.IControl.Name = "IControl";
            this.IControl.SelectedIndex = 0;
            this.IControl.Size = new System.Drawing.Size(575, 279);
            this.IControl.TabIndex = 0;
            this.IControl.SelectedIndexChanged += new System.EventHandler(this.IControl_SelectedIndexChanged);
            // 
            // Person
            // 
            this.Person.Controls.Add(this.CheckListPerson);
            this.Person.Location = new System.Drawing.Point(4, 22);
            this.Person.Name = "Person";
            this.Person.Padding = new System.Windows.Forms.Padding(3);
            this.Person.Size = new System.Drawing.Size(567, 253);
            this.Person.TabIndex = 0;
            this.Person.Text = "Сотрудники";
            this.Person.UseVisualStyleBackColor = true;
            // 
            // CheckListPerson
            // 
            this.CheckListPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckListPerson.FormattingEnabled = true;
            this.CheckListPerson.Location = new System.Drawing.Point(3, 3);
            this.CheckListPerson.Name = "CheckListPerson";
            this.CheckListPerson.Size = new System.Drawing.Size(561, 247);
            this.CheckListPerson.TabIndex = 0;
            // 
            // Order
            // 
            this.Order.Controls.Add(this.ListOrder);
            this.Order.Location = new System.Drawing.Point(4, 22);
            this.Order.Name = "Order";
            this.Order.Padding = new System.Windows.Forms.Padding(3);
            this.Order.Size = new System.Drawing.Size(567, 253);
            this.Order.TabIndex = 1;
            this.Order.Text = "Заказы";
            this.Order.UseVisualStyleBackColor = true;
            // 
            // ListOrder
            // 
            this.ListOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListOrder.FormattingEnabled = true;
            this.ListOrder.Location = new System.Drawing.Point(3, 3);
            this.ListOrder.Name = "ListOrder";
            this.ListOrder.Size = new System.Drawing.Size(561, 247);
            this.ListOrder.TabIndex = 0;
            this.ListOrder.SelectedIndexChanged += new System.EventHandler(this.ListOrder_SelectedIndexChanged);
            // 
            // Act
            // 
            this.Act.Controls.Add(this.groupAct);
            this.Act.Location = new System.Drawing.Point(4, 22);
            this.Act.Name = "Act";
            this.Act.Padding = new System.Windows.Forms.Padding(3);
            this.Act.Size = new System.Drawing.Size(567, 253);
            this.Act.TabIndex = 2;
            this.Act.Text = "Акт оказных услуг";
            this.Act.UseVisualStyleBackColor = true;
            // 
            // groupAct
            // 
            this.groupAct.Controls.Add(this.butDoAct);
            this.groupAct.Controls.Add(this.groupBox1);
            this.groupAct.Controls.Add(this.label1);
            this.groupAct.Controls.Add(this.BoxNomAct);
            this.groupAct.Controls.Add(this.progressBar1);
            this.groupAct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupAct.Location = new System.Drawing.Point(3, 3);
            this.groupAct.Name = "groupAct";
            this.groupAct.Size = new System.Drawing.Size(561, 247);
            this.groupAct.TabIndex = 0;
            this.groupAct.TabStop = false;
            this.groupAct.Text = "Акт оказанных услуг:";
            // 
            // butDoAct
            // 
            this.butDoAct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butDoAct.Location = new System.Drawing.Point(414, 206);
            this.butDoAct.Name = "butDoAct";
            this.butDoAct.Size = new System.Drawing.Size(141, 23);
            this.butDoAct.TabIndex = 4;
            this.butDoAct.Text = "Сформировать акт";
            this.butDoAct.UseVisualStyleBackColor = true;
            this.butDoAct.Click += new System.EventHandler(this.butDoAct_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkedListDO);
            this.groupBox1.Location = new System.Drawing.Point(6, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 152);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список работ:";
            // 
            // checkedListDO
            // 
            this.checkedListDO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListDO.FormattingEnabled = true;
            this.checkedListDO.Location = new System.Drawing.Point(3, 16);
            this.checkedListDO.Name = "checkedListDO";
            this.checkedListDO.Size = new System.Drawing.Size(543, 133);
            this.checkedListDO.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(166, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Заказ/Акт №";
            // 
            // BoxNomAct
            // 
            this.BoxNomAct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxNomAct.FormattingEnabled = true;
            this.BoxNomAct.Location = new System.Drawing.Point(307, 21);
            this.BoxNomAct.Name = "BoxNomAct";
            this.BoxNomAct.Size = new System.Drawing.Size(87, 21);
            this.BoxNomAct.TabIndex = 1;
            this.BoxNomAct.SelectedIndexChanged += new System.EventHandler(this.BoxNomAct_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 231);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(549, 10);
            this.progressBar1.TabIndex = 0;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateMenu,
            this.выходToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(575, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // UpdateMenu
            // 
            this.UpdateMenu.Image = ((System.Drawing.Image)(resources.GetObject("UpdateMenu.Image")));
            this.UpdateMenu.Name = "UpdateMenu";
            this.UpdateMenu.Size = new System.Drawing.Size(89, 20);
            this.UpdateMenu.Text = "Обновить";
            this.UpdateMenu.Click += new System.EventHandler(this.UpdateMenu_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // Foremen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 303);
            this.Controls.Add(this.IControl);
            this.Controls.Add(this.MenuStrip);
            this.Name = "Foremen";
            this.Text = "Бригадир";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Foremen_FormClosed);
            this.IControl.ResumeLayout(false);
            this.Person.ResumeLayout(false);
            this.Order.ResumeLayout(false);
            this.Act.ResumeLayout(false);
            this.groupAct.ResumeLayout(false);
            this.groupAct.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl IControl;
        private System.Windows.Forms.TabPage Person;
        private System.Windows.Forms.CheckedListBox CheckListPerson;
        private System.Windows.Forms.TabPage Order;
        private System.Windows.Forms.ListBox ListOrder;
        private System.Windows.Forms.TabPage Act;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem UpdateMenu;
        public System.Windows.Forms.GroupBox groupAct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BoxNomAct;
        private System.Windows.Forms.Button butDoAct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox checkedListDO;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Timer Time;
    }
}