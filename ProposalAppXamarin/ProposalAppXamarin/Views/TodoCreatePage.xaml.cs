using ProposalAppXamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProposalAppXamarin.Views
{
    [DesignTimeVisible(false)]
    public partial class TodoCreatePage : ContentPage
    {
        public TodoCreatePage()
        {
            InitializeComponent();

            BindingContext = new TodoCreatePageViewModel(Navigation);
        }
    }
}