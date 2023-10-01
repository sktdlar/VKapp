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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        int count = LoginPage.db.User.Count();
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void loginTb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            loginTb.Text = "";
            loginTb.Foreground = System.Windows.Media.Brushes.Black;
        }

        private void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StartPage.Users.Any(x => x.Login == loginTb.Text))
            {
                MessageBox.Show("Пользователь с таким номером уже зарегистрирован!");
                NavigationService.GoBack();
            }
            else if (PasswordTb.Visibility == Visibility.Hidden)
            {
                PasswordTb.Visibility = Visibility.Visible;
                PasswordTb.Height = 40;
            }
            else
            {

                if (loginTb.Text.Length == 11 && PasswordTb.Password.Length >= 8)
                {
                    StartPage.Users.Add(new User(loginTb.Text, PasswordTb.Password, Name = ""));
                    MessageBox.Show("Регистрация прошла успешно!");
                    LoginPage.db.SaveChanges();
                    NavigationService.Navigate(new Pages.StartPage());
                }
                else
                {
                    MessageBox.Show("Что то не так, пароль должен быть не менее 8 символов а номер телефона ровно 11 цифр");
                }
            }

            //if(LoginPage.db.User.Any(x => x.PhoneNum == loginTb.Text))
            //{
            //    MessageBox.Show("Пользователь с таким номером уже зарегистрирован!");
            //    NavigationService.GoBack();
            //}
            //else if(PasswordTb.Visibility == Visibility.Hidden)
            //{
            //    PasswordTb.Visibility = Visibility.Visible;
            //    PasswordTb.Height = 40;
            //}
            //else
            //{

            //    if(loginTb.Text.Length == 11 && PasswordTb.Password.Length >= 8)
            //    {
            //        LoginPage.db.User.Add(new User {id = count + 1, Name = "Ну не добавил я поле ввода и че((", Password = PasswordTb.Password, PhoneNum = loginTb.Text });
            //        MessageBox.Show("Регистрация прошла успешно!");
            //        LoginPage.db.SaveChanges();
            //        NavigationService.Navigate(new Pages.StartPage());
            //    }
            //    else
            //    {
            //        MessageBox.Show("Что то не так, пароль должен быть не менее 8 символов а номер телефона ровно 11 цифр");
            //    }
            //}
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
