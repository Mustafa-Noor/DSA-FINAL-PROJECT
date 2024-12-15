using MatchmakingPlatform.BL;
using MatchmakingPlatform.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    
    public class EducationTree
    {
        public EducationTree()
        {
            root = null;
        }
        private MaleNode root;

        public void InsertIntoEducationTree(Male data)
        {
            if (root == null)
            {
                root = new MaleNode(data);
            }
            else
            {
                RecursivelyAddInEducationTree(root, data);
            }

        }

        private void RecursivelyAddInEducationTree(MaleNode node, Male data)
        {
            if (Utility.GetEducationScore(data.Education) < Utility.GetEducationScore(node.Data.Education))
            {
                if (node.Left == null)
                    node.Left = new MaleNode(data);
                else
                    RecursivelyAddInEducationTree(node.Left, data);

            }
            else
            {
                if (node.Right == null)
                    node.Right = new MaleNode(data);
                else
                    RecursivelyAddInEducationTree(node.Right, data);
            }
        }

        public HashSet<Male> FilterDataBasedOnEducation(string education)
        {

            HashSet<Male> result = new HashSet<Male>();
                FilterLessDataRecursive(root, education, result);
            return result;
        }

        void FilterLessDataRecursive(MaleNode node,string education, HashSet<Male> result)
        {
            if (node == null) return;
            if (Utility.GetEducationScore(node.Data.Education) < Utility.GetEducationScore(education))
            {
                result.Add(node.Data);

                FilterLessDataRecursive(node.Left, education, result);

                FilterLessDataRecursive(node.Right, education, result);
            }
            else
            {
                FilterLessDataRecursive(node.Left, education, result);
            }
        }

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

}
