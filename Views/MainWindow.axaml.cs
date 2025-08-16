using Avalonia.Controls;
using System;
using System.Collections.ObjectModel;
using Tmds.DBus.Protocol;
using ToDoApp.Models;
using ToDoApp.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace ToDoApp.Views;

public partial class MainWindow : Window
{
    private MainWindowViewModel ViewModel => (MainWindowViewModel)this.DataContext;
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainWindowViewModel();
    }

    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        AddTodo();
    }
    private void RemoveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Todo todo)
        {
            ViewModel.RemoveAction(todo.TodoAction);
        }
    }

    private void NewToDoTextBox_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        if (e.Key == Avalonia.Input.Key.Enter)
        {
            AddTodo();
            e.Handled = true;
        }
    }

    private void AddTodo()
    {
        var text = NewToDoTextBox.Text;
        if (!string.IsNullOrWhiteSpace(text))
        {
            ViewModel.AddAction(text);
            NewToDoTextBox.Text = "";
        }
    }
    private void ClearList_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ViewModel.ClearActions();
    }
}