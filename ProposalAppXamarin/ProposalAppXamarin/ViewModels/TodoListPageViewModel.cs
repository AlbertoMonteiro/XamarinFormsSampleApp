using ProposalAppXamarin.Repositories;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProposalAppXamarin.ViewModels
{
    public class TodoListPageViewModel : BaseViewModel
    {
        private readonly ITodoRepository _repository = DependencyService.Get<ITodoRepository>();

        public TodoListPageViewModel()
        {
            LoadItemsCommand = new Command(async () => await LoadTodos());
            DeleteCommand = new Command<TodoItem>(DeleteItem);
            MessagingCenter.Subscribe<TodoItem>(this, "Todo added", _ => IsBusy = true);
        }

        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                SetProperty(ref _isBusy, value);
                OnPropertyChanged(nameof(ShowList));
                OnPropertyChanged(nameof(DoNotShowList));
            }
        }

        public ObservableCollection<TodoItem> Todos { get; } = new ObservableCollection<TodoItem>();

        public bool ShowList => Todos.Count > 0 && !IsBusy;
        public bool DoNotShowList => Todos.Count == 0 && !IsBusy;
        public Command LoadItemsCommand { get; }

        public Command DeleteCommand { get; }

        public Command CkeckCommand { get; } = new Command<TodoItem>(CheckItem);

        private static void CheckItem(TodoItem todoItem)
            => todoItem.IsDone = !todoItem.IsDone;

        private void DeleteItem(TodoItem todoItem)
        {
            Todos.Remove(todoItem);
            _repository.RemoveTodo(todoItem);
            OnPropertyChanged(nameof(ShowList));
            OnPropertyChanged(nameof(DoNotShowList));
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
