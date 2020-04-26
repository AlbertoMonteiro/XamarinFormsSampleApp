using ProposalAppXamarin.Repositories;
using ProposalAppXamarin.Views;
using Xamarin.Forms;

namespace ProposalAppXamarin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<TodoRepository>();
            MainPage = new NavigationPage(new TodoListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
