using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Library.CommonObjects;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace RpgSheetMaker.Tools
{
    public class Archivist : IArchivist
    {
        private readonly IFileProvider _fileProvider;
        private ILogMachine _logger;
        private static string sheetPath;
        private static string archivePath;

        public Archivist(IFileProvider fileProvider, ILogMachine logMachine)
        {
            _fileProvider = fileProvider;
            _logger = logMachine;

            //this will get the folder from which the code is executed.
            //our code should use that path and search inside if the needed folders exists.

            var current = AssemblyLocator.GetAssemblyLocation();

            _logger.Log($"Archivist looking inside {current} for required folders...");

            var directories = Directory.GetDirectories(current);

            Directory.CreateDirectory(Path.Combine(current, "CharacterSheets"));
            _logger.Log($"Archivist created Character Sheet folder");

            sheetPath = Path.GetFullPath(Path.Combine(current, "CharacterSheets"));

            var archiveFolder = directories.FirstOrDefault(x => x == "Archives");

            Directory.CreateDirectory(Path.Combine(current, "Archives"));
            _logger.Log($"Archivist created Archives folder");
            archivePath = Path.GetFullPath(Path.Combine(current, "Archives"));

            _logger.Log($"Characters will be saved in {sheetPath} and archived in {archivePath} .");


        }

        public List<Character> ReadAll()
        {
            var list = new List<Character>();

            _logger.Log($"Searching inside {sheetPath}");

            var files = from file in Directory.EnumerateFiles(sheetPath, "*.json", SearchOption.TopDirectoryOnly)
                        //where file.Contains("json")
                        select file;

            foreach (var item in files)
            {
                Character charac;

                using(StreamReader reader = new StreamReader(item))
                {
                    string jsonCharac = reader.ReadToEnd();
                    charac = JsonConvert.DeserializeObject<Character>(jsonCharac);
                    list.Add(charac);
                }
            }

            return list;
        }

        public Character ReadCharacterFromJson(string name)
        {
            var sheetName = sheetPath + "\\" + name + ".json";
            Character charac = new Character { };

            if (File.Exists(sheetName))
            {
                using (StreamReader reader = new StreamReader(sheetName))
                {
                    string jsonCharac = reader.ReadToEnd();
                    charac = JsonConvert.DeserializeObject<Character>(jsonCharac);
                }
            }

            return charac;
        }

        public void SaveCharacterAsJson(Character charac)
        {
            var sheetName = sheetPath + "\\" + charac.Name + ".json";

            using (StreamWriter writer = new StreamWriter(sheetName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, charac);
            }
        }

        public void WriteSummary(Character charac)
        {
            var sheetName = sheetPath + "\\" + charac.Name + ".txt";

            using (StreamWriter file = new StreamWriter(sheetName, true))
            {
                file.WriteLine("Game :" + charac.GameName);
                file.WriteLine("Character :" + charac.Name);

                file.WriteLine(Environment.NewLine);

                file.WriteLine("__Base Attributes__");
                foreach (var item in charac.BaseAttributes)
                {
                    file.WriteLine(item.Name + " : " + item.CurrentValue + " on " + item.Maximum);
                }
                file.WriteLine(Environment.NewLine);

                file.WriteLine("__Stats__");
                foreach (var item in charac.Stats)
                {
                    file.WriteLine(item.Name + " : " + item.CurrentValue);
                }
                file.WriteLine(Environment.NewLine);

                file.WriteLine("__Skills__");
                foreach (var item in charac.Skills)
                {
                    if (charac.Profession.JobSkills.Contains(item))
                        file.WriteLine(item.Name + " : " + item.CurrentValue + " on " + item.Maximum + " (Career Skill)");
                    else
                        file.WriteLine(item.Name + " : " + item.CurrentValue + " on " + item.Maximum);
                }

                file.WriteLine(Environment.NewLine);

                file.WriteLine("__Spendable points__");
                foreach (var item in charac.SpendablePoints)
                {
                    file.WriteLine(item.Name + " : " + item.CurrentValue + " lefts.");
                }
            }
        }

        public void ArchiveCharacter(string characterName)
        {
            var characSheet = ReadCharacterFromJson(characterName);

            var sheetName = archivePath + "\\" + characterName + "-archived-json.txt";

            using (StreamWriter writer = new StreamWriter(sheetName))
            {
                new JsonSerializer().Serialize(writer, characSheet);
            }
        }

        public void DeleteAndArchiveCharacter(string characterName)
        {
            ArchiveCharacter(characterName);

            var sheetName = sheetPath + "\\" + characterName + "-json.txt";

            if (File.Exists(sheetName))
            {
                File.Delete(sheetName);
            }
        }

    }
}
