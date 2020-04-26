using ProposalAppXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProposalAppXamarin.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly List<TodoItem> _items = new List<TodoItem>();

        public Task AddItemAsync(TodoItem item)
            => Delayed(1000, () => _items.Add(item));

        public async Task<IEnumerable<TodoItem>> LoadTodos()
        {
            await Task.Delay(2000);
            return _items.AsEnumerable();
        }

        public Task RemoveTodo(TodoItem todoItem)
            => Delayed(1000, () => _items.Remove(todoItem));

        private static async Task Delayed(int milliseconds, Action action)
        {
            await Task.Delay(milliseconds);
            action();
        }
    }
}