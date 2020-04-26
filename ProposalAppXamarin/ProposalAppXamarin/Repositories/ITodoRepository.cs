using System.Collections.Generic;
using System.Threading.Tasks;
using ProposalAppXamarin.ViewModels;

namespace ProposalAppXamarin.Repositories
{
    public interface ITodoRepository
    {
        Task AddItemAsync(TodoItem item);
        Task<IEnumerable<TodoItem>> LoadTodos();
        Task RemoveTodo(TodoItem todoItem);
    }
}
