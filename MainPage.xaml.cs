using TodoListNew.viewModels;

namespace TodoListNew
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

      
    }

}
