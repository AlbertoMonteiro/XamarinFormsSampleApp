using ProposalAppXamarin.ViewModels;
using System;
using Xamarin.Forms;

namespace ProposalAppXamarin.Views
{
    public partial class TodoListPage : ContentPage
    {
        private TodoListPageViewModel ViewModel => (TodoListPageViewModel)BindingContext;

        public TodoListPage()
            => InitializeComponent();

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel.Todos.Count == 0)
                ViewModel.IsBusy = true;
        }

        private void Button_OnClicked(object sender, EventArgs e)
            => Navigation.PushModalAsync(new TodoCreatePage(), true);
    }
}