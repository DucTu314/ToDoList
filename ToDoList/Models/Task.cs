using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public Task(int id, string taskName)
        {
            Id = id; TaskName = taskName; 
        }
    }
}
