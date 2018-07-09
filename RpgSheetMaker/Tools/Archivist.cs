using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Library.CommonObjects;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace RpgSheetMaker.Tools
{
    public class Archivist : IArchivist
    {
        private readonly IFileProvider _fileProvider;
        private static string sheetPath;
        private static string archivePath;

        public Archivist(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;

            var sheetFolder = _fileProvider.GetDirectoryContents("").FirstOrDefault(x => x.Name == "CharacterSheets");
            
            if(sheetFolder.Exists && sheetFolder.IsDirectory)
                sheetPath = sheetFolder.PhysicalPath;


            var archiveFolder = _fileProvider.GetDirectoryContents("").FirstOrDefault(x => x.Name == "Archives");
            if (archiveFolder.Exists && archiveFolder.IsDirectory)
                archivePath = archiveFolder.PhysicalPath;

        }

        public List<Character> ReadAll()
        {
            var list = new List<Character>();

            var files = from file in Directory.EnumerateFiles(sheetPath, "*.txt", SearchOption.TopDirectoryOnly)
                        where file.Contains("json")
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
            var sheetName = sheetPath + "\\" + name + "-json.txt";
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
            var sheetName = sheetPath + "\\" + charac.Name + "-json.txt";

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
