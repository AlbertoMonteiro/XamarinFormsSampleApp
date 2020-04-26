using ProposalAppXamarin.Repositories;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProposalAppXamarin.ViewModels
{
    public class TodoCreatePageViewModel : BaseViewModel
    {
        private readonly ITodoRepository _repository = DependencyService.Get<ITodoRepository>();

        public TodoCreatePageViewModel()
            => SaveItemCommand = new Command(async () => await SaveItem());

        public INavigation Navigation { get; set; }

        public TodoItem Item { get; } = new TodoItem();

        public Command SaveItemCommand { get; }

        private async Task SaveItem()
        {
            await _repository.AddItemAsync(Item);
            var popModalAsync = await Navigation.PopModalAsync(true);
            MessagingCenter.Send(this, "Todo added");
        }
    }
}