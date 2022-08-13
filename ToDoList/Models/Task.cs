using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public bool IsDone { get; set; }
        public Task (string taskName)
        {
            Id = Guid.NewGuid(); 
            TaskName = taskName; 
        }
    }
}
