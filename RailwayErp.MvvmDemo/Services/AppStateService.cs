namespace RailwayErp.MvvmDemo.Services
{
    public interface IAppStateService
    {
        // Чернетка форми редагування (те, що користувач встиг ввести)
        string DraftTrainNumber { get; set; }
        string DraftRoute { get; set; }

        // Час початку поточного сеансу
        DateTime SessionStarted { get; }

        void SaveToStorage();
        void LoadFromStorage();
    }

    public class AppStateService : IAppStateService
    {
        public string DraftTrainNumber { get; set; } = string.Empty;
        public string DraftRoute { get; set; } = string.Empty;

        public DateTime SessionStarted { get; } = DateTime.Now;

        // Записуємо чернетку на диск, щоб вона пережила закриття застосунку
        public void SaveToStorage()
        {
            Preferences.Set("draft_train_number", DraftTrainNumber);
            Preferences.Set("draft_route", DraftRoute);
        }

        // Читаємо чернетку з диска
        public void LoadFromStorage()
        {
            DraftTrainNumber = Preferences.Get("draft_train_number", string.Empty);
            DraftRoute = Preferences.Get("draft_route", string.Empty);
        }
    }
}