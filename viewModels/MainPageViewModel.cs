using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TodoListNew.viewModels
{
    public partial class MainPageViewModel : ObservableObject
    {

        public MainPageViewModel()
        {
            Items = new ObservableCollection<string>();
            completedItems = new ObservableCollection<string>();

        }
        public ICommand CompleteCommand => new Command<string>(Complete);

        [ObservableProperty]
        private ObservableCollection<string> items;

        [ObservableProperty]
        private string text;

        [RelayCommand]
        private void Add()
        {
            if (Text == null || Text == "")
            {
                Application.Current?.MainPage?.DisplayAlert("Resultado", "Debe ingresar una tarea.", "Aceptar");
                return;
            }
            else { Items.Add(Text); }

        }

        [RelayCommand]
        private void Delete(string s)
        {
            if (Items.Contains(s))
                Items.Remove(s);
        }
        private ObservableCollection<string> completedItems;

        public ObservableCollection<string> CompletedItems
        {
            get => completedItems;
            set => SetProperty(ref completedItems, value);
        }
        private void Complete(string item)
        {


            CompletedItems.Add(item);
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }

        }

        private bool showCompleted;

        public bool ShowCompleted
        {
            get => showCompleted;
            set
            {
                SetProperty(ref showCompleted, value);
                OnPropertyChanged(nameof(VisibleItems));
            }
        }

        public IEnumerable<string> VisibleItems
        {
            get
            {
                if (ShowCompleted)
                    return CompletedItems;
                else
                    return Items;
            }
        }

        public ICommand ShowCompletedCommand => new Command(ShowCompletedItems);

        private void ShowCompletedItems()
        {
            ShowCompleted = !ShowCompleted;
        }

    }
}
