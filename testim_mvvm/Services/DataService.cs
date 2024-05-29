using System.Collections.ObjectModel;
using testim_mvvm.Model;
using testim_mvvm.Models;

namespace testim_mvvm.Services
{
    public static class DataService
    {
        private static readonly string UserFilePath = "users.json";
        private static readonly string DeceasedFilePath = "deceaseds.json";
        private static readonly JsonDataService jsonDataService = new JsonDataService();

        public static ObservableCollection<User> LoadUsers()
        {
            var users = jsonDataService.LoadData<ObservableCollection<User>>(UserFilePath);
            return users ?? new ObservableCollection<User>
            {
                new User { Id = 1, Username = "admin", Password = "admin", Role = "Admin" },
                new User { Id = 2, Username = "employee", Password = "employee", Role = "Employee" }
            };
        }

        public static void SaveUsers(ObservableCollection<User> users)
        {
            jsonDataService.SaveData(UserFilePath, users);
        }

        public static ObservableCollection<Deceased> LoadDeceaseds()
        {
            var deceaseds = jsonDataService.LoadData<ObservableCollection<Deceased>>(DeceasedFilePath);
            return deceaseds ?? new ObservableCollection<Deceased>
            {
                new Deceased { Id = 1, FullName = "Трупик 1", DateOfDeath = new DateTime(2020, 1, 1), CauseOfDeath = "Естественная смерть" },
                new Deceased { Id = 2, FullName = "Трупик 2", DateOfDeath = new DateTime(2021, 5, 15), CauseOfDeath = "Насильственная смерть" }
            };
        }

        public static void SaveDeceaseds(ObservableCollection<Deceased> deceaseds)
        {
            jsonDataService.SaveData(DeceasedFilePath, deceaseds);
        }
    }
}
