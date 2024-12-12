using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MatchmakingPlatform.BL;

namespace MatchmakingPlatform.DL
{
    class FemaleDL
    {
        static Dictionary<string, Female> Females = new Dictionary<string, Female>();


        static void SavetoFile(){
            string json = JsonSerializer.Serialize(Females, new JsonSerializerOptions{
                WriteIndented = true
            });
            string filePath = "E:\\Studies\\3rd Samester\\DSAFinal\\DSA-FINAL-PROJECT\\MatchmakingPlatform\\MatchmakingPlatform\\Data\\FemaleData.json";//GetJsonFilePath();
            File.WriteAllText(filePath, json);
        }



        public static void LoadDAta(){
            string filePath = "E:\\Studies\\3rd Samester\\DSAFinal\\DSA-FINAL-PROJECT\\MatchmakingPlatform\\MatchmakingPlatform\\Data\\FemaleData.json";
            if(File.Exists(filePath))
            {
                string loadedJson = File.ReadAllText(filePath);
                if(string.IsNullOrEmpty(loadedJson)){
                    loadedJson = "{}";    
                }
                Females = JsonSerializer.Deserialize<Dictionary<string,Female>>(loadedJson);
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }






        static public bool AddUser(Female user)
        {
            if (Females.ContainsKey(user.Username))
            {
                return false; // User already exists
            }

            Females[user.Username] = user;
            SavetoFile();
            return true;
        }

        static public bool CheckUserExists(string username)
        {
            if (Females.ContainsKey(username))
            {
                return true;
            }

            return false;
        }

        static public Female FindUser(string username)
        {
            if (Females.ContainsKey(username))
            {
                return Females[username];
            }

            return null;
        }
    }
}
