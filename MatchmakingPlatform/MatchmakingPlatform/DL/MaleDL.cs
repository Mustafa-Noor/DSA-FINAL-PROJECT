using System.Text.Json;
using System.IO;
using System.Windows;
using MatchmakingPlatform.BL;
using System.Diagnostics;

namespace MatchmakingPlatform.DL
{

    public class MaleNode
    {
        public MaleNode(Male male)
        {
            this.Data = male;
            Left = null;
            Right = null;
        }
        public Male Data;
        public MaleNode Left;
        public MaleNode Right;
    }

    public class SalaryTree
    {
        public SalaryTree()
        {
            root = null;
        }
        private MaleNode root;

        public void InsertIntoSalaryTree(Male data)
        {
            if (root == null)
            {
                root = new MaleNode(data);
            }
            else
            {
                RecursivelyAddInSalaryTree(root, data);
            }

        }

        private void RecursivelyAddInSalaryTree(MaleNode node, Male data)
        {
            if (data.Salary < node.Data.Salary)
            {
                if (node.Left == null)
                    node.Left = new MaleNode(data);
                else
                    RecursivelyAddInSalaryTree(node.Left, data);

            }
            else
            {
                if (node.Right == null)
                    node.Right = new MaleNode(data);
                else
                    RecursivelyAddInSalaryTree(node.Right, data);
            }
        }

        public HashSet<Male> FilterDataBasedOnSalary(int salary, string Condition)
        {

            HashSet<Male> result = new HashSet<Male>();
            if (Condition == "Less than")
            {
                FilterLessDataRecursive(root, salary, result);
            }
            else
            {
                FilterMoreDataRecursive(root, salary, result);
            }
            return result;
        }

        void FilterLessDataRecursive(MaleNode node, int salary, HashSet<Male> result)
        {
            if (node == null) return;
            if (node.Data.Salary < salary)
            {
                result.Add(node.Data);

                FilterLessDataRecursive(node.Left, salary, result);

                FilterLessDataRecursive(node.Right, salary, result);
            }
            else
            {
                FilterLessDataRecursive(node.Left, salary, result);
            }

        }


        void FilterMoreDataRecursive(MaleNode node, int salary, HashSet<Male> result)
        {
            if (node == null) return;
            if (node.Data.Salary > salary)
            {
                result.Add(node.Data);

                FilterMoreDataRecursive(node.Right, salary, result);

                FilterMoreDataRecursive(node.Left, salary, result);
            }
            else
            {
                FilterMoreDataRecursive(node.Right, salary, result);
            }
        }

    }

    public class HeightTree
    {
        public HeightTree()
        {
            root = null;
        }
        private MaleNode root;

        public void InsertIntoHeightTree(Male data)
        {
            if (root == null)
            {
                root = new MaleNode(data);
            }
            else
            {
                RecursivelyAddIngHeightTree(root, data);
            }

        }

        private void RecursivelyAddIngHeightTree(MaleNode node, Male data)
        {
            if (data.Height < node.Data.Height)
            {
                if (node.Left == null)
                    node.Left = new MaleNode(data);
                else
                    RecursivelyAddIngHeightTree(node.Left, data);

            }
            else
            {
                if (node.Right == null)
                    node.Right = new MaleNode(data);
                else
                    RecursivelyAddIngHeightTree(node.Right, data);
            }
        }

        public HashSet<Male> FilterDataBasedOnHeight(int height, string Condition)
        {

            HashSet<Male> result = new HashSet<Male>();
            if (Condition == "Less than")
            {
                FilterLessDataRecursive(root, height, result);
            }
            else
            {
                FilterMoreDataRecursive(root, height, result);
            }
            return result;
        }

        void FilterLessDataRecursive(MaleNode node, int height, HashSet<Male> result)
        {
            if (node == null) return;
            if (node.Data.Height < height)
            {
                result.Add(node.Data);

                FilterLessDataRecursive(node.Left, height, result);

                FilterLessDataRecursive(node.Right, height, result);
            }
            else
            {
                FilterLessDataRecursive(node.Left, height, result);
            }

        }


        void FilterMoreDataRecursive(MaleNode node, int height, HashSet<Male> result)
        {
            if (node == null) return;
            if (node.Data.Height > height)
            {
                result.Add(node.Data);

                FilterMoreDataRecursive(node.Right, height, result);

                FilterMoreDataRecursive(node.Left, height, result);
            }
            else
            {
                FilterMoreDataRecursive(node.Right, height, result);
            }
        }
    }
    public class AgeTree
    {
        public AgeTree()
        {
            root = null;
        }
        private MaleNode root;

        public void InsertIntoAgeTree(Male data)
        {
            if (root == null)
            {
                root = new MaleNode(data);
            }
            else
            {
                RecursivelyAddInAgeTree(root, data);
            }

        }

        private void RecursivelyAddInAgeTree(MaleNode node, Male data)
        {
            if (data.Age < node.Data.Age)
            {
                if (node.Left == null)
                    node.Left = new MaleNode(data);
                else
                    RecursivelyAddInAgeTree(node.Left, data);

            }
            else
            {
                if (node.Right == null)
                    node.Right = new MaleNode(data);
                else
                    RecursivelyAddInAgeTree(node.Right, data);
            }
        }

        public HashSet<Male> FilterDataBasedOnAge(int age, string Condition)
        {

            HashSet<Male> result = new HashSet<Male>();
            if (Condition == "Less than")
            {
                FilterLessDataRecursive(root, age, result);
            }
            else
            {
                FilterMoreDataRecursive(root, age, result);
            }
            return result;
        }

        void FilterLessDataRecursive(MaleNode node, int age, HashSet<Male> result)
        {
            if (node == null) return;
            if (node.Data.Age < age)
            {
                result.Add(node.Data);

                FilterLessDataRecursive(node.Left, age, result);

                FilterLessDataRecursive(node.Right, age, result);
            }
            else
            {
                FilterLessDataRecursive(node.Left, age, result);
            }

        }


        void FilterMoreDataRecursive(MaleNode node, int age, HashSet<Male> result)
        {
            if (node == null) return;
            if (node.Data.Age > age)
            {
                result.Add(node.Data);

                FilterMoreDataRecursive(node.Right, age, result);

                FilterMoreDataRecursive(node.Left, age, result);
            }
            else
            {
                FilterMoreDataRecursive(node.Right, age, result);
            }
        }
    }


    public class MaleDL
    {

        public static SalaryTree salaryTree = new SalaryTree();
        public static HeightTree heightTree = new HeightTree();
        public static AgeTree AgeTree = new AgeTree();
        static Dictionary<string, Male> Males = new Dictionary<string, Male>();

        static string filePath = "C:\\Users\\musno\\OneDrive\\Desktop\\SEMESTER 3\\DSA\\Projects\\DSA-FINAL-PROJECT\\MatchmakingPlatform\\MatchmakingPlatform\\Data\\MaleData.json";
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

