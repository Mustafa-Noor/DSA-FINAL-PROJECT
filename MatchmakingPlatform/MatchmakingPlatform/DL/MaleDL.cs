﻿using System.Text.Json;
using System.IO;
using System.Windows;
using MatchmakingPlatform.BL;

namespace MatchmakingPlatform.DL{
    class MaleDL{

        static Dictionary<string, Male> Males = new Dictionary<string, Male>();

        static string filePath = "C:\\Users\\musno\\OneDrive\\Desktop\\SEMESTER 3\\DSA\\Projects\\DSA-FINAL-PROJECT\\MatchmakingPlatform\\MatchmakingPlatform\\Data\\MaleData.json";
        static string GetJsonFilePath(){
            string relativePath = "Data\\MaleData.json";
        
        // Get the absolute path
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            MessageBox.Show(absolutePath);
            return absolutePath;
        }

        static void SavetoFile(){
            string json = JsonSerializer.Serialize(Males, new JsonSerializerOptions{
                WriteIndented = true
            });
            File.WriteAllText(filePath, json);
        }

        public static void LoadDAta(){
            if(File.Exists(filePath))
            {
                string loadedJson = File.ReadAllText(filePath);
                if(string.IsNullOrEmpty(loadedJson)){
                    loadedJson = "{}";    
                }
                Males = JsonSerializer.Deserialize<Dictionary<string,Male>>(loadedJson);
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
            if(Males.ContainsKey(username))
            {
                return Males[username];
            }

            return null;
        }
    }
}
