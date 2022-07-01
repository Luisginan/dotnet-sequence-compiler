using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NG_Builder
{
    public class BuilderConfig
    {
        private static string OUTPUT_PATH_PARAM = @"c:\bosnet\bin";
        private static string REF_PATH_PARAM = @"c:\bosnet\bin";
        private static string MAIN_PROJECT_PATH_PARAM = @"C:\NGES";

        public static BuilderConfig GetConfig(string mainPath,string refPath ,string outputPath,bool isGenerateAll)
        {
            var config = new BuilderConfig();
            config.CleanBeforeBuild = false;
            config.ProjectPath = (mainPath != "")? mainPath : MAIN_PROJECT_PATH_PARAM;
            config.RefPath = (refPath != "")? refPath : REF_PATH_PARAM;
            config.OutputPath = (outputPath != "")? outputPath : OUTPUT_PATH_PARAM;
            if(isGenerateAll)
                config.GroupProjectList = ProjectModule.GetProjectFile(config.ProjectPath);
            else
                config.GroupProjectList = GetDefaultModule();


            return config;
        }

        private static List<GroupProject> GetDefaultModule()
        {
            List<GroupProject> defaultModuleList = new List<GroupProject>();
            List<string> defaultNameList = new List<string> { DefaultProject.MART_NAME, DefaultProject.IO_NAME, DefaultProject.NG365_NAME, DefaultProject.NGERETAIL_NAME };
            foreach (var groupName in defaultNameList)
            {
                defaultModuleList.Add(ProjectModule.SetDefaultGroupModule(groupName));
            }
            return defaultModuleList;
        }

       
      
        public bool CleanBeforeBuild { get; set; } = false;
        public String ProjectPath { get; set; } = "";

        public string RefPath { get; set; } = "";

        public string OutputPath { get; set; } = "";

        public List<GroupProject> GroupProjectList { get; set; } = new List<GroupProject>();

      

    }

    public class ProjectItem
    {
        public string ProjectPath { get; set; } = "";
        public bool Active { get; set; } = true; 
    }

    public class GroupProject
    {
        public string Name { get; set; } = "";
        public bool Active { get; set; } = true;

        public List<ProjectItem> ProjectList;
    }

    public class DefaultProjectType
    {
        public string INTERFACE { get;set;} = "";
        public string MANAGER { get; set; } = "";
        public string CONTROLLER { get; set; } = "";
    }

    public class DefaultProject
    {
        public const string MART_NAME = "MART";
        public const string IO_NAME = "IO";
        public const string NG365_NAME = "NG365";
        public const string NGERETAIL_NAME = "NGERETAIL";

        public class MART
        {
            public const string INTERFACE = @"\MART\API.NG.MART\API.NG.MART.Interfaces\API.NG.MART.Interfaces.csproj";
            public const string MANAGER = @"\MART\API.NG.MART\API.NG.MART.Managers\API.NG.MART.Managers.csproj";
            public const string CONTROLLER = @"\MART\API.NG.MART\API.NG.MART.Controller\API.NG.MART.Controller.csproj";
        }
        public class IO
        {
            public const string INTERFACE = @"\IO\GIN.IO.Interface\GIN.IO.Interface\GIN.IO.Interface.csproj";
            public const string MANAGER = @"\IO\GIN.IO.Manager\GIN.IO.Manager\GIN.IO.Manager.csproj";
            public const string CONTROLLER = @"\IO\GIN.IO.controller\GIN.IO.controller\API.GIN.IO.controller.csproj";
        }
        public class NG365
        {
            public const string INTERFACE = @"\NG365\GIN.IO.NG365.Interface\GIN.IO.NG365.Interface\GIN.IO.NG365.Interface.csproj";
            public const string MANAGER = @"\NG365\GIN.IO.NG365.Manager\GIN.IO.NG365.Manager\GIN.IO.NG365.Manager.csproj";
            public const string CONTROLLER = @"\NG365\API.GIN.IO.NG365.Controller\API.GIN.IO.NG365.Controller\API.GIN.IO.NG365.Controller.csproj";
        }
        public class NGERETAIL
        {
            public const string INTERFACE = @"\NGERETAIL\API.GIN.NGERETAIL\API.GIN.NGERETAIL.Interfaces\API.GIN.NGERETAIL.Interfaces.csproj";
            public const string MANAGER = @"\NGERETAIL\API.GIN.NGERETAIL\API.NG.NGERETAIL.Managers\API.GIN.NGERETAIL.Managers.csproj";
            public const string CONTROLLER = @"\NGERETAIL\API.GIN.NGERETAIL\API.GIN.NGERETAIL.Controller\API.GIN.NGERETAIL.Controller.csproj";
        }
    }

    public  class ProjectModule
    {
        internal static List<GroupProject> GetProjectFile(string basePath)
        {
            List<GroupProject> defaultModuleList = new List<GroupProject>();
            string[] ModuleDirs = Directory.GetDirectories(basePath);
            foreach (var groupPath in ModuleDirs)
            {
                string[] filesPath = Directory.GetFiles(groupPath, "*.csproj", SearchOption.AllDirectories);
                if(filesPath.Length > 0)
                    defaultModuleList.Add(SetAllGroupModule(basePath, groupPath, filesPath));
            }                    
       
            return defaultModuleList;

        }

        internal static GroupProject SetAllGroupModule(string basePath, string groupPath, string[] filesPath)
        {
            string moduleName = groupPath.Remove(0, basePath.Length + 1);         

            GroupProject projectGroup = new GroupProject();
            projectGroup.Name = moduleName;
            projectGroup.Active = true;
            projectGroup.ProjectList = SetAllProjectPath(basePath, filesPath);
            return projectGroup;
        }

        private static List<ProjectItem> SetAllProjectPath(string basePath, string[] files)
        {
            List<ProjectItem> projectList = new List<ProjectItem>();
            foreach (var item in files)
            {                           
                ProjectItem interfaceProject = new ProjectItem();
                interfaceProject.Active = true;
                interfaceProject.ProjectPath = item.Remove(0, basePath.Length);
                projectList.Add(interfaceProject);
            }
            return projectList;
        }

        internal static GroupProject SetDefaultGroupModule(string groupName)
        {
            GroupProject projectGroup = new GroupProject();
            projectGroup.Name = groupName;
            projectGroup.Active = true;
            projectGroup.ProjectList = SetDefaultProjectModule(groupName);
            return projectGroup;
        }

        internal static List<ProjectItem> SetDefaultProjectModule(string groupName)
        {
            List<ProjectItem> projectList = new List<ProjectItem>();
            ProjectItem interfaceProject = new ProjectItem();
            interfaceProject.Active = true;
            interfaceProject.ProjectPath = GetDefaultPath(groupName).INTERFACE;
            projectList.Add(interfaceProject);

            ProjectItem managerProject = new ProjectItem();
            managerProject.Active = true;
            managerProject.ProjectPath = GetDefaultPath(groupName).MANAGER;
            projectList.Add(managerProject);

            ProjectItem controllerProject = new ProjectItem();
            controllerProject.Active = true;
            controllerProject.ProjectPath = GetDefaultPath(groupName).CONTROLLER;
            projectList.Add(controllerProject);

            return projectList;
        }

        internal static DefaultProjectType GetDefaultPath(string projectName)
        {
            switch (projectName)
            {
                case DefaultProject.MART_NAME:
                    DefaultProjectType projectType = new DefaultProjectType();
                    projectType.INTERFACE = DefaultProject.MART.INTERFACE;
                    projectType.MANAGER = DefaultProject.MART.MANAGER;
                    projectType.CONTROLLER = DefaultProject.MART.CONTROLLER;
                    return projectType;

                case DefaultProject.IO_NAME:
                    DefaultProjectType projectType1 = new DefaultProjectType();
                    projectType1.INTERFACE = DefaultProject.IO.INTERFACE;
                    projectType1.MANAGER = DefaultProject.IO.MANAGER;
                    projectType1.CONTROLLER = DefaultProject.IO.CONTROLLER;
                    return projectType1;

                case DefaultProject.NG365_NAME:
                    DefaultProjectType projectType2 = new DefaultProjectType();
                    projectType2.INTERFACE = DefaultProject.NG365.INTERFACE;
                    projectType2.MANAGER = DefaultProject.NG365.MANAGER;
                    projectType2.CONTROLLER = DefaultProject.NG365.CONTROLLER;
                    return projectType2;

                case DefaultProject.NGERETAIL_NAME:
                    DefaultProjectType projectType3 = new DefaultProjectType();
                    projectType3.INTERFACE = DefaultProject.NGERETAIL.INTERFACE;
                    projectType3.MANAGER = DefaultProject.NGERETAIL.MANAGER;
                    projectType3.CONTROLLER = DefaultProject.NGERETAIL.CONTROLLER;
                    return projectType3;

                default:
                    return new DefaultProjectType();
            }
        }

    }


}
