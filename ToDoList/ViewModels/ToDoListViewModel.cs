using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ToDoList.Commands;
using ToDoList.Models;

namespace ToDoList.ViewModels 
{
    public class ToDoListViewModel : BaseViewModel
    {
        public ObservableCollection<Task> ListTasks{ get; set; } = new ObservableCollection<Task> { };
        public ObservableCollection<Task> ListDays{ get; set; } = new ObservableCollection<Task> { };
        public Task SelectedTask { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CompleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ToDoListViewModel()
        {
            ListTasks.Add(new Task("Làm việc đi"));
            ListTasks.Add(new Task("Làm việc đi"));
            ListTasks.Add(new Task("Làm việc đi"));
            ListTasks.Add(new Task("Làm việc đi"));
            ListTasks.Add(new Task("Làm việc đi"));
            ListTasks.Add(new Task("Làm việc đi"));
            ListTasks.Add(new Task("Làm việc đi"));
            ListTasks.Add(new Task("Làm việc đi"));
            DeleteCommand = new RelayCommand(DeleteAction);
            AddCommand = new RelayCommand(AddAction);
            Load();
        }

        private void Load()
        {
            //Load database go here 
        }

        private void DeleteAction()
        {
            ListTasks.Remove(SelectedTask)   ;
        }
        private void AddAction()
        {
            ListTasks.Add(new Task("what to do"));
        }
    }
}
