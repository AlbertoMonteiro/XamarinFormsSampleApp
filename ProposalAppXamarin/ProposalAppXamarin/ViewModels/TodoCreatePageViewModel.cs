using ProposalAppXamarin.Repositories;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProposalAppXamarin.ViewModels
{
    public class TodoCreatePageViewModel : BaseViewModel
    {
        private readonly ITodoRepository _repository = DependencyService.Get<ITodoRepository>();
        private bool _isSaving;

        public TodoCreatePageViewModel()
            => SaveItemCommand = new Command(async () => await SaveItem());

        public INavigation Navigation { get; set; }

        public TodoItem Item { get; } = new TodoItem();

        public Command SaveItemCommand { get; }

        public bool IsSaving
        {
            get => _isSaving;
            set => SetProperty(ref _isSaving, value, nameof(IsSaving), nameof(IsNotSaving));
        }

        public bool IsNotSaving => !_isSaving;

        private async Task SaveItem()
        {
            IsSaving = true;
            await _repository.AddItemAsync(Item);
            await Navigation.PopModalAsync(true);
            MessagingCenter.Send(this, "Todo added");
            IsSaving = false;
        }
    }
}