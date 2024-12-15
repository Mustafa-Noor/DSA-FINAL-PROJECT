using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MatchmakingPlatform.Utils
{
    internal class Utility
    {
        public static string FilePath = "E:\\Studies\\3rd Samester\\DSAFinal\\DSA-FINAL-PROJECT\\MatchmakingPlatform\\MatchmakingPlatform";
        static Dictionary<string, int> educationLevels = new Dictionary<string, int>
        {
            { "Under Matric", 1 },
            { "Matric", 2 },
            { "Inter", 3 },
            { "Diploma", 4 },
            { "Bachelor", 5 },
            { "Masters", 6 },
            { "Doctorate", 7 }
        };
        public static int GetEducationScore(string education){
            return educationLevels[education];
        }
    }
}
