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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VKapp.DataBase;

namespace VKapp.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public static string Login { get; set; }
        VKDataBaseEntities db = new VKDataBaseEntities();
        public static List<User> Users = new List<User>();
        public static User CurrentUser { get; set; }
        public StartPage()
        {
            InitializeComponent();

        }
        bool Logb { get; set; }
        private void LoginTb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (LoginTb.IsKeyboardFocused && Logb is false)
            {
                Logb = true;
                LoginTb.Text = "";
                LoginTb.Foreground = System.Windows.Media.Brushes.Black;

            }
            else if (LoginTb.IsKeyboardFocused is false && LoginTb.Text == "")
            {
                Logb = false;
                LoginTb.Text = "Телефон или почта";
                LoginTb.Foreground = System.Windows.Media.Brushes.Gray;

            }
        }
        private void LoginTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {


            //if (db.User.Any(x => x.PhoneNum == LoginTb.Text))
            //{
            //    Login = LoginTb.Text;
            //    NavigationService.Navigate(new Pages.LoginPage());
            //}
            //else
            //{
            //    HiddenTb.Visibility = Visibility.Visible;
            //    HiddenTb.FontSize = 12;
            //}
            if (Users.Any(x => x.Login == LoginTb.Text))
            {
                CurrentUser = Users.Find(x => x.Login == LoginTb.Text);
                NavigationService.Navigate(new Pages.LoginPage());
            }
            else
            {
                HiddenTb.Visibility = Visibility.Visible;
                HiddenTb.FontSize = 12;
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.RegistrationPage());
        }
    }
}
