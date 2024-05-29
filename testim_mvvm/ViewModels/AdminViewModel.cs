using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using testim_mvvm.Commands;
using testim_mvvm.Model;

namespace testim_mvvm.ViewModels
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand LogoutCommand { get; }

        private readonly MainViewModel mainViewModel;

        public ObservableCollection<User> Users => mainViewModel.Users;

        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private string _newUsername;
        public string NewUsername
        {
            get => _newUsername;
            set
            {
                _newUsername = value;
                OnPropertyChanged(nameof(NewUsername));
            }
        }

        private string _newPassword;
        public string NewPassword
        {
            get => _newPassword;
            set
            {
                _newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        public AdminViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            AddEmployeeCommand = new RelayCommand(AddEmployee);
            DeleteEmployeeCommand = new RelayCommand(DeleteEmployee);
            BackCommand = new RelayCommand(Back);
            LogoutCommand = new RelayCommand(Logout);
        }

        private void AddEmployee(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(NewUsername) && !string.IsNullOrWhiteSpace(NewPassword))
            {
                Users.Add(new User { Id = Users.Count + 1, Username = NewUsername, Password = NewPassword, Role = "Employee" });
                NewUsername = string.Empty;
                NewPassword = string.Empty;
            }
        }

        private void DeleteEmployee(object parameter)
        {
            if (SelectedUser != null && Users.Contains(SelectedUser))
            {
                Users.Remove(SelectedUser);
            }
        }

        private void Back(object parameter)
        {
            mainViewModel.ShowLoginView();
        }

        private void Logout(object parameter)
        {
            mainViewModel.Logout();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
