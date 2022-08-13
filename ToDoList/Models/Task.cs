using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Models
{
    public class Task
    {
        public string TaskName { get; set; }
        public bool IsDone { get; set; }
        public Guid DayId{ get; set; }
        public Day Day{ get; set; }
        public Guid Id { get; internal set; }

        public Task (string taskName)
        {
            Id = Guid.NewGuid ();   
            TaskName = taskName; 
        }
    }
}
