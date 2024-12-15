using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchmakingPlatform{
    public class Preference{
        public string Pref{get;set; } 
        public int Value { get;set; }
        public string Condition { get;set; }


        public Preference(string Pref,int Value,string Condition)
        {
            this.Pref = Pref;
            this.Value = Value;
            this.Condition = Condition;
        }

    }
}
