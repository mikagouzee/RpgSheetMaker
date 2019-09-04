using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RpgSheetMaker.Tools
{
    public class LogMachine : ILogMachine
    {
        private string logFile;
        private readonly IFileProvider _fileProvider;

        public LogMachine(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
            string logFolderPath = "";

            var assemblyPath = AssemblyLocator.GetAssemblyLocation();

            var logFolder = Directory.GetDirectories(assemblyPath).FirstOrDefault(x => x == "logfolder");

            //var logFolder = _fileProvider.GetDirectoryContents("").FirstOrDefault(x => x.Name == "logFolder");

            if(logFolder == null)
            {
                Directory.CreateDirectory(Path.Combine(assemblyPath, "logFolder"));
            }

            logFolderPath = Path.GetFullPath(Path.Combine(assemblyPath, "logFolder"));

            logFile = Path.Combine(logFolderPath, "log.txt");

            if (!File.Exists(logFile))
            {
                File.Create(logFile).Close();
            }
        }

        public void Log(string content)
        {
            using (StreamWriter file = new StreamWriter(logFile, true))
            {
                file.WriteLine(DateTime.Now + " : " + content);
                //file.WriteLine(Environment.NewLine);             
            }

        }
    }
}
