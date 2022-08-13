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
        public ObservableCollection<Task> ListTasks {
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
                if(value == null)
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
        public Task SelectedTask { get; set; }
        private Day selectedDate = new Day(new DateTime(1999,1,1));
        public Day SelectedDate
        {
            get => selectedDate;
            set 
                {
                if ((value != null) &(selectedDate.Date != value.Date))
                {

                    selectedDate = value;
                    ListTasks = selectedDate.ListTask as ObservableCollection<Task>;
                }
                }
        }

        private void ReloadListTask()
        {
            //ReloadListTask
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand CompleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ToDoListViewModel()
        {
            Load();
        }

        private void Load()
        {
            DeleteCommand = new RelayCommand(DeleteAction);
            AddCommand = new RelayCommand(AddAction);
            //Load database go here 
            var Date1 = new Day(new DateTime(2022, 8, 10));
            test(Date1.ListTask, 1);
            var Date2 = new Day(new DateTime(2022, 8, 11));
            test(Date2.ListTask, 2);
            var Date3 = new Day(new DateTime(2022, 8, 12));
            test(Date3.ListTask, 3);
            var Date4 = new Day(new DateTime(2022, 8, 13));
            test(Date4.ListTask, 4);
            var Date5 = new Day(new DateTime(2022, 8, 14));
            test(Date5.ListTask, 5);
            var Date6 = new Day(new DateTime(2022, 8, 15));
            test(Date6.ListTask, 6);
            ListDates.Add(Date1);
            ListDates.Add(Date2);
            ListDates.Add(Date3);
            ListDates.Add(Date4);
            ListDates.Add(Date5);
            ListDates.Add(Date6);
        }

        private void test(ObservableCollection<Task> ListTasks, int v)
        {
            for(int i = 0; i < v; i++)
            {
                ListTasks.Add(new Task("Làm việc đi"));
            }
        }

        private void DeleteAction()
        {
            ListTasks.Remove(SelectedTask);
        }
        private void AddAction()
        {
            ListTasks.Add(new Task("what to do"));
        }
    }
}
