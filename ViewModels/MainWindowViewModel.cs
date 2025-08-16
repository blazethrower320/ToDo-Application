using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoApp.Models;

namespace ToDoApp.ViewModels;

public partial class MainWindowViewModel : ObservableObject //ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<Todo> todoActions = new ObservableCollection<Todo>();
    public MainWindowViewModel()
    {
        Task.Run(async () =>
        {
            await Task.Delay(2000);
            TodoActions.Add(new Todo { TodoAction = "Action 1"});
        });

        
    }

    public void AddAction(string action)
    {
        TodoActions.Add(new Todo { TodoAction = action });
    }
    public void ClearActions()
    {
        TodoActions.Clear();
    }

    public void RemoveAction(string action)
    {
        var actionToRemove = TodoActions.FirstOrDefault(c => c.TodoAction.Equals(action, StringComparison.CurrentCultureIgnoreCase));
        if (actionToRemove == null) return;
        TodoActions.Remove(actionToRemove);
    }
}
