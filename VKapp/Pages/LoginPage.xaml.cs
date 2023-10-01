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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public static string Login {  get; set; }
        public static VKDataBaseEntities db = new VKDataBaseEntities();
        public LoginPage()
        {
            InitializeComponent();
            Label1.Text += " " + StartPage.Login;
        }


        bool Passb { get; set; }
        private void PasswordTb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (PasswordTb.IsKeyboardFocused && Passb is false)
            {
                Passb = true;
                PasswordTb.Text = "";
                PasswordTb.Foreground = System.Windows.Media.Brushes.Black;
                Opacity = 1;
            }


        }

        private void PasswordTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(StartPage.Login);
            //int ThatOneUserId = db.User.FirstOrDefault(x => x.PhoneNum == StartPage.Login).id;
            //if (db.User.Find(ThatOneUserId).Password != PasswordTb.Text)
            //{
            //    MessageBox.Show("Ну это что за блин ваще капец(( пароль не правильный кароче");
            //}
            //else
            //{
            //    MessageBox.Show("Добро пожаловать, " + db.User.Find(ThatOneUserId).Name);
            //}
            string thatOneLogin = StartPage.CurrentUser.Login;
            if (StartPage.Users.Find(x => x.Login == thatOneLogin).Password != PasswordTb.Text)
            {
                MessageBox.Show("Ну это что за блин ваще капец(( пароль не правильный кароче");
            }
            else
            {
                MessageBox.Show("Добро пожаловать, " + StartPage.Users.Find(x => x.Login == thatOneLogin).Name);
            }

        }
    }
}
