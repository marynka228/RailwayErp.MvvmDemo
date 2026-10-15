using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RailwayErp.MvvmDemo.Models;
using RailwayErp.MvvmDemo.Services;

namespace RailwayErp.MvvmDemo.ViewModels
{
    public class TrainListViewModel : INotifyPropertyChanged
    {
        private readonly IAppStateService _appState;

        public ObservableCollection<Train> Trains { get; } = new();

        // Поля форми читають і пишуть напряму в сервіс стану.
        // Тому те, що користувач встиг ввести, завжди лежить у IAppStateService
        // і його можна зберегти на диск при згортанні застосунку.
        public string TrainNumber
        {
            get => _appState.DraftTrainNumber;
            set
            {
                if (_appState.DraftTrainNumber != value)
                {
                    _appState.DraftTrainNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Route
        {
            get => _appState.DraftRoute;
            set
            {
                if (_appState.DraftRoute != value)
                {
                    _appState.DraftRoute = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoadCommand { get; }
        public ICommand AddTrainCommand { get; }

        // IAppStateService підставляє DI-контейнер автоматично
        public TrainListViewModel(IAppStateService appState)
        {
            _appState = appState;

            LoadCommand = new Command(Load);
            AddTrainCommand = new Command(AddTrain);
        }

        // Викликається з OnAppearing сторінки
        private void Load()
        {
            Debug.WriteLine("[TrainList] LoadCommand виконано");

            // Оновлюємо поля форми з сервісу (після відновлення стану)
            OnPropertyChanged(nameof(TrainNumber));
            OnPropertyChanged(nameof(Route));

            if (Trains.Count > 0) return;

            Trains.Add(new Train { Id = 1, Number = "001К", Route = "Київ — Львів" });
            Trains.Add(new Train { Id = 2, Number = "043Л", Route = "Львів — Одеса" });
            Trains.Add(new Train { Id = 3, Number = "115Д", Route = "Дніпро — Харків" });
        }

        private void AddTrain()
        {
            if (string.IsNullOrWhiteSpace(TrainNumber)) return;

            Trains.Add(new Train
            {
                Id = Trains.Count + 1,
                Number = TrainNumber,
                Route = Route
            });

            TrainNumber = string.Empty;
            Route = string.Empty;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}