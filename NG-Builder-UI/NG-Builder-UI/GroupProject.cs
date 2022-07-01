using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using NG_Builder_UI;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        String xmlPath = "";
        String rootPath = "";
        String binPath = "";
        GroupProject groupProject { get; set; }

        BuilderConfig config;
        bool emptyProjectPath = false;

        public Form1(String xmlPath, String rootPath, String binPath)
        {
            InitializeComponent();
            this.xmlPath = xmlPath;
            this.rootPath = rootPath;
            this.binPath = binPath;
        }

        private String ShowFileDialog()
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();

            return openFileDialog1.FileName;
        }

        private String ShowFolderDialog()
        {
            string folderName = "";
            FolderBrowserDialog diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderName = diag.SelectedPath;  
            }
            return folderName;
        }

        private String SaveFileDialog()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            sfd.Title = "Save an XML File";
            sfd.ShowDialog();
            string fileName = "";

            if(sfd.FileName != "")
            {
                fileName = sfd.FileName;
            }
            return fileName;
        }
        private void btnXML_Click(object sender, EventArgs e)
        {
            var file = ShowFileDialog();
            if (file == "")
                return;
            txtXML.Text = file;

            LoadDataToUi();
        }

        private void LoadDataToUi()
        {
            config = ReadConfig<BuilderConfig>(txtXML.Text);

            if (config.ProjectPath == "")
            {
                config.ProjectPath = Directory.GetCurrentDirectory() + @"\";
                emptyProjectPath = true;
            }
            GroupProjectLoad(config);

            btnAdd.Enabled = true;
            btnSave.Enabled = true;
            btnSaveAs.Enabled = true;
            btnOutput.Enabled = true;
            btnRef.Enabled = true;
            btnProject.Enabled = true;
            btnBuild.Enabled = true;

            if (xmlPath != "")
            {
                txtOutputPath.Enabled = false;
                txtProjectPath.Enabled = false;
                txtRefPath.Enabled = false;
                btnBuild.Enabled = false;
                btnOutput.Enabled = false;
                btnProject.Enabled = false;
                btnRef.Enabled = false;
            }
        }

        public T ReadConfig<T>(string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            var fileConfig = new StreamReader(path);
            T a = (T)serializer.Deserialize(fileConfig);
            fileConfig.Close();
            return a;
        }

        public void WriteConfig<T>(T config, string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            var fileConfig = new StreamWriter(path);
            serializer.Serialize(fileConfig, config);
            fileConfig.Close();
            Console.WriteLine($"{path} Created ");
        }

        private void GroupProjectLoad(BuilderConfig config)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = config.GroupProjectList;
            txtOutputPath.Text = config.OutputPath;
            txtRefPath.Text = config.RefPath;

            if (binPath != "")
            {
                txtOutputPath.Text = binPath;
                txtRefPath.Text = binPath;
            }
            
            if (rootPath != "")
            {
                txtProjectPath.Text = rootPath;
            }
      
           


            checkClean.Checked = config.CleanBeforeBuild;
            dataGridView1.AutoGenerateColumns = false;

            if (config.ProjectPath == "")
            {
                config.ProjectPath = Directory.GetCurrentDirectory();
            }
            txtProjectPath.Text = config.ProjectPath;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GroupProjectDetail groupProjectDetail = new GroupProjectDetail(config);
            groupProjectDetail.ShowDialog();
            if (groupProjectDetail.DialogResult == DialogResult.OK)
            if (config != null)
            {
                config.GroupProjectList.Add(groupProjectDetail.groupProject);
                GroupProjectLoad(config);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (emptyProjectPath)
            {
                config.ProjectPath = "";
            }
            
            WriteConfig(config, txtXML.Text);
            MessageBox.Show("Save Success", "Info");
            config = ReadConfig<BuilderConfig>(txtXML.Text);
            GroupProjectLoad(config);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.ColumnIndex == 0))
            {
                GroupProjectDetail groupProjectDetail = new GroupProjectDetail(config)
                {
                    groupProject = config.GroupProjectList[e.RowIndex]
                };
                groupProjectDetail.ShowDialog();
            }
            else if ((e.RowIndex > -1) && (e.ColumnIndex == 1))
            {
                groupProject = config.GroupProjectList[e.RowIndex];
                config.GroupProjectList.Remove(groupProject);
                GroupProjectLoad(config);
            }
            else if ((e.RowIndex > -1) && (e.ColumnIndex == 2))
            {
                if(((e.RowIndex) - 1) != -1)
                {
                    groupProject = config.GroupProjectList[e.RowIndex];
                    config.GroupProjectList.Remove(groupProject);
                    config.GroupProjectList.Insert((e.RowIndex) - 1, groupProject);
                    GroupProjectLoad(config);
                }
            }
            else if ((e.RowIndex > -1) && (e.ColumnIndex == 3))
            {
                if (((e.RowIndex) + 1) < config.GroupProjectList.Count)
                {
                    groupProject = config.GroupProjectList[e.RowIndex];
                    config.GroupProjectList.Remove(groupProject);
                    config.GroupProjectList.Insert((e.RowIndex) + 1, groupProject);
                    GroupProjectLoad(config);
                }
            }
            dataGridView1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (xmlPath != "")
            {
                txtXML.Text = xmlPath;
        
                LoadDataToUi();
            }
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            var folder = ShowFolderDialog();
            if (folder == "")
                return;
            txtProjectPath.Text = folder;
            config.ProjectPath = folder;
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            var folder = ShowFolderDialog();
            if (folder == "")
                return;
            txtRefPath.Text = folder;
            config.RefPath = folder;
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            var folder = ShowFolderDialog();
            if (folder == "")
                return;
            txtOutputPath.Text = folder;
            config.OutputPath = folder;
        }

        private void checkClean_CheckedChanged(object sender, EventArgs e)
        {
            config.CleanBeforeBuild = checkClean.Checked;
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            var name = SaveFileDialog();
            if (name == "")
                return;
            config.ProjectPath = txtProjectPath.Text;
            WriteConfig(config, name);
            MessageBox.Show("Save Success", "Info");

            txtXML.Text = name;

            config = ReadConfig<BuilderConfig>(txtXML.Text);
            GroupProjectLoad(config);
        }

        private void BtnBuild_Click(object sender, EventArgs e)
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = "dotnet";
                process.StartInfo.Arguments = $@"""D:\nge-automation\builder\portable\NG-Builder.dll"" /d={txtXML.Text}";
                process.StartInfo.WorkingDirectory = $"{config.ProjectPath}";
                process.Start();
                process.WaitForExit();
                if (process.ExitCode != 0)
                {
                    throw new Exception("build failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }
    }
}
