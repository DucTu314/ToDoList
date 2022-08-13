using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToDoList.Models
{
    public class Day
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public ObservableCollection<Task> ListTask { get; set; } = new ObservableCollection<Task>();
        public Day(DateTime date)
        {
            Id = Guid.NewGuid();
            Date = date;

        }
    }
}
