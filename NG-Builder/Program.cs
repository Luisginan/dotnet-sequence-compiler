using NGE_Tool_Lib;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace NG_Builder
{
    class Program
    {
        private static readonly StyleUtil Style = new StyleUtil();
        private static readonly NgFileMaker NgFileMaker = new NgFileMaker();
        private static readonly ServicesUtil ServiceUtil = new ServicesUtil();
        private static readonly InternetUtil InternetUtil = new InternetUtil();
        private static readonly GinxUtil GinxUtil = new GinxUtil();
        private static string xmlFilename = "Project_list.xml";
        private static string errorLogFile = "build_Error_log.txt";
        private static string successLogFile = "build_Success_log.txt";
        private static string logFolder = "\\BuildLog";
        private static string OUTPUT_PATH_PARAM = "";
        private static string REF_PATH_PARAM = "";
        private static string MAIN_PROJECT_PATH_PARAM = "";
        private static bool allSubFolder = false;


        static async Task Main(string[] args)
        {
            bool paramValid = true;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "/h")
                {
                    paramValid = false;
                    ShowParameterHelp();
                    break;
                }
                else if (args[i] == "/all")
                    allSubFolder = true;
                else
                {
                    if (args[i].Contains("="))
                    {
                        string param = args[i].Split('=')[0];
                        string paramValue = args[i].Split('=')[1];

                        if (paramValue == null || paramValue == string.Empty)
                        {
                            StopProcess();
                            break;
                        }

                        if (param == "/p")
                            MAIN_PROJECT_PATH_PARAM = paramValue;
                        else if (param == "/r")
                            REF_PATH_PARAM = paramValue;
                        else if (param == "/o")
                            OUTPUT_PATH_PARAM = paramValue;
                        else if (param == "/d")
                            xmlFilename = paramValue;
                        else
                        {
                            StopProcess();
                            
                            break;
                        }

                    }
                    else
                    {
                        StopProcess();
                        break;
                    }


                }
            }

            if (paramValid)
            {
                ProcessSetting();
            }

        }

        private static void StopProcess()
        {
            throw new Exception(" Wrong parameter, Please use NG-Builder /h , for help");
        }

        private static void ProcessSetting()
        {
            Style.WriteWelcome(Assembly.GetExecutingAssembly());
            BuilderConfig config;
            if (NgFileMaker.Exists(new FileInfo(xmlFilename)))
            {
                config = NgFileMaker.ReadConfig<BuilderConfig>(xmlFilename);
                if (MAIN_PROJECT_PATH_PARAM != "")
                {
                    config.ProjectPath = MAIN_PROJECT_PATH_PARAM + @"\";
                }

                if (REF_PATH_PARAM != "")
                {
                    config.RefPath = REF_PATH_PARAM;
                }

                if (OUTPUT_PATH_PARAM != "")
                {
                    config.OutputPath = OUTPUT_PATH_PARAM;
                }

                ProjectBuildProcess(config);
            }
            else
            {
                config = BuilderConfig.GetConfig(MAIN_PROJECT_PATH_PARAM, REF_PATH_PARAM, OUTPUT_PATH_PARAM, allSubFolder);
                NgFileMaker.WriteConfig(config, xmlFilename);
                return;
            }
            WriteTitle("FINISH");
        }

        private static void ShowParameterHelp()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Please use : ");
            Console.WriteLine(@" /p:{mainProjectPath} , default : C:\NGES");
            Console.WriteLine(@" /r:{referencePath} , default : c:\bosnet\bin");
            Console.WriteLine(@" /o:{outputPath} , default c:\bosnet\bin");
            Console.WriteLine(@" /d:{xml location path}, default xml file location");
            Console.WriteLine(" no param will use default value.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(3000);
        }

        private static void ProjectBuildProcess(BuilderConfig config)
        {
            Style.WriteTitle("READING CONFIG");

            if (config.ProjectPath == null || config.ProjectPath == "")
            {
                config.ProjectPath = Directory.GetCurrentDirectory() + @"\";
            }

            Console.WriteLine("Project Location   : " + config.ProjectPath);
            Console.WriteLine("Build to           : " + config.OutputPath);
            Console.WriteLine("Clean before build : " + config.CleanBeforeBuild);
            Console.WriteLine("Ref                : " + config.RefPath);
            //DeleteLogSource(config.OutputPath + logFolder + "\\" + errorLogFile);
            foreach (var projectGroup in config.GroupProjectList)
            {
                WriteProcess(projectGroup.Name + " : " + projectGroup.Active);
                if (projectGroup.Active)
                {
                    foreach (var project in projectGroup.ProjectList)
                    {
                        if (project.Active)
                        {
                            string fullProjectPath = config.ProjectPath + project.ProjectPath;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Build : " + new DirectoryInfo(project.ProjectPath).Name + " ....");
                            RunMsBuild(config.OutputPath, config.RefPath, fullProjectPath, config.CleanBeforeBuild);
                            Console.WriteLine(" OK");
                        }
                    }
                }
            }
        }

        private static void WriteTitle(String title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==============================================");
            Console.WriteLine(" " + title.ToUpper());
            Console.WriteLine("==============================================");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(3000);
        }

        private static void WriteProcess(String title)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("==============================================");
            Console.WriteLine(" " + "BUILD " + title.ToUpper());
            Console.WriteLine("==============================================");
            Console.ForegroundColor = ConsoleColor.White;
        }


        private static void SetMsBuildExePath()
        {
            try
            {
                var process = Process.Start(new ProcessStartInfo("dotnet", "--list-sdks") { UseShellExecute = false, RedirectStandardOutput = true });
                process.WaitForExit(1000);

                var output = process.StandardOutput.ReadToEnd();
                var sdkPaths = Regex.Matches(output, "([0-9]+.[0-9]+.[0-9]+) \\[(.*)\\]").OfType<Match>()
                    .Select(m => Path.Combine(m.Groups[2].Value, m.Groups[1].Value, "MSBuild.dll"));

                var sdkPath = sdkPaths.Last(); // sdkPaths.LastOrDefault() ?? Path.Combine(ProjectExtensions.GetToolsPath(), "msbuild.exe");
                Environment.SetEnvironmentVariable("MSBUILD_EXE_PATH", sdkPath);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Could not set MSBUILD_EXE_PATH: " + exception + "\n\n");
            }
        }

        private static void RunMsBuild(string outputPath, string refPath, string projectFullPath, Boolean cleanBeforeBuild)
        {

            using (Process p = new Process())
            {

                var errorLog = "";
                var successLog = "";

                string arg1 = Path.GetFileName(projectFullPath);
                string arg2 = @" /p:OutDir=" + outputPath;
                string arg3 = @" /p:referencepath=" + refPath;
                string arg4 = @" /t:Clean,Build";
                string arg5 = @" /verbosity:q";
                string arg6 = @" /clp:ErrorsOnly";

                StringBuilder builder = new StringBuilder();

                builder.Append(Path.GetFileName(projectFullPath));
                builder.Append(@" /p:OutDir=" + outputPath);
                builder.Append(@" /p:referencepath=" + refPath);
                if (cleanBeforeBuild)
                {
                    builder.Append(@" /t:Clean,Build");
                }
                else
                {
                    builder.Append(@" /t:Build");
                }
            
                builder.Append(@" /verbosity:q");
                builder.Append(@" /clp:ErrorsOnly");

                p.StartInfo.WorkingDirectory = Path.GetDirectoryName(projectFullPath);
                p.StartInfo.FileName = "msBuild.exe";
                p.StartInfo.Arguments = builder.ToString();
                p.StartInfo.UseShellExecute = false;

                p.StartInfo.RedirectStandardOutput = true;
                //p.OutputDataReceived += (sender, data) =>
                //{
                //    Console.WriteLine("SUCCESS : " + data.Data);
                //};

                //p.StartInfo.RedirectStandardError = true;
                //p.ErrorDataReceived += (sender, data) =>
                //{
                //    Console.WriteLine("ERROR :" + data.Data);
                //};

                p.Start();

                string output = p.StandardOutput.ReadToEnd();
                if (output.ToLower().Contains("error"))
                {
                    Console.WriteLine();
                    errorLog = Environment.NewLine + "ERROR : " + projectFullPath + Environment.NewLine + output + Environment.NewLine +
                                "===========================================================================================";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR :" + output);
                    //UpdateErrorLog(outputPath, errorLog, errorLogFile);
                    Console.ForegroundColor = ConsoleColor.White;
                }


                p.WaitForExit();
                if (p.ExitCode == 1)
                {
                    throw new Exception("Build Failed");
                }

            }

        }

        private static void UpdateErrorLog(string outputPath, string errorLog, string logFile)
        {
            string logFullPath = outputPath + logFolder;
            DirectoryInfo logDir = new DirectoryInfo(logFullPath);
            NgFileMaker.CreateFolder(logDir);
            string logPath = logFullPath + "\\" + logFile;

            File.AppendAllText(logPath, errorLog);

        }

        private static void UpdateSuccessLog(string outputPath, string successLog, string logFile)
        {
            string logFullPath = outputPath + logFolder;
            DirectoryInfo logDir = new DirectoryInfo(logFullPath);
            NgFileMaker.CreateFolder(logDir);
            string logPath = logFullPath + "\\" + logFile;

            File.AppendAllText(logPath, successLog);

        }

        public static string MakeValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);
            return Regex.Replace(name, invalidRegStr, "_");
        }

        public static void DeleteLogSource(string logPath)
        {
            if (File.Exists(logPath))
            {
                File.Delete(logPath);
            }

        }

    }
}
