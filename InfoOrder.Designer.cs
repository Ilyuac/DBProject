namespace sql
{
    partial class InfoOrder
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
            this.butPerform = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Comment = new System.Windows.Forms.Label();
            this.Adress = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Client = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.NomOrder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butEnd = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.butCheck = new System.Windows.Forms.Button();
            this.butPrintAct = new System.Windows.Forms.Button();
            this.butPrintCheck = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butPerform
            // 
            this.butPerform.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butPerform.Location = new System.Drawing.Point(8, 267);
            this.butPerform.Name = "butPerform";
            this.butPerform.Size = new System.Drawing.Size(608, 23);
            this.butPerform.TabIndex = 19;
            this.butPerform.Text = "Приступить к выполнению";
            this.butPerform.UseVisualStyleBackColor = true;
            this.butPerform.Click += new System.EventHandler(this.butPerform_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Comment);
            this.groupBox1.Location = new System.Drawing.Point(1, 116);
            this.groupBox1.MinimumSize = new System.Drawing.Size(615, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 145);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Описание:";
            // 
            // Comment
            // 
            this.Comment.AutoSize = true;
            this.Comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Comment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Comment.Location = new System.Drawing.Point(3, 16);
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(105, 24);
            this.Comment.TabIndex = 8;
            this.Comment.Text = "Описание:";
            // 
            // Adress
            // 
            this.Adress.AutoSize = true;
            this.Adress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Adress.Location = new System.Drawing.Point(117, 79);
            this.Adress.Name = "Adress";
            this.Adress.Size = new System.Drawing.Size(67, 24);
            this.Adress.TabIndex = 17;
            this.Adress.Text = "Адрес";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(14, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Адрес:";
            // 
            // Client
            // 
            this.Client.AutoSize = true;
            this.Client.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Client.Location = new System.Drawing.Point(117, 45);
            this.Client.Name = "Client";
            this.Client.Size = new System.Drawing.Size(92, 24);
            this.Client.TabIndex = 15;
            this.Client.Text = "Заказчик";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Заказчик:";
            // 
            // Date
            // 
            this.Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Date.AutoSize = true;
            this.Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Date.Location = new System.Drawing.Point(530, 5);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(44, 20);
            this.Date.TabIndex = 13;
            this.Date.Text = "Date";
            // 
            // NomOrder
            // 
            this.NomOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NomOrder.AutoSize = true;
            this.NomOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomOrder.Location = new System.Drawing.Point(337, 1);
            this.NomOrder.Name = "NomOrder";
            this.NomOrder.Size = new System.Drawing.Size(31, 24);
            this.NomOrder.TabIndex = 12;
            this.NomOrder.Text = "№";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(229, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "№ заказа";
            // 
            // butEnd
            // 
            this.butEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butEnd.Enabled = false;
            this.butEnd.Location = new System.Drawing.Point(8, 267);
            this.butEnd.Name = "butEnd";
            this.butEnd.Size = new System.Drawing.Size(286, 23);
            this.butEnd.TabIndex = 20;
            this.butEnd.Text = "Завершить";
            this.butEnd.UseVisualStyleBackColor = true;
            this.butEnd.Visible = false;
            this.butEnd.Click += new System.EventHandler(this.butEnd_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.Enabled = false;
            this.butCancel.Location = new System.Drawing.Point(366, 267);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(250, 23);
            this.butCancel.TabIndex = 22;
            this.butCancel.Text = "Отменить выполнение";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Visible = false;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butCheck
            // 
            this.butCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butCheck.Location = new System.Drawing.Point(12, 267);
            this.butCheck.Name = "butCheck";
            this.butCheck.Size = new System.Drawing.Size(612, 23);
            this.butCheck.TabIndex = 9;
            this.butCheck.Text = "Сформировать чек";
            this.butCheck.UseVisualStyleBackColor = true;
            this.butCheck.Click += new System.EventHandler(this.butCheck_Click);
            // 
            // butPrintAct
            // 
            this.butPrintAct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrintAct.Enabled = false;
            this.butPrintAct.Location = new System.Drawing.Point(9, 267);
            this.butPrintAct.Name = "butPrintAct";
            this.butPrintAct.Size = new System.Drawing.Size(297, 23);
            this.butPrintAct.TabIndex = 9;
            this.butPrintAct.Text = "Печать акта";
            this.butPrintAct.UseVisualStyleBackColor = true;
            this.butPrintAct.Visible = false;
            this.butPrintAct.Click += new System.EventHandler(this.butPrintAct_Click);
            // 
            // butPrintCheck
            // 
            this.butPrintCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butPrintCheck.Enabled = false;
            this.butPrintCheck.Location = new System.Drawing.Point(320, 267);
            this.butPrintCheck.Name = "butPrintCheck";
            this.butPrintCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.butPrintCheck.Size = new System.Drawing.Size(304, 23);
            this.butPrintCheck.TabIndex = 23;
            this.butPrintCheck.Text = "Печать чека";
            this.butPrintCheck.UseVisualStyleBackColor = true;
            this.butPrintCheck.Visible = false;
            this.butPrintCheck.Click += new System.EventHandler(this.butPrintCheck_Click);
            // 
            // InfoOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 302);
            this.ControlBox = false;
            this.Controls.Add(this.butPrintCheck);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butEnd);
            this.Controls.Add(this.butPrintAct);
            this.Controls.Add(this.butCheck);
            this.Controls.Add(this.butPerform);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Adress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Client);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.NomOrder);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoOrder";
            this.ShowIcon = false;
            this.Text = "Данные заказа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoOrder_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butPerform;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label Comment;
        protected System.Windows.Forms.Label Adress;
        protected System.Windows.Forms.Label Client;
        protected System.Windows.Forms.Label NomOrder;
        protected System.Windows.Forms.Label Date;
        private System.Windows.Forms.Button butEnd;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butCheck;
        private System.Windows.Forms.Button butPrintAct;
        private System.Windows.Forms.Button butPrintCheck;
    }
}