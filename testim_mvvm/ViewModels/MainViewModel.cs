using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using testim_mvvm.Commands;
using testim_mvvm.Model;
using testim_mvvm.Models;
using testim_mvvm.Services;

namespace testim_mvvm.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private object _currentViewModel;
        public object CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Deceased> Deceaseds { get; set; }

        public ICommand ShowLoginViewCommand { get; }
        public ICommand ShowEmployeeViewCommand { get; }
        public ICommand ShowAdminViewCommand { get; }
        public ICommand LogoutCommand { get; }

        public MainViewModel()
        {
            ShowLoginViewCommand = new RelayCommand(o => ShowLoginView());
            ShowEmployeeViewCommand = new RelayCommand(o => ShowEmployeeView());
            ShowAdminViewCommand = new RelayCommand(o => ShowAdminView());
            LogoutCommand = new RelayCommand(o => Logout());

            Users = DataService.LoadUsers();
            Deceaseds = DataService.LoadDeceaseds();

            ShowLoginView();
        }

        public void ShowLoginView()
        {
            CurrentViewModel = new LoginViewModel(this);
        }

        public void ShowEmployeeView()
        {
            CurrentViewModel = new EmployeeViewModel(this);
        }

        public void ShowAdminView()
        {
            CurrentViewModel = new AdminViewModel(this);
        }

        public void Logout()
        {
            DataService.SaveUsers(Users);
            DataService.SaveDeceaseds(Deceaseds);
            ShowLoginView();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
