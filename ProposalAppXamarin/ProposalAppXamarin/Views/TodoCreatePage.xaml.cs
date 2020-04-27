using ProposalAppXamarin.ViewModels;
using Xamarin.Forms;

namespace ProposalAppXamarin.Views
{
    public partial class TodoCreatePage : ContentPage
    {
        public TodoCreatePage()
            => InitializeComponent();

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is TodoCreatePageViewModel viewModel)
                viewModel.Navigation = Navigation;
        }
    }
}