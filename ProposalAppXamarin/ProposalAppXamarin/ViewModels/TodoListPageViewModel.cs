using ProposalAppXamarin.Repositories;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProposalAppXamarin.ViewModels
{
    public class TodoListPageViewModel : BaseViewModel
    {
        private readonly ITodoRepository _repository = DependencyService.Get<ITodoRepository>();
        private bool _isBusy;

        public TodoListPageViewModel()
        {
            LoadItemsCommand = new Command(async () => await LoadTodos());
            DeleteCommand = new Command<TodoItem>(DeleteItem);
            MessagingCenter.Subscribe<TodoItem>(this, "Todo added", _ => IsBusy = true);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value, nameof(IsBusy), nameof(ShowList), nameof(DoNotShowList));
        }

        public ObservableCollection<TodoItem> Todos { get; } = new ObservableCollection<TodoItem>();

        public bool ShowList => Todos.Count > 0 && !IsBusy;
        public bool DoNotShowList => Todos.Count == 0 && !IsBusy;
        public Command LoadItemsCommand { get; }

        public Command DeleteCommand { get; }

        public Command CheckCommand { get; } = new Command<TodoItem>(CheckItem);

        private static void CheckItem(TodoItem todoItem)
            => todoItem.IsDone = !todoItem.IsDone;

        private void DeleteItem(TodoItem todoItem)
        {
            Todos.Remove(todoItem);
            _repository.RemoveTodo(todoItem);
            OnPropertyChanged(nameof(ShowList), nameof(DoNotShowList));
        }

        public async Task LoadTodos()
        {
            IsBusy = true;
            Todos.Clear();
            var todos = await _repository.LoadTodos();
            foreach (var todo in todos)
                Todos.Add(todo);
            IsBusy = false;
        }
    }
}
