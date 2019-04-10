namespace sql
{
    partial class NewOrder
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
            this.panelOrder = new System.Windows.Forms.Panel();
            this.lableNoDo = new System.Windows.Forms.Label();
            this.LableDo = new System.Windows.Forms.Label();
            this.butSaveOrder = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.labelSelectBrigad = new System.Windows.Forms.Label();
            this.butAddOrder = new System.Windows.Forms.Button();
            this.BoxErrors = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butBrigadSeach = new System.Windows.Forms.Button();
            this.Garant = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CommentBox = new System.Windows.Forms.TextBox();
            this.LableDate = new System.Windows.Forms.Label();
            this.BoxEquipment = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelOrder.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOrder
            // 
            this.panelOrder.Controls.Add(this.lableNoDo);
            this.panelOrder.Controls.Add(this.LableDo);
            this.panelOrder.Controls.Add(this.butSaveOrder);
            this.panelOrder.Controls.Add(this.butCancel);
            this.panelOrder.Controls.Add(this.labelSelectBrigad);
            this.panelOrder.Controls.Add(this.butAddOrder);
            this.panelOrder.Controls.Add(this.BoxErrors);
            this.panelOrder.Controls.Add(this.label5);
            this.panelOrder.Controls.Add(this.butBrigadSeach);
            this.panelOrder.Controls.Add(this.Garant);
            this.panelOrder.Controls.Add(this.groupBox3);
            this.panelOrder.Controls.Add(this.LableDate);
            this.panelOrder.Controls.Add(this.BoxEquipment);
            this.panelOrder.Controls.Add(this.label4);
            this.panelOrder.Controls.Add(this.labelName);
            this.panelOrder.Controls.Add(this.label3);
            this.panelOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrder.Location = new System.Drawing.Point(0, 0);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(628, 339);
            this.panelOrder.TabIndex = 13;
            // 
            // lableNoDo
            // 
            this.lableNoDo.AutoSize = true;
            this.lableNoDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lableNoDo.ForeColor = System.Drawing.Color.Lime;
            this.lableNoDo.Location = new System.Drawing.Point(140, 306);
            this.lableNoDo.Name = "lableNoDo";
            this.lableNoDo.Size = new System.Drawing.Size(73, 15);
            this.lableNoDo.TabIndex = 23;
            this.lableNoDo.Text = "Выполнено";
            this.lableNoDo.Visible = false;
            // 
            // LableDo
            // 
            this.LableDo.AutoSize = true;
            this.LableDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LableDo.ForeColor = System.Drawing.Color.Red;
            this.LableDo.Location = new System.Drawing.Point(128, 304);
            this.LableDo.Name = "LableDo";
            this.LableDo.Size = new System.Drawing.Size(102, 16);
            this.LableDo.TabIndex = 22;
            this.LableDo.Text = "Не выполнено";
            this.LableDo.Visible = false;
            // 
            // butSaveOrder
            // 
            this.butSaveOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butSaveOrder.Enabled = false;
            this.butSaveOrder.Location = new System.Drawing.Point(499, 301);
            this.butSaveOrder.Name = "butSaveOrder";
            this.butSaveOrder.Size = new System.Drawing.Size(115, 24);
            this.butSaveOrder.TabIndex = 21;
            this.butSaveOrder.Text = "Сохранить";
            this.butSaveOrder.UseVisualStyleBackColor = true;
            this.butSaveOrder.Visible = false;
            this.butSaveOrder.Click += new System.EventHandler(this.butSaveOrder_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.Enabled = false;
            this.butCancel.Location = new System.Drawing.Point(314, 302);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(179, 23);
            this.butCancel.TabIndex = 20;
            this.butCancel.Text = "Отменить выполнение";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Visible = false;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // labelSelectBrigad
            // 
            this.labelSelectBrigad.AutoSize = true;
            this.labelSelectBrigad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSelectBrigad.Location = new System.Drawing.Point(311, 272);
            this.labelSelectBrigad.Name = "labelSelectBrigad";
            this.labelSelectBrigad.Size = new System.Drawing.Size(138, 16);
            this.labelSelectBrigad.TabIndex = 19;
            this.labelSelectBrigad.Text = "Выбранная бригада";
            // 
            // butAddOrder
            // 
            this.butAddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddOrder.Enabled = false;
            this.butAddOrder.Location = new System.Drawing.Point(499, 301);
            this.butAddOrder.Name = "butAddOrder";
            this.butAddOrder.Size = new System.Drawing.Size(115, 23);
            this.butAddOrder.TabIndex = 18;
            this.butAddOrder.Text = "Оформить заказ";
            this.butAddOrder.UseVisualStyleBackColor = true;
            this.butAddOrder.Visible = false;
            this.butAddOrder.Click += new System.EventHandler(this.butAddOrder_Click);
            // 
            // BoxErrors
            // 
            this.BoxErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BoxErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BoxErrors.FormattingEnabled = true;
            this.BoxErrors.Location = new System.Drawing.Point(131, 271);
            this.BoxErrors.Name = "BoxErrors";
            this.BoxErrors.Size = new System.Drawing.Size(173, 21);
            this.BoxErrors.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(7, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Причина отказа:";
            // 
            // butBrigadSeach
            // 
            this.butBrigadSeach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBrigadSeach.Location = new System.Drawing.Point(499, 269);
            this.butBrigadSeach.Name = "butBrigadSeach";
            this.butBrigadSeach.Size = new System.Drawing.Size(115, 23);
            this.butBrigadSeach.TabIndex = 15;
            this.butBrigadSeach.Text = "Выбор бригады";
            this.butBrigadSeach.UseVisualStyleBackColor = true;
            this.butBrigadSeach.Click += new System.EventHandler(this.butBrigadSeach_Click_1);
            // 
            // Garant
            // 
            this.Garant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Garant.AutoSize = true;
            this.Garant.Enabled = false;
            this.Garant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Garant.Location = new System.Drawing.Point(523, 58);
            this.Garant.Name = "Garant";
            this.Garant.Size = new System.Drawing.Size(88, 20);
            this.Garant.TabIndex = 14;
            this.Garant.Text = "Гарантия";
            this.Garant.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.CommentBox);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(10, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(604, 179);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Описание:";
            // 
            // CommentBox
            // 
            this.CommentBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommentBox.Location = new System.Drawing.Point(3, 18);
            this.CommentBox.MaxLength = 100;
            this.CommentBox.Multiline = true;
            this.CommentBox.Name = "CommentBox";
            this.CommentBox.Size = new System.Drawing.Size(598, 158);
            this.CommentBox.TabIndex = 0;
            // 
            // LableDate
            // 
            this.LableDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LableDate.AutoSize = true;
            this.LableDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LableDate.Location = new System.Drawing.Point(519, 21);
            this.LableDate.Name = "LableDate";
            this.LableDate.Size = new System.Drawing.Size(44, 20);
            this.LableDate.TabIndex = 12;
            this.LableDate.Text = "Date";
            // 
            // BoxEquipment
            // 
            this.BoxEquipment.FormattingEnabled = true;
            this.BoxEquipment.Location = new System.Drawing.Point(183, 58);
            this.BoxEquipment.Name = "BoxEquipment";
            this.BoxEquipment.Size = new System.Drawing.Size(121, 21);
            this.BoxEquipment.TabIndex = 10;
            this.BoxEquipment.SelectedIndexChanged += new System.EventHandler(this.BoxEquipment_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Оборудование:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(186, 21);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(51, 20);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Заказчик:";
            // 
            // NewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 339);
            this.Controls.Add(this.panelOrder);
            this.Name = "NewOrder";
            this.Text = "Заказ";
            this.panelOrder.ResumeLayout(false);
            this.panelOrder.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOrder;
        private System.Windows.Forms.Button butAddOrder;
        private System.Windows.Forms.ComboBox BoxErrors;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button butBrigadSeach;
        private System.Windows.Forms.CheckBox Garant;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox CommentBox;
        private System.Windows.Forms.Label LableDate;
        private System.Windows.Forms.ComboBox BoxEquipment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelSelectBrigad;
        private System.Windows.Forms.Button butSaveOrder;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label LableDo;
        private System.Windows.Forms.Label lableNoDo;
    }
}