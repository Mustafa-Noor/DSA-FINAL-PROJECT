using System.Windows;
using MatchmakingPlatform.BL;
using MatchmakingPlatform.DL;
using MatchmakingPlatform.Extras;

namespace MatchmakingPlatform.Forms
{
    public partial class FemalePrefrencesForm : Window
    {
        Female female;
        public FemalePrefrencesForm(Female female)
        {
            
            InitializeComponent();
            this.female = female;
            this.DataContext = this.female;
        }

        // Find Pairs Button Click
        private void FindPairsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Find pairs functionality not implemented yet!");
        }
        private void AddPreferenceButton_Click_1(object sender, RoutedEventArgs e)
        {
            FemalePreferenceBox customMessageBox = new FemalePreferenceBox(female);
            customMessageBox.ShowDialog();
        }
        
        private void FindMatchesTest(object sender, RoutedEventArgs e) {
            if(female.Preferences.Count == 0){ 
                MessageBox.Show("Enter preferences to find a pair");
                return;
            }
            HashSet<Male> FeasiblePairs = GetMatches();
            Matches matches = new Matches(FeasiblePairs);
            matches.Show();
            this.Close();
        }

        HashSet<Male> GetMatches() {
            HashSet<Male> m = new HashSet<Male>();
            //firstly we will take the union and then we will keep taking intersection until we reach our final destination
            bool isFirst = true;
            while(female.Queue.Count != 0){
                MessageBox.Show(female.Queue.Count.ToString());
                HashSet<Male> next = new HashSet<Male>();
                Preference pref = female.Queue.Dequeue();
                if (pref.Pref == "Age") {
                    next = MaleDL.AgeTree.FilterDataBasedOnAge(pref.Value,pref.Condition);
                }else if(pref.Pref == "Height") {
                    next = MaleDL.heightTree.FilterDataBasedOnHeight(pref.Value,pref.Condition);
                }else if(pref.Pref == "Monthly Income"){
                    next = MaleDL.salaryTree.FilterDataBasedOnSalary(pref.Value,pref.Condition);
                }else if(pref.Pref == "Education") {
                    next = MaleDL.educationTree.FilterDataBasedOnEducation(pref.Condition);
                }else if(pref.Pref == "Profession"){
                    next = MaleDL.FilterDataBasedOnProfession(pref.Condition);
                }
                if (isFirst) {
                    m.UnionWith(next);
                    isFirst = false;
                }else{
                    m.IntersectWith(next);
                }
                female.Preferences.RemoveAt(0);
                FemaleDL.SavetoFile();
            }
            return m;
        }
        private void ClearPreferencesButton_Click_1(object sender, RoutedEventArgs e)
        {
            female.clearPreferences();
            FemaleDL.SavetoFile();
        }
    }
}
