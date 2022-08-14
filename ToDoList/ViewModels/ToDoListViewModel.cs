using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ToDoList.Commands;
using ToDoList.Models;
using ToDoList.Repository;

namespace ToDoList.ViewModels
{
    public class ToDoListViewModel : BaseViewModel
    {
        private TaskRepository taskrp;
        private DayRepository dayrp;

        public ObservableCollection<Task> ListTasks
        {
            get
            {
                if (SelectedDate == null)
                {
                    return new ObservableCollection<Task>();
                }
                else return SelectedDate.ListTask;
            }
            set
            {
                if (value == null)
                {
                    SelectedDate.ListTask.Clear();
                    foreach (var task in value)
                    {
                        SelectedDate.ListTask.Add(task);
                    }
                };
            }
        }
        public ObservableCollection<Day> ListDates { get; set; } = new ObservableCollection<Day> { };
        private Task selectedTask;
        public Task SelectedTask
        {
            get => selectedTask;
            set
            {
                selectedTask = value;
            }
        }
        private void ModifiedTask(ObservableCollection<Task> ListTasks)
        {
            _lock = false;
            taskrp.UpdateTask(ListTasks);
            _lock = true;
        }

        private Day selectedDate = new Day(new DateTime(1999, 1, 1)); //dummy date
        private bool _lock = true;

        public Day SelectedDate
        {
            get => selectedDate;
            set
            {
                if ((value != null) & (selectedDate.Date != value.Date))
                {
                    selectedDate = value;
                    ListTasks.Clear();
                    foreach (var date in taskrp.Read(selectedDate.Id))
                    {
                        ListTasks.Add(date);
                    }
                }
            }
        }
        public ICommand DeleteCommand { get; set; }
        public ICommand CompleteCommand { get; set; }
        public ICommand AddDateCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ToDoListViewModel()
        {
            Load();
        }

        private void Load()
        {
            taskrp = new TaskRepository();
            dayrp = new DayRepository();
            DeleteCommand = new RelayCommand(DeleteAction);
            AddCommand = new RelayCommand(AddAction);
            SaveCommand = new RelayCommand(SaveAction);
            AddDateCommand = new RelayCommand(AddDateAction);
            LoadDay();
            if (selectedDate != null)
            {

                foreach (var task in taskrp.Read(selectedDate.Id))
                {
                    ListTasks.Add(task);
                };
            }
        }

        private void SaveAction()
        {
            ModifiedTask(ListTasks);
        }

        private void LoadDay()
        {
            var dates = dayrp.Read();
            foreach (var date in dates)
            {
                ListDates.Add(date);
            }
            if (ListDates.Count != 0)
            {

                selectedDate = ListDates[0];
            }
            else
            {
                selectedDate = null;
            }
        }

        private void AddDateAction()
        {
            if (_lock)
            {
                if (ListDates.Count != 0)
                {
                    DateTime temp = (DateTime)(ListDates[ListDates.Count - 1]).Date.Date.AddDays(1);
                    ListDates.Add(new Day(temp));
                    dayrp.Create(new Day(temp));
                }
                else
                {
                    ListDates.Add(new Day(DateTime.UtcNow));
                    dayrp.Create(new Day(DateTime.UtcNow));
                }
            }
        }
        private void DeleteAction()
        {
            if (_lock)
            {
                if (selectedTask != null)
                {
                    taskrp.Delete(SelectedTask.Id);
                    ListTasks.Remove(SelectedTask);
                }
            }

        }
        private void AddAction()
        {
            if (_lock)
            {
                if (selectedDate != null)
                {
                    var temp = new Task("what to do", selectedDate.Id);
                    ListTasks.Add(temp);
                    taskrp.Create(temp);
                }

            }
        }
    }
}
