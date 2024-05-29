using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using testim_mvvm.Commands;
using testim_mvvm.Models;

namespace testim_mvvm.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand BackCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand AddDeceasedCommand { get; }

        private readonly MainViewModel mainViewModel;

        public ObservableCollection<Deceased> Deceaseds => mainViewModel.Deceaseds;

        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        private DateTime _dateOfDeath;
        public DateTime DateOfDeath
        {
            get => _dateOfDeath;
            set
            {
                _dateOfDeath = value;
                OnPropertyChanged(nameof(DateOfDeath));
            }
        }

        private string _causeOfDeath;
        public string CauseOfDeath
        {
            get => _causeOfDeath;
            set
            {
                _causeOfDeath = value;
                OnPropertyChanged(nameof(CauseOfDeath));
            }
        }

        public EmployeeViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            BackCommand = new RelayCommand(Back);
            LogoutCommand = new RelayCommand(Logout);
            AddDeceasedCommand = new RelayCommand(AddDeceased);
        }

        private void AddDeceased(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(FullName) && DateOfDeath != default && !string.IsNullOrWhiteSpace(CauseOfDeath))
            {
                Deceaseds.Add(new Deceased { Id = Deceaseds.Count + 1, FullName = FullName, DateOfDeath = DateOfDeath, CauseOfDeath = CauseOfDeath });
                FullName = string.Empty;
                DateOfDeath = default;
                CauseOfDeath = string.Empty;
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
