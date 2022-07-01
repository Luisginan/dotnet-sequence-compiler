using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NG_Builder_UI
{
    public partial class ProjectItemEdit : Form
    {
        public ProjectItem projectItem { get; set; }
        public readonly BuilderConfig config;

        public ProjectItemEdit(BuilderConfig config)
        {
            this.config = config;
            InitializeComponent();
        }

        private void ProjectItemEdit_Load(object sender, EventArgs e)
        {

            if (projectItem != null)
            {
                ProjectItemLoad(projectItem);
            }
            else
            {
                projectItem = new ProjectItem();
            }
        }

        private void ProjectItemLoad(ProjectItem projectItem)
        {
            txtProjectPath.Text = projectItem.ProjectPath;
            checkActive.Checked = projectItem.Active ? true : false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProjectPath.Text))
            {
                MessageBox.Show("Path Is Empty", "Warning");
            }
            else
            {
                var fileName = new FileInfo(txtProjectPath.Text).Name;
                foreach (var projectDetail in config.GroupProjectList)
                {
                    var projectItem = new ProjectItem();
                    projectItem = projectDetail.ProjectList.Where(x => x.ProjectName.Equals(fileName)).FirstOrDefault();

                    if (projectItem.ProjectName != "")
                    {
                        MessageBox.Show($@"Duplicate Project Item {projectItem.ProjectName} in Group {projectDetail.Name}");
                        return;
                    }
                }

                projectItem.ProjectPath = txtProjectPath.Text;
                projectItem.Active = checkActive.Checked ? true : false;
                DialogResult = DialogResult.OK;
                Close();
            }
            
        }

        private String ShowFileDialog()
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "csproj files (*.csproj)|*.csproj|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();

            return openFileDialog1.FileName;
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            var file = ShowFileDialog();
            if (file == "")
                return;
            txtProjectPath.Text = file.Replace(config.ProjectPath,"");
        }
    }
}
