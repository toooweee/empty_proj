using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using testim_mvvm.Commands;
using testim_mvvm.Model;

namespace testim_mvvm.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }

        private readonly MainViewModel mainViewModel;

        public LoginViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            LoginCommand = new RelayCommand(Login);
        }

        private void Login(object parameter)
        {
            var users = mainViewModel.Users;

            var user = users.FirstOrDefault(u => u.Username == Username && u.Password == Password);

            if (user != null)
            {
                if (user.Role == "Admin")
                {
                    mainViewModel.ShowAdminView();
                }
                else if (user.Role == "Employee")
                {
                    mainViewModel.ShowEmployeeView();
                }
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
