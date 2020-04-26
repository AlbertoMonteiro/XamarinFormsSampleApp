using System.Threading.Tasks;
using ProposalAppXamarin.Repositories;
using Xamarin.Forms;

namespace ProposalAppXamarin.ViewModels
{
    public class TodoCreatePageViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private readonly ITodoRepository _repository = DependencyService.Get<ITodoRepository>();

        public TodoCreatePageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Item = new TodoItem();
            SaveItemCommand = new Command(async () => await SaveItem());
        }

        private async Task SaveItem()
        {
            await _repository.AddItemAsync(Item);
            await _navigation.PopModalAsync(true);
            MessagingCenter.Send(Item, "Todo added");
        }

        public TodoItem Item { get; }
        public Command SaveItemCommand { get; }
    }
}