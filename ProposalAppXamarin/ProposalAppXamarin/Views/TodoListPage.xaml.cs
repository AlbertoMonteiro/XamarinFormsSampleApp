using ProposalAppXamarin.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProposalAppXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListPage : ContentPage
    {
        private TodoListPageViewModel viewModel;

        public TodoListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new TodoListPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Todos.Count == 0)
                viewModel.IsBusy = true;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new TodoCreatePage(), true);
        }
    }
}