namespace NG_Builder_UI
{
    partial class GroupProjectDetail
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtGroupProject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.checkActive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.CProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.BDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.BUp = new System.Windows.Forms.DataGridViewImageColumn();
            this.BDown = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CProjectName,
            this.CActive,
            this.BEdit,
            this.BDelete,
            this.BUp,
            this.BDown});
            this.dataGridView1.Location = new System.Drawing.Point(12, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(663, 366);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtGroupProject
            // 
            this.txtGroupProject.Location = new System.Drawing.Point(93, 12);
            this.txtGroupProject.Name = "txtGroupProject";
            this.txtGroupProject.Size = new System.Drawing.Size(647, 20);
            this.txtGroupProject.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Active";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Group Project";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 467);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(160, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // checkActive
            // 
            this.checkActive.AutoSize = true;
            this.checkActive.Checked = true;
            this.checkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkActive.Location = new System.Drawing.Point(93, 38);
            this.checkActive.Name = "checkActive";
            this.checkActive.Size = new System.Drawing.Size(48, 17);
            this.checkActive.TabIndex = 12;
            this.checkActive.Text = "True";
            this.checkActive.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(681, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 22);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // CProjectName
            // 
            this.CProjectName.DataPropertyName = "ProjectName";
            this.CProjectName.HeaderText = "Project";
            this.CProjectName.Name = "CProjectName";
            this.CProjectName.ReadOnly = true;
            this.CProjectName.Width = 350;
            // 
            // CActive
            // 
            this.CActive.DataPropertyName = "Active";
            this.CActive.HeaderText = "Active";
            this.CActive.Name = "CActive";
            this.CActive.ReadOnly = true;
            this.CActive.Width = 80;
            // 
            // BEdit
            // 
            this.BEdit.HeaderText = "";
            this.BEdit.Image = global::NG_Builder_UI.Properties.Resources.edit;
            this.BEdit.Name = "BEdit";
            this.BEdit.ReadOnly = true;
            this.BEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BEdit.Width = 50;
            // 
            // BDelete
            // 
            this.BDelete.HeaderText = "";
            this.BDelete.Image = global::NG_Builder_UI.Properties.Resources.delete;
            this.BDelete.Name = "BDelete";
            this.BDelete.ReadOnly = true;
            this.BDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BDelete.Width = 50;
            // 
            // BUp
            // 
            this.BUp.HeaderText = "";
            this.BUp.Image = global::NG_Builder_UI.Properties.Resources.Up;
            this.BUp.Name = "BUp";
            this.BUp.ReadOnly = true;
            this.BUp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BUp.Width = 50;
            // 
            // BDown
            // 
            this.BDown.HeaderText = "";
            this.BDown.Image = global::NG_Builder_UI.Properties.Resources.Down;
            this.BDown.Name = "BDown";
            this.BDown.ReadOnly = true;
            this.BDown.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BDown.Width = 50;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(93, 61);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(526, 20);
            this.txtSearch.TabIndex = 14;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(681, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 22);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Search";
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(619, 61);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 20);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "X";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // GroupProjectDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 498);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.checkActive);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtGroupProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GroupProjectDetail";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group Project Detail";
            this.Load += new System.EventHandler(this.GroupProjectDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtGroupProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox checkActive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CActive;
        private System.Windows.Forms.DataGridViewImageColumn BEdit;
        private System.Windows.Forms.DataGridViewImageColumn BDelete;
        private System.Windows.Forms.DataGridViewImageColumn BUp;
        private System.Windows.Forms.DataGridViewImageColumn BDown;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
    }
}