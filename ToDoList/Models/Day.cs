using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoList.Models
{
    public class Day
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public ObservableCollection<Task> ListTask { get; set; } = new ObservableCollection<Task>();
        public Day(DateTime date)
        {
            Id = Guid.NewGuid();
            Date = date;

        }
    }
}
