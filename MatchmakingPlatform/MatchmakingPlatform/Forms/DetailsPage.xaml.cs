using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MatchmakingPlatform.BL;
using System.Text.Json;
using System.Net;
using System.Reflection;
using System.Windows.Media.Media3D;

namespace MatchmakingPlatform.Forms
{
    /// <summary>
    /// Interaction logic for DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Window
    {
        public Male CurrentUser { get; set; }

        public DetailsPage(Male male)
        {
            CurrentUser = male;
            InitializeComponent();

            //CurrentUser = new Male
            //{
            //};

            //CurrentUser.FirstName = "John";
            //   CurrentUser.LastName = "Doe";
            //CurrentUser.Email = "john.doe@example.com";
            //   CurrentUser.ContactNumber = "1234567890";
            //   CurrentUser.Address = "123 Main St";
            //   CurrentUser.City = "New York";
            //   CurrentUser.Profession = "Engineer";
            //   CurrentUser.Height = 180;
            //   CurrentUser.Education = "Bachelor's Degree";
            //   CurrentUser.Salary = 75000;
            //   CurrentUser.Image = "path_to_image.jpg"; // Replace with actual image path
            //   CurrentUser.DateOfBirth = new DateTime(1990, 1,1);
            //   CurrentUser.Gender = "Male";
            //CurrentUser.Age = 34;

            DataContext = CurrentUser;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
