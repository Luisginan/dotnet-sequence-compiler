namespace WindowsFormsApp1
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtXML = new System.Windows.Forms.TextBox();
            this.btnXML = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.bDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.BUp = new System.Windows.Forms.DataGridViewImageColumn();
            this.BDown = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtProjectPath = new System.Windows.Forms.TextBox();
            this.txtRefPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkClean = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnProject = new System.Windows.Forms.Button();
            this.btnRef = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBuild = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Root";
            // 
            // txtXML
            // 
            this.txtXML.Location = new System.Drawing.Point(110, 7);
            this.txtXML.Name = "txtXML";
            this.txtXML.Size = new System.Drawing.Size(421, 20);
            this.txtXML.TabIndex = 1;
            // 
            // btnXML
            // 
            this.btnXML.Location = new System.Drawing.Point(537, 6);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(28, 20);
            this.btnXML.TabIndex = 2;
            this.btnXML.Text = "...";
            this.btnXML.UseVisualStyleBackColor = true;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CName,
            this.CActive,
            this.bEdit,
            this.bDelete,
            this.BUp,
            this.BDown});
            this.dataGridView1.Location = new System.Drawing.Point(110, 134);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(421, 275);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // CName
            // 
            this.CName.DataPropertyName = "Name";
            this.CName.HeaderText = "Name";
            this.CName.Name = "CName";
            this.CName.ReadOnly = true;
            // 
            // CActive
            // 
            this.CActive.DataPropertyName = "Active";
            this.CActive.HeaderText = "Active";
            this.CActive.Name = "CActive";
            this.CActive.ReadOnly = true;
            // 
            // bEdit
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "Edit";
            this.bEdit.DefaultCellStyle = dataGridViewCellStyle1;
            this.bEdit.HeaderText = "";
            this.bEdit.Image = global::NG_Builder_UI.Properties.Resources.edit;
            this.bEdit.Name = "bEdit";
            this.bEdit.ReadOnly = true;
            this.bEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.bEdit.Width = 50;
            // 
            // bDelete
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "Delete";
            this.bDelete.DefaultCellStyle = dataGridViewCellStyle2;
            this.bDelete.HeaderText = "";
            this.bDelete.Image = global::NG_Builder_UI.Properties.Resources.delete;
            this.bDelete.Name = "bDelete";
            this.bDelete.ReadOnly = true;
            this.bDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.bDelete.Width = 50;
            // 
            // BUp
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "Up";
            this.BUp.DefaultCellStyle = dataGridViewCellStyle3;
            this.BUp.HeaderText = "";
            this.BUp.Image = global::NG_Builder_UI.Properties.Resources.Up;
            this.BUp.Name = "BUp";
            this.BUp.ReadOnly = true;
            this.BUp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BUp.Width = 50;
            // 
            // BDown
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = "Down";
            this.BDown.DefaultCellStyle = dataGridViewCellStyle4;
            this.BDown.HeaderText = "";
            this.BDown.Image = global::NG_Builder_UI.Properties.Resources.Down;
            this.BDown.Name = "BDown";
            this.BDown.ReadOnly = true;
            this.BDown.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BDown.Width = 50;
            // 
            // txtProjectPath
            // 
            this.txtProjectPath.Location = new System.Drawing.Point(110, 33);
            this.txtProjectPath.Name = "txtProjectPath";
            this.txtProjectPath.Size = new System.Drawing.Size(421, 20);
            this.txtProjectPath.TabIndex = 9;
            // 
            // txtRefPath
            // 
            this.txtRefPath.Location = new System.Drawing.Point(110, 59);
            this.txtRefPath.Name = "txtRefPath";
            this.txtRefPath.Size = new System.Drawing.Size(421, 20);
            this.txtRefPath.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ref Path";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(110, 85);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(421, 20);
            this.txtOutputPath.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Output Path";
            // 
            // checkClean
            // 
            this.checkClean.AutoSize = true;
            this.checkClean.Location = new System.Drawing.Point(110, 111);
            this.checkClean.Name = "checkClean";
            this.checkClean.Size = new System.Drawing.Size(48, 17);
            this.checkClean.TabIndex = 15;
            this.checkClean.Text = "True";
            this.checkClean.UseVisualStyleBackColor = true;
            this.checkClean.CheckedChanged += new System.EventHandler(this.checkClean_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Clean ";
            // 
            // btnProject
            // 
            this.btnProject.Enabled = false;
            this.btnProject.Location = new System.Drawing.Point(537, 32);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(28, 20);
            this.btnProject.TabIndex = 16;
            this.btnProject.Text = "...";
            this.btnProject.UseVisualStyleBackColor = true;
            this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
            // 
            // btnRef
            // 
            this.btnRef.Enabled = false;
            this.btnRef.Location = new System.Drawing.Point(537, 58);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(28, 20);
            this.btnRef.TabIndex = 17;
            this.btnRef.Text = "...";
            this.btnRef.UseVisualStyleBackColor = true;
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Enabled = false;
            this.btnOutput.Location = new System.Drawing.Point(537, 85);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(28, 20);
            this.btnOutput.TabIndex = 18;
            this.btnOutput.Text = "...";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Enabled = false;
            this.btnSaveAs.Location = new System.Drawing.Point(185, 415);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAs.TabIndex = 19;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::NG_Builder_UI.Properties.Resources.edit;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 70;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::NG_Builder_UI.Properties.Resources.delete;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.Width = 70;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(537, 134);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 22);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(104, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBuild
            // 
            this.btnBuild.Enabled = false;
            this.btnBuild.Location = new System.Drawing.Point(266, 415);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(128, 23);
            this.btnBuild.TabIndex = 9;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.BtnBuild_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 450);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.btnRef);
            this.Controls.Add(this.btnProject);
            this.Controls.Add(this.checkClean);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRefPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProjectPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnXML);
            this.Controls.Add(this.txtXML);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NG-BUILD Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXML;
        private System.Windows.Forms.Button btnXML;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtProjectPath;
        private System.Windows.Forms.TextBox txtRefPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkClean;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnProject;
        private System.Windows.Forms.Button btnRef;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.DataGridViewTextBoxColumn CName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CActive;
        private System.Windows.Forms.DataGridViewImageColumn bEdit;
        private System.Windows.Forms.DataGridViewImageColumn bDelete;
        private System.Windows.Forms.DataGridViewImageColumn BUp;
        private System.Windows.Forms.DataGridViewImageColumn BDown;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuild;
    }
}

