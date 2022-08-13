using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class ToDoListViewModel
    {
        public List<Task> ListTasks{ get; set; } = new List<Task> { };
        public ToDoListViewModel()
        {
            ListTasks.Add(new Task(1,"Làm việc đi"));
        }
    }
}
