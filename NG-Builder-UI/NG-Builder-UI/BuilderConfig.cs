using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NG_Builder_UI
{
    public class BuilderConfig
    {
        public bool CleanBeforeBuild { get; set; } = false;
        public String ProjectPath { get; set; } = "";
        
        public string RefPath { get; set; } = "";

        public string OutputPath { get; set; } = "";

        public List<GroupProject> GroupProjectList { get; set; } = new List<GroupProject>();
    }

    public class GroupProject
    {
        public string Name { get; set; } = "";
        public bool Active { get; set; } = true;

        public List<ProjectItem> ProjectList;
    }

    public class ProjectItem
    {
        public string ProjectPath { get; set; } = "";
        public String ProjectName => new FileInfo(ProjectPath).Name;

        public bool Active { get; set; } = true;
    }
}
