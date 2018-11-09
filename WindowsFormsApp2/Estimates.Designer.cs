namespace WindowsFormsApp2
{
    partial class Estimates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Estimates));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Discipline_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Differential = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Course_title_UA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estimat_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estimat_UA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estimat_CHAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estimat_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Del = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Discipline_ID,
            this.Differential,
            this.Course_title_UA,
            this.Estimat_NUM,
            this.Estimat_UA,
            this.Estimat_CHAR,
            this.Estimat_ID,
            this.Del});
            this.dataGridView1.Location = new System.Drawing.Point(13, 11);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(563, 385);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_RowValidating);
            // 
            // Discipline_ID
            // 
            this.Discipline_ID.HeaderText = "Graduat_ID";
            this.Discipline_ID.Name = "Discipline_ID";
            this.Discipline_ID.Visible = false;
            // 
            // Differential
            // 
            this.Differential.HeaderText = "Differential";
            this.Differential.Name = "Differential";
            this.Differential.Visible = false;
            // 
            // Course_title_UA
            // 
            this.Course_title_UA.HeaderText = "Предмет";
            this.Course_title_UA.Name = "Course_title_UA";
            this.Course_title_UA.ReadOnly = true;
            this.Course_title_UA.Width = 77;
            // 
            // Estimat_NUM
            // 
            this.Estimat_NUM.HeaderText = "Бал";
            this.Estimat_NUM.Name = "Estimat_NUM";
            this.Estimat_NUM.Width = 51;
            // 
            // Estimat_UA
            // 
            this.Estimat_UA.HeaderText = "Оцінка";
            this.Estimat_UA.Name = "Estimat_UA";
            this.Estimat_UA.ReadOnly = true;
            this.Estimat_UA.Width = 66;
            // 
            // Estimat_CHAR
            // 
            this.Estimat_CHAR.HeaderText = "Рейтинг";
            this.Estimat_CHAR.Name = "Estimat_CHAR";
            this.Estimat_CHAR.ReadOnly = true;
            this.Estimat_CHAR.Width = 73;
            // 
            // Estimat_ID
            // 
            this.Estimat_ID.HeaderText = "Estimat_ID";
            this.Estimat_ID.Name = "Estimat_ID";
            this.Estimat_ID.Visible = false;
            // 
            // Del
            // 
            this.Del.HeaderText = "Редагування";
            this.Del.Name = "Del";
            this.Del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Del.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Del.Text = "Видалити";
            this.Del.UseColumnTextForButtonValue = true;
            this.Del.Width = 97;
            // 
            // Estimates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 450);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Estimates";
            this.Text = "Оцінки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Estimates_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Estimates_FormClosed);
            this.Load += new System.EventHandler(this.Estimates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discipline_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Differential;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course_title_UA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estimat_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estimat_UA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estimat_CHAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estimat_ID;
        private System.Windows.Forms.DataGridViewButtonColumn Del;
    }
}