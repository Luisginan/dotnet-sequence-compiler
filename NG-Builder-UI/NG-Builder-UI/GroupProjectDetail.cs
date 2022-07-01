using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NG_Builder_UI
{
    public partial class GroupProjectDetail : Form
    {
        public GroupProject groupProject { get; set; }
        List<ProjectItem> resultList;

        ProjectItem projectItem { get; set; }

        public readonly BuilderConfig config;

        public GroupProjectDetail(BuilderConfig config)
        {
            this.config = config;
            InitializeComponent();
        }

        private void GroupProjectDetail_Load(object sender, EventArgs e)
        {
            if (groupProject != null)
            {
                GroupProjectDetailLoad();
            }
            else
            {
                groupProject = new GroupProject();
                groupProject.ProjectList = new List<ProjectItem>();
            }
        }

        private void GroupProjectDetailLoad()
        {
            resultList = groupProject.ProjectList.Where(x => x.ProjectName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            txtGroupProject.Text = groupProject.Name;
            checkActive.Checked = groupProject.Active ? true : false;

            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = resultList;
            dataGridView1.Refresh();
           
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower() == "Bedit".ToLower())
            {
                ProjectItemEdit projectItemEdit = new ProjectItemEdit(config)
                {
                    projectItem = resultList[e.RowIndex]
                };

                projectItemEdit.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower() == "BDelete".ToLower())
            {
                projectItem = resultList[e.RowIndex];
                groupProject.ProjectList.Remove(projectItem);
                GroupProjectDetailLoad();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower() == "Bup".ToLower())
            {
                if (((e.RowIndex) - 1) != -1)
                {
                    projectItem = resultList[e.RowIndex];
                    groupProject.ProjectList.Remove(projectItem);
                    groupProject.ProjectList.Insert((e.RowIndex) - 1, projectItem);
                    GroupProjectDetailLoad();
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower() == "Bdown".ToLower())
            {
                if (((e.RowIndex) + 1) <= config.GroupProjectList.Count)
                {
                    projectItem = resultList[e.RowIndex];
                    groupProject.ProjectList.Remove(projectItem);
                    groupProject.ProjectList.Insert((e.RowIndex) + 1, projectItem);
                    GroupProjectDetailLoad();
                }
            }

            dataGridView1.Refresh();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGroupProject.Text))
            {
                MessageBox.Show("Group Project Is Empty", "Warning");
            }
            else
            {
                groupProject.Name = txtGroupProject.Text;
                groupProject.Active = checkActive.Checked ? true : false;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProjectItemEdit projectItemEdit = new ProjectItemEdit(config);
            projectItemEdit.ShowDialog();
            if (projectItemEdit.DialogResult == DialogResult.OK)
            {
                groupProject.ProjectList.Add(projectItemEdit.projectItem);
                groupProject.Name = txtGroupProject.Text;
                groupProject.Active = checkActive.Checked ? true : false;

                GroupProjectDetailLoad();
            }    
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GroupProjectDetailLoad();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            GroupProjectDetailLoad();
        }
    }
}
