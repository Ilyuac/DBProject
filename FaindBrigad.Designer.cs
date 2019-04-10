namespace sql
{
    partial class FaindBrigad
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
            this.Free = new System.Windows.Forms.CheckBox();
            this.Plan = new System.Windows.Forms.CheckBox();
            this.butSearch = new System.Windows.Forms.Button();
            this.dataBrigad = new System.Windows.Forms.DataGridView();
            this.Nomber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Foremen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataBrigad)).BeginInit();
            this.SuspendLayout();
            // 
            // Free
            // 
            this.Free.AutoSize = true;
            this.Free.Location = new System.Drawing.Point(12, 12);
            this.Free.Name = "Free";
            this.Free.Size = new System.Drawing.Size(83, 17);
            this.Free.TabIndex = 0;
            this.Free.Text = "Свободные";
            this.Free.UseVisualStyleBackColor = true;
            // 
            // Plan
            // 
            this.Plan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Plan.AutoSize = true;
            this.Plan.Location = new System.Drawing.Point(92, 12);
            this.Plan.Name = "Plan";
            this.Plan.Size = new System.Drawing.Size(141, 17);
            this.Plan.TabIndex = 1;
            this.Plan.Text = "НЕ выполнившие план";
            this.Plan.UseVisualStyleBackColor = true;
            // 
            // butSearch
            // 
            this.butSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSearch.Location = new System.Drawing.Point(355, 8);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(75, 23);
            this.butSearch.TabIndex = 2;
            this.butSearch.Text = "Поиск";
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // dataBrigad
            // 
            this.dataBrigad.AllowUserToAddRows = false;
            this.dataBrigad.AllowUserToDeleteRows = false;
            this.dataBrigad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataBrigad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBrigad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nomber,
            this.Foremen});
            this.dataBrigad.Location = new System.Drawing.Point(12, 37);
            this.dataBrigad.Name = "dataBrigad";
            this.dataBrigad.ReadOnly = true;
            this.dataBrigad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataBrigad.Size = new System.Drawing.Size(418, 209);
            this.dataBrigad.TabIndex = 4;
            this.dataBrigad.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataBrigad_CellClick);
            // 
            // Nomber
            // 
            this.Nomber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Nomber.HeaderText = "Номер Бригады";
            this.Nomber.Name = "Nomber";
            this.Nomber.ReadOnly = true;
            this.Nomber.Width = 104;
            // 
            // Foremen
            // 
            this.Foremen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Foremen.HeaderText = "Бригадир";
            this.Foremen.Name = "Foremen";
            this.Foremen.ReadOnly = true;
            this.Foremen.Width = 80;
            // 
            // FaindBrigad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 258);
            this.Controls.Add(this.dataBrigad);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.Plan);
            this.Controls.Add(this.Free);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(454, 297);
            this.MinimizeBox = false;
            this.Name = "FaindBrigad";
            this.Text = "Выбор бргады";
            ((System.ComponentModel.ISupportInitialize)(this.dataBrigad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Free;
        private System.Windows.Forms.CheckBox Plan;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.DataGridView dataBrigad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nomber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Foremen;
    }
}