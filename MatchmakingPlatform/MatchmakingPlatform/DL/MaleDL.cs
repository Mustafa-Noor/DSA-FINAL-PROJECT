using System.Text.Json;
using System.IO;
using System.Windows;
using MatchmakingPlatform.BL;
using System.Diagnostics;
using MatchmakingPlatform.Utils;

namespace MatchmakingPlatform.DL
{
    public class MaleDL
    {

        public static SalaryTree salaryTree = new SalaryTree();
        public static HeightTree heightTree = new HeightTree();
        public static AgeTree AgeTree = new AgeTree();
        static Dictionary<string, Male> Males = new Dictionary<string, Male>();

        static string filePath = Utility.FilePath+ "\\Data\\MaleData.json";
        static string GetJsonFilePath()
        {
            string relativePath = "Data\\MaleData.json";

            // Get the absolute path
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            MessageBox.Show(absolutePath);
            return absolutePath;
        }



        public static void SavetoFile()
        {
            string json = JsonSerializer.Serialize(Males, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, json);
        }

        public static void LoadDAta()
        {
            if (File.Exists(filePath))
            {
                string loadedJson = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(loadedJson))
                {
                    loadedJson = "{}";
                }
                Males = JsonSerializer.Deserialize<Dictionary<string, Male>>(loadedJson);
                foreach (Male male in Males.Values)
                {
                    AgeTree.InsertIntoAgeTree(male);
                    heightTree.InsertIntoHeightTree(male);
                    salaryTree.InsertIntoSalaryTree(male);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        static public bool AddUser(Male user)
        {
            if (Males.ContainsKey(user.UserName))
            {
                return false; // User already exists
            }

            Males[user.UserName] = user;
            SavetoFile();
            AgeTree.InsertIntoAgeTree(user);
            heightTree.InsertIntoHeightTree(user);
            salaryTree.InsertIntoSalaryTree(user);
            return true;
        }

        static public bool CheckUserExists(string username)
        {
            if (Males.ContainsKey(username))
            {
                return true;
            }

            return false;
        }
        static public Male FindUser(string username)
        {
            if (Males.ContainsKey(username))
            {
                return Males[username];
            }

            return null;
        }
    }
}

